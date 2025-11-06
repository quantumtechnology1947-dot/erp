"""
Utility functions for the ERP system.
"""

import random
import string
from datetime import datetime, timedelta
from decimal import Decimal
from django.utils.text import slugify


def generate_unique_code(prefix='', length=8):
    """
    Generate a unique alphanumeric code.

    Args:
        prefix: String prefix for the code
        length: Length of the random part

    Returns:
        Unique code string
    """
    random_part = ''.join(random.choices(string.ascii_uppercase + string.digits, k=length))
    return f"{prefix}{random_part}" if prefix else random_part


def generate_sequential_code(model, field_name, prefix='', start=1, padding=5):
    """
    Generate sequential code for a model.

    Args:
        model: Django model class
        field_name: Name of the field containing the code
        prefix: String prefix for the code
        start: Starting number
        padding: Zero padding length

    Returns:
        Next sequential code

    Example:
        generate_sequential_code(Customer, 'customer_id', 'CUST', 1, 5)
        Returns: 'CUST00001', 'CUST00002', etc.
    """
    # Get the last object
    last_object = model.objects.order_by('-id').first()

    if last_object:
        last_code = getattr(last_object, field_name)
        # Extract number from code
        if prefix:
            number_part = last_code.replace(prefix, '')
        else:
            number_part = last_code

        try:
            last_number = int(number_part)
            next_number = last_number + 1
        except ValueError:
            next_number = start
    else:
        next_number = start

    # Format with padding
    return f"{prefix}{str(next_number).zfill(padding)}"


def format_currency(amount, currency='₹'):
    """
    Format amount as currency.

    Args:
        amount: Decimal or float amount
        currency: Currency symbol

    Returns:
        Formatted currency string
    """
    if amount is None:
        return f"{currency} 0.00"

    amount = Decimal(str(amount))
    return f"{currency} {amount:,.2f}"


def calculate_gst(amount, gst_rate=18):
    """
    Calculate GST amount.

    Args:
        amount: Base amount
        gst_rate: GST percentage (default 18%)

    Returns:
        Dictionary with GST breakdown
    """
    amount = Decimal(str(amount))
    gst_rate = Decimal(str(gst_rate))

    gst_amount = (amount * gst_rate) / 100
    sgst = gst_amount / 2
    cgst = gst_amount / 2
    total = amount + gst_amount

    return {
        'base_amount': amount,
        'gst_rate': gst_rate,
        'sgst': sgst.quantize(Decimal('0.01')),
        'cgst': cgst.quantize(Decimal('0.01')),
        'gst_amount': gst_amount.quantize(Decimal('0.01')),
        'total_amount': total.quantize(Decimal('0.01')),
    }


def get_financial_year(date=None):
    """
    Get financial year for a given date.
    Financial year in India: April 1 to March 31

    Args:
        date: Date object (default: today)

    Returns:
        String representing financial year (e.g., '2024-2025')
    """
    if date is None:
        date = datetime.now().date()

    if date.month >= 4:
        # April onwards - current year to next year
        fy_start = date.year
        fy_end = date.year + 1
    else:
        # Jan to March - previous year to current year
        fy_start = date.year - 1
        fy_end = date.year

    return f"{fy_start}-{fy_end}"


def get_financial_year_dates(financial_year_str):
    """
    Get start and end dates for a financial year string.

    Args:
        financial_year_str: String like '2024-2025'

    Returns:
        Tuple of (start_date, end_date)
    """
    start_year = int(financial_year_str.split('-')[0])
    end_year = int(financial_year_str.split('-')[1])

    start_date = datetime(start_year, 4, 1).date()
    end_date = datetime(end_year, 3, 31).date()

    return start_date, end_date


