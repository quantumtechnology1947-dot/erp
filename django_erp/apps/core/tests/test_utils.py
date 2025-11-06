"""
Tests for core utility functions.
"""

import pytest
from datetime import datetime, date
from decimal import Decimal
from apps.core.utils import (
    generate_unique_code,
    generate_sequential_code,
    format_currency,
    calculate_gst,
    get_financial_year,
    get_financial_year_dates,
    validate_gstin,
    validate_pan,
    get_age_from_dob,
    convert_to_words,
)


class TestGenerateUniqueCode:
    """Test unique code generation."""

    def test_generates_code_without_prefix(self):
        """Test code generation without prefix."""
        code = generate_unique_code(length=8)
        assert len(code) == 8
        assert code.isalnum()
        assert code.isupper() or code.isdigit()

    def test_generates_code_with_prefix(self):
        """Test code generation with prefix."""
        code = generate_unique_code(prefix='TEST', length=8)
        assert code.startswith('TEST')
        assert len(code) == 12  # TEST + 8 chars

    def test_generates_unique_codes(self):
        """Test that multiple calls generate different codes."""
        code1 = generate_unique_code(length=8)
        code2 = generate_unique_code(length=8)
        assert code1 != code2


class TestFormatCurrency:
    """Test currency formatting."""

    def test_format_positive_amount(self):
        """Test formatting positive amount."""
        result = format_currency(1000)
        assert result == '₹ 1,000.00'

    def test_format_large_amount(self):
        """Test formatting large amount."""
        result = format_currency(1234567.89)
        assert result == '₹ 1,234,567.89'

    def test_format_zero(self):
        """Test formatting zero."""
        result = format_currency(0)
        assert result == '₹ 0.00'

    def test_format_none(self):
        """Test formatting None."""
        result = format_currency(None)
        assert result == '₹ 0.00'

    def test_format_with_different_currency(self):
        """Test formatting with different currency symbol."""
        result = format_currency(1000, currency='$')
        assert result == '$ 1,000.00'


class TestCalculateGST:
    """Test GST calculation."""

    def test_calculate_gst_18_percent(self):
        """Test GST calculation with 18% rate."""
        result = calculate_gst(1000, 18)

        assert result['base_amount'] == Decimal('1000')
        assert result['gst_rate'] == Decimal('18')
        assert result['gst_amount'] == Decimal('180.00')
        assert result['sgst'] == Decimal('90.00')
        assert result['cgst'] == Decimal('90.00')
        assert result['total_amount'] == Decimal('1180.00')

    def test_calculate_gst_12_percent(self):
        """Test GST calculation with 12% rate."""
        result = calculate_gst(1000, 12)

        assert result['gst_amount'] == Decimal('120.00')
        assert result['total_amount'] == Decimal('1120.00')

    def test_calculate_gst_with_decimal_amount(self):
        """Test GST calculation with decimal amount."""
        result = calculate_gst(1250.50, 18)

        assert result['base_amount'] == Decimal('1250.50')
        assert result['gst_amount'] == Decimal('225.09')
        assert result['total_amount'] == Decimal('1475.59')


class TestFinancialYear:
    """Test financial year functions."""

    def test_get_financial_year_april_onwards(self):
        """Test financial year for dates from April onwards."""
        test_date = date(2024, 6, 15)  # June 2024
        fy = get_financial_year(test_date)
        assert fy == '2024-2025'

    def test_get_financial_year_january_to_march(self):
        """Test financial year for dates from January to March."""
        test_date = date(2024, 2, 15)  # February 2024
        fy = get_financial_year(test_date)
        assert fy == '2023-2024'

    def test_get_financial_year_april_1(self):
        """Test financial year for April 1."""
        test_date = date(2024, 4, 1)
        fy = get_financial_year(test_date)
        assert fy == '2024-2025'

    def test_get_financial_year_march_31(self):
        """Test financial year for March 31."""
        test_date = date(2024, 3, 31)
        fy = get_financial_year(test_date)
        assert fy == '2023-2024'

    def test_get_financial_year_dates(self):
        """Test getting start and end dates for financial year."""
        start, end = get_financial_year_dates('2024-2025')

        assert start == date(2024, 4, 1)
        assert end == date(2025, 3, 31)


