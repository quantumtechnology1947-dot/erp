"""
Custom validators for the ERP system.
"""

from django.core.exceptions import ValidationError
from django.utils.translation import gettext_lazy as _
import re


def validate_phone_number(value):
    """
    Validate phone number format.
    Accepts: +91-9876543210, 9876543210, +919876543210
    """
    pattern = r'^(\+91[-\s]?)?[6-9]\d{9}$'
    if not re.match(pattern, value):
        raise ValidationError(
            _('%(value)s is not a valid phone number. Please enter a valid Indian phone number.'),
            params={'value': value},
        )


def validate_gstin(value):
    """
    Validate Indian GSTIN format.
    Format: 22AAAAA0000A1Z5
    """
    if not value:
        return

    pattern = r'^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$'
    if not re.match(pattern, value.upper()):
        raise ValidationError(
            _('%(value)s is not a valid GSTIN. Format should be: 22AAAAA0000A1Z5'),
            params={'value': value},
        )


def validate_pan(value):
    """
    Validate Indian PAN format.
    Format: AAAAA9999A
    """
    if not value:
        return

    pattern = r'^[A-Z]{5}[0-9]{4}[A-Z]{1}$'
    if not re.match(pattern, value.upper()):
        raise ValidationError(
            _('%(value)s is not a valid PAN. Format should be: AAAAA9999A'),
            params={'value': value},
        )


def validate_pincode(value):
    """
    Validate Indian pincode format.
    Format: 6 digits
    """
    if not value:
        return

    pattern = r'^\d{6}$'
    if not re.match(pattern, value):
        raise ValidationError(
            _('%(value)s is not a valid pincode. Please enter a 6-digit pincode.'),
            params={'value': value},
        )


def validate_ifsc_code(value):
    """
    Validate Indian IFSC code format.
    Format: ABCD0123456 (4 letters + 7 digits, 5th char is 0)
    """
    if not value:
        return

    pattern = r'^[A-Z]{4}0[A-Z0-9]{6}$'
    if not re.match(pattern, value.upper()):
        raise ValidationError(
            _('%(value)s is not a valid IFSC code. Format should be: ABCD0123456'),
            params={'value': value},
        )


def validate_positive_decimal(value):
    """
    Validate that decimal value is positive.
    """
    if value < 0:
        raise ValidationError(
            _('%(value)s must be a positive number.'),
            params={'value': value},
        )


def validate_positive_integer(value):
    """
    Validate that integer value is positive.
    """
    if value < 0:
        raise ValidationError(
            _('%(value)s must be a positive integer.'),
            params={'value': value},
        )


def validate_percentage(value):
    """
    Validate that value is between 0 and 100.
    """
    if value < 0 or value > 100:
        raise ValidationError(
            _('%(value)s must be between 0 and 100.'),
            params={'value': value},
        )


def validate_email_domain(value, allowed_domains=None):
    """
    Validate email domain against allowed list.
    """
    if allowed_domains is None:
        return

    domain = value.split('@')[-1].lower()
    if domain not in allowed_domains:
        raise ValidationError(
            _('Email domain %(domain)s is not allowed. Allowed domains: %(allowed)s'),
            params={'domain': domain, 'allowed': ', '.join(allowed_domains)},
        )


def validate_file_size(value, max_size_mb=5):
    """
    Validate file size.

    Args:
        value: File field value
        max_size_mb: Maximum file size in MB
    """
    if value.size > max_size_mb * 1024 * 1024:
        raise ValidationError(
            _('File size must not exceed %(max_size)s MB. Current size: %(current_size).2f MB'),
            params={
                'max_size': max_size_mb,
                'current_size': value.size / (1024 * 1024)
            },
        )


def validate_file_extension(value, allowed_extensions=None):
    """
    Validate file extension.

    Args:
        value: File field value
        allowed_extensions: List of allowed extensions (e.g., ['pdf', 'jpg', 'png'])
    """
    if allowed_extensions is None:
        allowed_extensions = ['pdf', 'jpg', 'jpeg', 'png', 'doc', 'docx', 'xls', 'xlsx']

    import os
    ext = os.path.splitext(value.name)[1][1:].lower()

    if ext not in allowed_extensions:
        raise ValidationError(
            _('File extension "%(ext)s" is not allowed. Allowed extensions: %(allowed)s'),
            params={'ext': ext, 'allowed': ', '.join(allowed_extensions)},
        )


def validate_future_date(value):
    """
    Validate that date is in the future.
    """
    from django.utils import timezone

    if value < timezone.now().date():
        raise ValidationError(
            _('Date must be in the future.'),
        )


def validate_past_date(value):
    """
    Validate that date is in the past.
    """
    from django.utils import timezone

    if value > timezone.now().date():
        raise ValidationError(
            _('Date must be in the past.'),
        )
