"""
Tests for core validators.
"""

import pytest
from django.core.exceptions import ValidationError
from apps.core.validators import (
    validate_phone_number,
    validate_gstin,
    validate_pan,
    validate_pincode,
    validate_ifsc_code,
    validate_positive_decimal,
    validate_positive_integer,
    validate_percentage,
)


class TestPhoneNumberValidator:
    """Test phone number validation."""

    def test_valid_phone_numbers(self):
        """Test valid phone numbers."""
        validate_phone_number('9876543210')  # Should not raise
        validate_phone_number('+919876543210')  # Should not raise
        validate_phone_number('+91-9876543210')  # Should not raise
        validate_phone_number('+91 9876543210')  # Should not raise

    def test_invalid_phone_starts_with_5(self):
        """Test phone number starting with invalid digit."""
        with pytest.raises(ValidationError):
            validate_phone_number('5876543210')

    def test_invalid_phone_too_short(self):
        """Test phone number too short."""
        with pytest.raises(ValidationError):
            validate_phone_number('987654321')

    def test_invalid_phone_too_long(self):
        """Test phone number too long."""
        with pytest.raises(ValidationError):
            validate_phone_number('98765432100')

    def test_invalid_phone_letters(self):
        """Test phone number with letters."""
        with pytest.raises(ValidationError):
            validate_phone_number('987ABC4210')


class TestGSTINValidator:
    """Test GSTIN validation."""

    def test_valid_gstin(self):
        """Test valid GSTIN."""
        validate_gstin('22AAAAA0000A1Z5')  # Should not raise
        validate_gstin('29ABCDE1234F1Z5')  # Should not raise

    def test_invalid_gstin_format(self):
        """Test invalid GSTIN format."""
        with pytest.raises(ValidationError):
            validate_gstin('22AAAAA0000A1A5')  # Wrong format (A instead of Z)

    def test_invalid_gstin_length(self):
        """Test invalid GSTIN length."""
        with pytest.raises(ValidationError):
            validate_gstin('22AAAAA0000A1Z')

    def test_empty_gstin(self):
        """Test that empty GSTIN doesn't raise (allowed to be blank)."""
        validate_gstin('')  # Should not raise
        validate_gstin(None)  # Should not raise


class TestPANValidator:
    """Test PAN validation."""

    def test_valid_pan(self):
        """Test valid PAN."""
        validate_pan('ABCDE1234F')  # Should not raise
        validate_pan('ZYXWV9876A')  # Should not raise

    def test_invalid_pan_format(self):
        """Test invalid PAN format."""
        with pytest.raises(ValidationError):
            validate_pan('12345ABCDE')

    def test_invalid_pan_length(self):
        """Test invalid PAN length."""
        with pytest.raises(ValidationError):
            validate_pan('ABCDE1234')

    def test_empty_pan(self):
        """Test that empty PAN doesn't raise (allowed to be blank)."""
        validate_pan('')  # Should not raise
        validate_pan(None)  # Should not raise


class TestPincodeValidator:
    """Test pincode validation."""

    def test_valid_pincode(self):
        """Test valid pincode."""
        validate_pincode('400001')  # Should not raise
        validate_pincode('110011')  # Should not raise

    def test_invalid_pincode_length(self):
        """Test invalid pincode length."""
        with pytest.raises(ValidationError):
            validate_pincode('4000')

        with pytest.raises(ValidationError):
            validate_pincode('4000011')

    def test_invalid_pincode_letters(self):
        """Test pincode with letters."""
        with pytest.raises(ValidationError):
            validate_pincode('40000A')

    def test_empty_pincode(self):
        """Test that empty pincode doesn't raise (allowed to be blank)."""
        validate_pincode('')  # Should not raise
        validate_pincode(None)  # Should not raise


class TestIFSCCodeValidator:
    """Test IFSC code validation."""

    def test_valid_ifsc(self):
        """Test valid IFSC code."""
        validate_ifsc_code('SBIN0001234')  # Should not raise
        validate_ifsc_code('HDFC0000123')  # Should not raise

    def test_invalid_ifsc_fifth_char(self):
        """Test IFSC with invalid 5th character."""
        with pytest.raises(ValidationError):
            validate_ifsc_code('SBIN1001234')  # 5th char must be 0

    def test_invalid_ifsc_length(self):
        """Test invalid IFSC length."""
        with pytest.raises(ValidationError):
            validate_ifsc_code('SBIN000123')

    def test_empty_ifsc(self):
        """Test that empty IFSC doesn't raise (allowed to be blank)."""
        validate_ifsc_code('')  # Should not raise
        validate_ifsc_code(None)  # Should not raise


class TestPositiveDecimalValidator:
    """Test positive decimal validation."""

    def test_valid_positive_decimal(self):
        """Test valid positive decimal."""
        from decimal import Decimal
        validate_positive_decimal(Decimal('10.50'))  # Should not raise
        validate_positive_decimal(Decimal('0'))  # Should not raise

    def test_invalid_negative_decimal(self):
        """Test invalid negative decimal."""
        from decimal import Decimal
        with pytest.raises(ValidationError):
            validate_positive_decimal(Decimal('-10.50'))


class TestPositiveIntegerValidator:
    """Test positive integer validation."""

    def test_valid_positive_integer(self):
        """Test valid positive integer."""
        validate_positive_integer(10)  # Should not raise
        validate_positive_integer(0)  # Should not raise

    def test_invalid_negative_integer(self):
        """Test invalid negative integer."""
        with pytest.raises(ValidationError):
            validate_positive_integer(-10)


class TestPercentageValidator:
    """Test percentage validation."""

    def test_valid_percentage(self):
        """Test valid percentage."""
        validate_percentage(0)  # Should not raise
        validate_percentage(50)  # Should not raise
        validate_percentage(100)  # Should not raise

    def test_invalid_percentage_below_zero(self):
        """Test percentage below zero."""
        with pytest.raises(ValidationError):
            validate_percentage(-1)

    def test_invalid_percentage_above_100(self):
        """Test percentage above 100."""
        with pytest.raises(ValidationError):
            validate_percentage(101)
