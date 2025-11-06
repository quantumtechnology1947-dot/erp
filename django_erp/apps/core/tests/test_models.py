"""
Tests for core abstract models.
"""

import pytest
from django.test import TestCase
from django.contrib.auth import get_user_model
from django.utils import timezone
from datetime import timedelta

User = get_user_model()


# Since core models are abstract, we need concrete implementations for testing
from django.db import models
from apps.core.models import (
    TimeStampedModel,
    SoftDeleteModel,
    AuditMixin,
    ApprovalWorkflowModel,
    ActiveManager,
    AllObjectsManager
)


# Create concrete test models
class TestTimeStampedModel(TimeStampedModel):
    name = models.CharField(max_length=100)

    class Meta:
        app_label = 'core'


class TestSoftDeleteModel(SoftDeleteModel):
    name = models.CharField(max_length=100)

    objects = ActiveManager()
    all_objects = AllObjectsManager()

    class Meta:
        app_label = 'core'


class TestAuditModel(TimeStampedModel, AuditMixin):
    name = models.CharField(max_length=100)

    class Meta:
        app_label = 'core'


class TestApprovalModel(TimeStampedModel, AuditMixin, ApprovalWorkflowModel):
    name = models.CharField(max_length=100)

    class Meta:
        app_label = 'core'


@pytest.mark.django_db
class TestTimeStampedModelCase:
    """Test TimeStampedModel functionality."""

    def test_created_at_auto_set(self):
        """Test that created_at is automatically set on creation."""
        obj = TestTimeStampedModel.objects.create(name='Test')
        assert obj.created_at is not None
        assert obj.created_at <= timezone.now()

    def test_updated_at_auto_set(self):
        """Test that updated_at is automatically set on creation."""
        obj = TestTimeStampedModel.objects.create(name='Test')
        assert obj.updated_at is not None
        assert obj.updated_at <= timezone.now()

    def test_updated_at_changes_on_save(self):
        """Test that updated_at changes when object is updated."""
        obj = TestTimeStampedModel.objects.create(name='Test')
        original_updated_at = obj.updated_at

        # Wait a bit to ensure timestamp difference
        import time
        time.sleep(0.1)

        obj.name = 'Updated'
        obj.save()

        assert obj.updated_at > original_updated_at

    def test_created_at_does_not_change(self):
        """Test that created_at doesn't change on update."""
        obj = TestTimeStampedModel.objects.create(name='Test')
        original_created_at = obj.created_at

        obj.name = 'Updated'
        obj.save()

        assert obj.created_at == original_created_at


@pytest.mark.django_db
class TestSoftDeleteModelCase:
    """Test SoftDeleteModel functionality."""

    def setup_method(self):
        """Set up test data."""
        self.user = User.objects.create_user(username='testuser', password='12345')

    def test_default_not_deleted(self):
        """Test that objects are not deleted by default."""
        obj = TestSoftDeleteModel.objects.create(name='Test')
        assert obj.is_deleted is False
        assert obj.deleted_at is None
        assert obj.deleted_by is None

    def test_soft_delete(self):
        """Test soft delete functionality."""
        obj = TestSoftDeleteModel.objects.create(name='Test')
        obj.soft_delete(user=self.user)

        obj.refresh_from_db()
        assert obj.is_deleted is True
        assert obj.deleted_at is not None
        assert obj.deleted_by == self.user

    def test_soft_delete_without_user(self):
        """Test soft delete without user."""
        obj = TestSoftDeleteModel.objects.create(name='Test')
        obj.soft_delete()

        obj.refresh_from_db()
        assert obj.is_deleted is True
        assert obj.deleted_at is not None
        assert obj.deleted_by is None

    def test_restore(self):
        """Test restoring a soft-deleted object."""
        obj = TestSoftDeleteModel.objects.create(name='Test')
        obj.soft_delete(user=self.user)
        obj.restore()

        obj.refresh_from_db()
        assert obj.is_deleted is False
        assert obj.deleted_at is None
        assert obj.deleted_by is None

    def test_active_manager_excludes_deleted(self):
        """Test that ActiveManager excludes soft-deleted objects."""
        obj1 = TestSoftDeleteModel.objects.create(name='Active')
        obj2 = TestSoftDeleteModel.objects.create(name='Deleted')
        obj2.soft_delete()

        active_objects = TestSoftDeleteModel.objects.all()
        assert active_objects.count() == 1
        assert obj1 in active_objects
        assert obj2 not in active_objects

    def test_all_objects_manager_includes_deleted(self):
        """Test that AllObjectsManager includes soft-deleted objects."""
        obj1 = TestSoftDeleteModel.objects.create(name='Active')
        obj2 = TestSoftDeleteModel.objects.create(name='Deleted')
        obj2.soft_delete()

        all_objects = TestSoftDeleteModel.all_objects.all()
        assert all_objects.count() == 2
        assert obj1 in all_objects
        assert obj2 in all_objects


