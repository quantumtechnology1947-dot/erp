"""
Core abstract models for ERP system.
All app models should inherit from these base models for consistency.
"""

from django.conf import settings
from django.db import models
from django.contrib.auth import get_user_model
from django.utils import timezone


class TimeStampedModel(models.Model):
    """
    Abstract base model that provides self-updating
    'created_at' and 'updated_at' fields.
    """
    created_at = models.DateTimeField(
        auto_now_add=True,
        editable=False,
        help_text='Date and time when the record was created'
    )
    updated_at = models.DateTimeField(
        auto_now=True,
        editable=False,
        help_text='Date and time when the record was last updated'
    )

    class Meta:
        abstract = True
        ordering = ['-created_at']


class SoftDeleteModel(models.Model):
    """
    Abstract base model that provides soft delete functionality.
    Records are not physically deleted but marked as deleted.
    """
    is_deleted = models.BooleanField(
        default=False,
        help_text='Whether this record is soft-deleted'
    )
    deleted_at = models.DateTimeField(
        null=True,
        blank=True,
        editable=False,
        help_text='Date and time when the record was deleted'
    )
    deleted_by = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        null=True,
        blank=True,
        on_delete=models.SET_NULL,
        related_name='%(app_label)s_%(class)s_deletions',
        help_text='User who deleted this record'
    )

    class Meta:
        abstract = True

    def soft_delete(self, user=None):
        """Soft delete the record."""
        self.is_deleted = True
        self.deleted_at = timezone.now()
        if user:
            self.deleted_by = user
        self.save()

    def restore(self):
        """Restore a soft-deleted record."""
        self.is_deleted = False
        self.deleted_at = None
        self.deleted_by = None
        self.save()


class CompanyScopedModel(models.Model):
    """
    Abstract base model for multi-company support.
    All records are scoped to a specific company.
    """
    company = models.ForeignKey(
        'sysconfig.Company',
        on_delete=models.CASCADE,
        related_name='%(app_label)s_%(class)s_records',
        help_text='Company this record belongs to'
    )

    class Meta:
        abstract = True


class AuditMixin(models.Model):
    """
    Abstract mixin that tracks who created and last updated a record.
    """
    created_by = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        on_delete=models.SET_NULL,
        null=True,
        blank=True,
        related_name='%(app_label)s_%(class)s_created',
        help_text='User who created this record'
    )
    updated_by = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        on_delete=models.SET_NULL,
        null=True,
        blank=True,
        related_name='%(app_label)s_%(class)s_updated',
        help_text='User who last updated this record'
    )

    class Meta:
        abstract = True


class ApprovalWorkflowModel(models.Model):
    """
    Abstract model for multi-level approval workflow.
    Implements Check → Approve → Authorize pattern.
    """
    STATUS_CHOICES = [
        ('draft', 'Draft'),
        ('submitted', 'Submitted'),
        ('checked', 'Checked'),
        ('approved', 'Approved'),
        ('authorized', 'Authorized'),
        ('rejected', 'Rejected'),
    ]

    status = models.CharField(
        max_length=20,
        choices=STATUS_CHOICES,
        default='draft',
        db_index=True,
        help_text='Current approval status'
    )

    # Check level
    checked_by = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        null=True,
        blank=True,
        on_delete=models.SET_NULL,
        related_name='%(app_label)s_%(class)s_checked',
        help_text='User who checked this record'
    )
    checked_at = models.DateTimeField(
        null=True,
        blank=True,
        help_text='Date and time when checked'
    )
    check_remarks = models.TextField(
        blank=True,
        help_text='Remarks from checker'
    )

    # Approve level
    approved_by = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        null=True,
        blank=True,
        on_delete=models.SET_NULL,
        related_name='%(app_label)s_%(class)s_approved',
        help_text='User who approved this record'
    )
    approved_at = models.DateTimeField(
        null=True,
        blank=True,
        help_text='Date and time when approved'
    )
    approve_remarks = models.TextField(
        blank=True,
        help_text='Remarks from approver'
    )

    # Authorize level
    authorized_by = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        null=True,
        blank=True,
        on_delete=models.SET_NULL,
        related_name='%(app_label)s_%(class)s_authorized',
        help_text='User who authorized this record'
    )
    authorized_at = models.DateTimeField(
        null=True,
        blank=True,
        help_text='Date and time when authorized'
    )
    authorize_remarks = models.TextField(
        blank=True,
        help_text='Remarks from authorizer'
    )

    # Rejection
    rejection_reason = models.TextField(
        blank=True,
        help_text='Reason for rejection'
    )

    class Meta:
        abstract = True

    def submit(self):
        """Submit for approval."""
        if self.status == 'draft':
            self.status = 'submitted'
            self.save()

    def check(self, user, remarks=''):
        """Check the record."""
        if self.status == 'submitted':
            self.status = 'checked'
            self.checked_by = user
            self.checked_at = timezone.now()
            self.check_remarks = remarks
            self.save()

    def approve(self, user, remarks=''):
        """Approve the record."""
        if self.status == 'checked':
            self.status = 'approved'
            self.approved_by = user
            self.approved_at = timezone.now()
            self.approve_remarks = remarks
            self.save()

    def authorize(self, user, remarks=''):
        """Authorize the record."""
        if self.status == 'approved':
            self.status = 'authorized'
            self.authorized_by = user
            self.authorized_at = timezone.now()
            self.authorize_remarks = remarks
            self.save()

    def reject(self, user, reason):
        """Reject the record."""
        if self.status in ['submitted', 'checked', 'approved']:
            self.status = 'rejected'
            self.rejection_reason = reason
            self.save()

    def is_editable(self):
        """Check if record can be edited."""
        return self.status in ['draft', 'rejected']

    def is_authorized(self):
        """Check if record is fully authorized."""
        return self.status == 'authorized'


class ActiveManager(models.Manager):
    """
    Custom manager that filters out soft-deleted records by default.
    """
    def get_queryset(self):
        return super().get_queryset().filter(is_deleted=False)


class AllObjectsManager(models.Manager):
    """
    Manager that returns all objects including soft-deleted ones.
    """
    def get_queryset(self):
        return super().get_queryset()


# Import auth models to make User and UserProfile available
from .auth_models import User, UserProfile  # noqa: F401, E402