class TestValidateGSTIN:
    """Test GSTIN validation."""

    def test_valid_gstin(self):
        """Test valid GSTIN."""
        assert validate_gstin('22AAAAA0000A1Z5') is True
        assert validate_gstin('29ABCDE1234F1Z5') is True

    def test_invalid_gstin_length(self):
        """Test GSTIN with invalid length."""
        assert validate_gstin('22AAAAA0000A1Z') is False  # Too short
        assert validate_gstin('22AAAAA0000A1Z56') is False  # Too long

    def test_invalid_gstin_format(self):
        """Test GSTIN with invalid format."""
        assert validate_gstin('AA AAAAA0000A1Z5') is False  # Letters in first 2 positions
        assert validate_gstin('2212345000A1Z5') is False  # Digits instead of letters

    def test_empty_gstin(self):
        """Test empty GSTIN."""
        assert validate_gstin('') is False
        assert validate_gstin(None) is False

    def test_gstin_case_insensitive(self):
        """Test that GSTIN validation is case-insensitive."""
        assert validate_gstin('22aaaaa0000a1z5') is True


class TestValidatePAN:
    """Test PAN validation."""

    def test_valid_pan(self):
        """Test valid PAN."""
        assert validate_pan('ABCDE1234F') is True
        assert validate_pan('ZYXWV9876A') is True

    def test_invalid_pan_length(self):
        """Test PAN with invalid length."""
        assert validate_pan('ABCDE1234') is False  # Too short
        assert validate_pan('ABCDE1234FG') is False  # Too long

    def test_invalid_pan_format(self):
        """Test PAN with invalid format."""
        assert validate_pan('12345ABCDE') is False  # Wrong pattern
        assert validate_pan('ABCDEFGHIJ') is False  # No digits

    def test_empty_pan(self):
        """Test empty PAN."""
        assert validate_pan('') is False
        assert validate_pan(None) is False

    def test_pan_case_insensitive(self):
        """Test that PAN validation is case-insensitive."""
        assert validate_pan('abcde1234f') is True


class TestGetAgeFromDOB:
    """Test age calculation from date of birth."""

    def test_exact_years(self):
        """Test age calculation for exact years."""
        # If today is 2024-11-06
        dob = date(2000, 11, 6)
        age = get_age_from_dob(dob)
        assert age == 24

    def test_birthday_not_occurred(self):
        """Test age when birthday hasn't occurred this year."""
        # If today is 2024-11-06, and birthday is 2000-12-15
        dob = date(2000, 12, 15)
        age = get_age_from_dob(dob)
        assert age == 23  # Still 23 until Dec 15

    def test_birthday_already_occurred(self):
        """Test age when birthday has already occurred this year."""
        # If today is 2024-11-06, and birthday is 2000-01-15
        dob = date(2000, 1, 15)
        age = get_age_from_dob(dob)
        assert age == 24  # Already turned 24


class TestConvertToWords:
    """Test number to words conversion."""

    def test_zero(self):
        """Test converting zero."""
        assert convert_to_words(0) == 'Zero'

    def test_single_digit(self):
        """Test single digit numbers."""
        assert convert_to_words(1) == 'One'
        assert convert_to_words(5) == 'Five'
        assert convert_to_words(9) == 'Nine'

    def test_tens(self):
        """Test tens."""
        assert convert_to_words(10) == 'Ten'
        assert convert_to_words(15) == 'Fifteen'
        assert convert_to_words(20) == 'Twenty'
        assert convert_to_words(99) == 'Ninety Nine'

    def test_hundreds(self):
        """Test hundreds."""
        assert convert_to_words(100) == 'One Hundred'
        assert convert_to_words(250) == 'Two Hundred Fifty'
        assert convert_to_words(999) == 'Nine Hundred Ninety Nine'

    def test_thousands(self):
        """Test thousands."""
        assert convert_to_words(1000) == 'One Thousand'
        assert convert_to_words(5500) == 'Five Thousand Five Hundred'

    def test_lakhs(self):
        """Test lakhs (Indian numbering)."""
        assert convert_to_words(100000) == 'One Lakh'
        assert convert_to_words(550000) == 'Five Lakh Fifty Thousand'

    def test_crores(self):
        """Test crores (Indian numbering)."""
        assert convert_to_words(10000000) == 'One Crore'
        assert convert_to_words(25000000) == 'Two Crore Fifty Lakh'

    def test_complex_number(self):
        """Test complex number."""
        result = convert_to_words(12345678)
        assert 'Crore' in result
        assert 'Lakh' in result