@pytest.mark.django_db
class TestAuditMixinCase:
    """Test AuditMixin functionality."""

    def setup_method(self):
        """Set up test data."""
        self.user1 = User.objects.create_user(username='user1', password='12345')
        self.user2 = User.objects.create_user(username='user2', password='12345')

    def test_created_by_can_be_set(self):
        """Test that created_by can be set."""
        obj = TestAuditModel.objects.create(name='Test', created_by=self.user1)
        assert obj.created_by == self.user1

    def test_updated_by_can_be_set(self):
        """Test that updated_by can be set."""
        obj = TestAuditModel.objects.create(
            name='Test',
            created_by=self.user1,
            updated_by=self.user1
        )
        assert obj.updated_by == self.user1

    def test_updated_by_changes_on_update(self):
        """Test that updated_by can change on update."""
        obj = TestAuditModel.objects.create(
            name='Test',
            created_by=self.user1,
            updated_by=self.user1
        )

        obj.name = 'Updated'
        obj.updated_by = self.user2
        obj.save()

        obj.refresh_from_db()
        assert obj.created_by == self.user1  # Should not change
        assert obj.updated_by == self.user2  # Should change


@pytest.mark.django_db
class TestApprovalWorkflowModelCase:
    """Test ApprovalWorkflowModel functionality."""

    def setup_method(self):
        """Set up test data."""
        self.checker = User.objects.create_user(username='checker', password='12345')
        self.approver = User.objects.create_user(username='approver', password='12345')
        self.authorizer = User.objects.create_user(username='authorizer', password='12345')

    def test_default_status_is_draft(self):
        """Test that default status is draft."""
        obj = TestApprovalModel.objects.create(name='Test')
        assert obj.status == 'draft'

    def test_submit_workflow(self):
        """Test submit functionality."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.submit()

        obj.refresh_from_db()
        assert obj.status == 'submitted'

    def test_check_workflow(self):
        """Test check functionality."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.submit()
        obj.check(self.checker, 'Looks good')

        obj.refresh_from_db()
        assert obj.status == 'checked'
        assert obj.checked_by == self.checker
        assert obj.checked_at is not None
        assert obj.check_remarks == 'Looks good'

    def test_approve_workflow(self):
        """Test approve functionality."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.submit()
        obj.check(self.checker, 'Looks good')
        obj.approve(self.approver, 'Approved')

        obj.refresh_from_db()
        assert obj.status == 'approved'
        assert obj.approved_by == self.approver
        assert obj.approved_at is not None
        assert obj.approve_remarks == 'Approved'

    def test_authorize_workflow(self):
        """Test authorize functionality."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.submit()
        obj.check(self.checker)
        obj.approve(self.approver)
        obj.authorize(self.authorizer, 'Authorized')

        obj.refresh_from_db()
        assert obj.status == 'authorized'
        assert obj.authorized_by == self.authorizer
        assert obj.authorized_at is not None
        assert obj.authorize_remarks == 'Authorized'

    def test_reject_workflow(self):
        """Test reject functionality."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.submit()
        obj.reject(self.checker, 'Incorrect data')

        obj.refresh_from_db()
        assert obj.status == 'rejected'
        assert obj.rejection_reason == 'Incorrect data'

    def test_is_editable_draft(self):
        """Test that draft objects are editable."""
        obj = TestApprovalModel.objects.create(name='Test')
        assert obj.is_editable() is True

    def test_is_editable_rejected(self):
        """Test that rejected objects are editable."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.submit()
        obj.reject(self.checker, 'Needs correction')
        assert obj.is_editable() is True

    def test_is_not_editable_submitted(self):
        """Test that submitted objects are not editable."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.submit()
        assert obj.is_editable() is False

    def test_is_authorized(self):
        """Test is_authorized check."""
        obj = TestApprovalModel.objects.create(name='Test')
        assert obj.is_authorized() is False

        obj.submit()
        obj.check(self.checker)
        obj.approve(self.approver)
        obj.authorize(self.authorizer)

        assert obj.is_authorized() is True

    def test_check_only_from_submitted(self):
        """Test that check only works from submitted status."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.check(self.checker)  # Should not work from draft

        obj.refresh_from_db()
        assert obj.status == 'draft'  # Should remain draft

    def test_approve_only_from_checked(self):
        """Test that approve only works from checked status."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.submit()
        obj.approve(self.approver)  # Should not work from submitted

        obj.refresh_from_db()
        assert obj.status == 'submitted'  # Should remain submitted

    def test_authorize_only_from_approved(self):
        """Test that authorize only works from approved status."""
        obj = TestApprovalModel.objects.create(name='Test')
        obj.submit()
        obj.check(self.checker)
        obj.authorize(self.authorizer)  # Should not work from checked

        obj.refresh_from_db()
        assert obj.status == 'checked'  # Should remain checked
