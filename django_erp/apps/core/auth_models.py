"""
Authentication models for the ERP system.
Custom User model and UserProfile for extended user information.
"""

from django.contrib.auth.models import AbstractUser
from django.db import models
from django.core.validators import RegexValidator
from .models import TimeStampedModel


class User(AbstractUser):
    """
    Custom User model extending Django's AbstractUser.
    Adds employee_id and phone fields.
    """
    employee_id = models.CharField(
        max_length=20,
        unique=True,
        null=True,
        blank=True,
        help_text='Employee ID for linking to HR module'
    )
    phone_regex = RegexValidator(
        regex=r'^(\+91[-\s]?)?[6-9]\d{9}$',
        message="Phone number must be valid Indian format: +91-9876543210 or 9876543210"
    )
    phone = models.CharField(
        validators=[phone_regex],
        max_length=17,
        blank=True,
        help_text='Phone number in Indian format'
    )

    class Meta:
        db_table = 'auth_user'
        verbose_name = 'User'
        verbose_name_plural = 'Users'
        ordering = ['username']

    def __str__(self):
        return f"{self.get_full_name() or self.username} ({self.username})"

    def get_display_name(self):
        """Get display name (full name or username)."""
        return self.get_full_name() or self.username


class UserProfile(TimeStampedModel):
    """
    Extended user profile with company and role information.
    One-to-One relationship with User model.
    """
    user = models.OneToOneField(
        User,
        on_delete=models.CASCADE,
        related_name='profile',
        help_text='Associated user account'
    )
    company = models.ForeignKey(
        'sysconfig.Company',
        on_delete=models.CASCADE,
        related_name='user_profiles',
        help_text='Company this user belongs to'
    )
    default_financial_year = models.ForeignKey(
        'sysconfig.FinancialYear',
        on_delete=models.SET_NULL,
        null=True,
        blank=True,
        related_name='user_profiles',
        help_text='Default financial year for this user'
    )
    # Note: department field will be added when HR module is implemented
    designation = models.CharField(
        max_length=100,
        blank=True,
        help_text='Job designation/title'
    )
    photo = models.ImageField(
        upload_to='user_photos/%Y/%m/',
        blank=True,
        null=True,
        help_text='Profile photo'
    )
    bio = models.TextField(
        blank=True,
        help_text='Short biography'
    )

    # Preferences
    theme = models.CharField(
        max_length=20,
        choices=[
            ('light', 'Light'),
            ('dark', 'Dark'),
            ('auto', 'Auto'),
        ],
        default='light',
        help_text='UI theme preference'
    )
    language = models.CharField(
        max_length=10,
        choices=[
            ('en', 'English'),
            ('hi', 'Hindi'),
        ],
        default='en',
        help_text='Preferred language'
    )
    timezone = models.CharField(
        max_length=50,
        default='Asia/Kolkata',
        help_text='User timezone'
    )

    # Notification preferences
    email_notifications = models.BooleanField(
        default=True,
        help_text='Receive email notifications'
    )
    push_notifications = models.BooleanField(
        default=True,
        help_text='Receive push notifications'
    )

    class Meta:
        db_table = 'core_userprofile'
        verbose_name = 'User Profile'
        verbose_name_plural = 'User Profiles'

    def __str__(self):
        return f"Profile of {self.user.get_display_name()}"

    def get_initials(self):
        """Get user initials for avatar."""
        if self.user.first_name and self.user.last_name:
            return f"{self.user.first_name[0]}{self.user.last_name[0]}".upper()
        return self.user.username[0].upper()