def validate_gstin(gstin):
    """
    Validate Indian GSTIN format.
    Format: 22AAAAA0000A1Z5
    - First 2 chars: State code (01-37)
    - Next 10 chars: PAN
    - 13th char: Entity number
    - 14th char: Z (default)
    - 15th char: Checksum

    Args:
        gstin: GSTIN string

    Returns:
        Boolean indicating validity
    """
    if not gstin or len(gstin) != 15:
        return False

    import re
    pattern = r'^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$'
    return bool(re.match(pattern, gstin.upper()))


def validate_pan(pan):
    """
    Validate Indian PAN format.
    Format: AAAAA9999A

    Args:
        pan: PAN string

    Returns:
        Boolean indicating validity
    """
    if not pan or len(pan) != 10:
        return False

    import re
    pattern = r'^[A-Z]{5}[0-9]{4}[A-Z]{1}$'
    return bool(re.match(pattern, pan.upper()))


def get_age_from_dob(date_of_birth):
    """
    Calculate age from date of birth.

    Args:
        date_of_birth: Date object

    Returns:
        Age in years
    """
    today = datetime.now().date()
    age = today.year - date_of_birth.year

    # Adjust if birthday hasn't occurred this year
    if today.month < date_of_birth.month or (
        today.month == date_of_birth.month and today.day < date_of_birth.day
    ):
        age -= 1

    return age


def generate_slug_unique(model, text, slug_field='slug'):
    """
    Generate a unique slug for a model.

    Args:
        model: Django model class
        text: Text to slugify
        slug_field: Name of the slug field

    Returns:
        Unique slug string
    """
    slug = slugify(text)
    unique_slug = slug
    num = 1

    while model.objects.filter(**{slug_field: unique_slug}).exists():
        unique_slug = f'{slug}-{num}'
        num += 1

    return unique_slug


def chunk_queryset(queryset, chunk_size=1000):
    """
    Split a queryset into chunks for batch processing.

    Args:
        queryset: Django queryset
        chunk_size: Number of objects per chunk

    Yields:
        Chunks of queryset
    """
    count = queryset.count()
    for start in range(0, count, chunk_size):
        end = min(start + chunk_size, count)
        yield queryset[start:end]


def get_client_ip(request):
    """
    Get client IP address from request.

    Args:
        request: Django request object

    Returns:
        IP address string
    """
    x_forwarded_for = request.META.get('HTTP_X_FORWARDED_FOR')
    if x_forwarded_for:
        ip = x_forwarded_for.split(',')[0]
    else:
        ip = request.META.get('REMOTE_ADDR')
    return ip


def convert_to_words(number):
    """
    Convert number to words (Indian numbering system).

    Args:
        number: Integer or Decimal

    Returns:
        String representation in words
    """
    ones = ['', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine']
    tens = ['', '', 'Twenty', 'Thirty', 'Forty', 'Fifty', 'Sixty', 'Seventy', 'Eighty', 'Ninety']
    teens = ['Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen',
             'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen']

    def convert_less_than_thousand(n):
        if n == 0:
            return ''
        elif n < 10:
            return ones[n]
        elif n < 20:
            return teens[n - 10]
        elif n < 100:
            return tens[n // 10] + (' ' + ones[n % 10] if n % 10 != 0 else '')
        else:
            return ones[n // 100] + ' Hundred' + (' ' + convert_less_than_thousand(n % 100) if n % 100 != 0 else '')

    if number == 0:
        return 'Zero'

    # Split into crores, lakhs, thousands, hundreds
    crores = number // 10000000
    lakhs = (number % 10000000) // 100000
    thousands = (number % 100000) // 1000
    remainder = number % 1000

    result = []

    if crores:
        result.append(convert_less_than_thousand(crores) + ' Crore')
    if lakhs:
        result.append(convert_less_than_thousand(lakhs) + ' Lakh')
    if thousands:
        result.append(convert_less_than_thousand(thousands) + ' Thousand')
    if remainder:
        result.append(convert_less_than_thousand(remainder))

    return ' '.join(result)
