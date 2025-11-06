"""
System Configuration models.
Company, Financial Year, and Location management.
"""

from django.db import models
from django.core.validators import MinValueValidator, MaxValueValidator
from django.urls import reverse
from apps.core.models import TimeStampedModel, SoftDeleteModel, AuditMixin
from apps.core.validators import validate_gstin, validate_pan, validate_phone_number, validate_pincode


class Company(TimeStampedModel, SoftDeleteModel, AuditMixin):
    """
    Company master for multi-company support.
    All other modules reference this for company scoping.
    """
    name = models.CharField(
        max_length=200,
        unique=True,
        help_text='Company legal name'
    )
    code = models.CharField(
        max_length=20,
        unique=True,
        help_text='Company code (for internal reference)'
    )

    # Contact Information
    address = models.TextField(
        help_text='Registered office address'
    )
    city = models.ForeignKey(
        'City',
        on_delete=models.PROTECT,
        related_name='companies',
        help_text='City where company is registered'
    )
    pincode = models.CharField(
        max_length=10,
        validators=[validate_pincode],
        help_text='Postal pincode'
    )
    phone = models.CharField(
        max_length=20,
        validators=[validate_phone_number],
        help_text='Primary contact phone'
    )
    email = models.EmailField(
        help_text='Primary contact email'
    )
    website = models.URLField(
        blank=True,
        help_text='Company website'
    )

    # Tax Information
    gst_number = models.CharField(
        max_length=15,
        unique=True,
        validators=[validate_gstin],
        help_text='GST registration number'
    )
    pan_number = models.CharField(
        max_length=10,
        unique=True,
        validators=[validate_pan],
        help_text='PAN number'
    )
    tan_number = models.CharField(
        max_length=10,
        blank=True,
        help_text='TAN number (for TDS)'
    )
    cin_number = models.CharField(
        max_length=21,
        blank=True,
        help_text='Corporate Identification Number'
    )

    # Business Details
    established_date = models.DateField(
        null=True,
        blank=True,
        help_text='Date of establishment'
    )
    industry = models.CharField(
        max_length=100,
        blank=True,
        help_text='Industry/sector'
    )

    # Logo and Branding
    logo = models.ImageField(
        upload_to='company_logos/',
        blank=True,
        null=True,
        help_text='Company logo'
    )

    # Status
    is_active = models.BooleanField(
        default=True,
        help_text='Whether company is active'
    )

    class Meta:
        db_table = 'sysconfig_company'
        verbose_name = 'Company'
        verbose_name_plural = 'Companies'
        ordering = ['name']

    def __str__(self):
        return f"{self.name} ({self.code})"

    def get_absolute_url(self):
        return reverse('sysconfig:company-detail', kwargs={'pk': self.pk})


class FinancialYear(TimeStampedModel, SoftDeleteModel, AuditMixin):
    """
    Financial Year master.
    Typically runs from April 1 to March 31 in India.
    """
    company = models.ForeignKey(
        Company,
        on_delete=models.CASCADE,
        related_name='financial_years',
        help_text='Company this financial year belongs to'
    )
    year = models.CharField(
        max_length=9,
        help_text='Financial year (e.g., 2024-2025)'
    )
    start_date = models.DateField(
        help_text='Start date of financial year'
    )
    end_date = models.DateField(
        help_text='End date of financial year'
    )
    is_active = models.BooleanField(
        default=False,
        help_text='Whether this is the active financial year'
    )
    is_locked = models.BooleanField(
        default=False,
        help_text='Whether transactions are locked for this year'
    )

    class Meta:
        db_table = 'sysconfig_financialyear'
        verbose_name = 'Financial Year'
        verbose_name_plural = 'Financial Years'
        unique_together = ['company', 'year']
        ordering = ['-start_date']

    def __str__(self):
        return f"{self.company.code} - {self.year}"

    def get_absolute_url(self):
        return reverse('sysconfig:financialyear-detail', kwargs={'pk': self.pk})

    def save(self, *args, **kwargs):
        """Ensure only one active financial year per company."""
        if self.is_active:
            # Deactivate other financial years for this company
            FinancialYear.objects.filter(
                company=self.company,
                is_active=True
            ).exclude(pk=self.pk).update(is_active=False)
        super().save(*args, **kwargs)


class Country(TimeStampedModel):
    """
    Country master for location hierarchy.
    """
    name = models.CharField(
        max_length=100,
        unique=True,
        help_text='Country name'
    )
    code = models.CharField(
        max_length=3,
        unique=True,
        help_text='ISO 3166-1 alpha-3 country code'
    )
    phone_code = models.CharField(
        max_length=10,
        blank=True,
        help_text='International dialing code (e.g., +91)'
    )
    currency_code = models.CharField(
        max_length=3,
        default='INR',
        help_text='ISO 4217 currency code'
    )
    currency_symbol = models.CharField(
        max_length=5,
        default='₹',
        help_text='Currency symbol'
    )
    is_active = models.BooleanField(
        default=True,
        help_text='Whether country is active'
    )

    class Meta:
        db_table = 'sysconfig_country'
        verbose_name = 'Country'
        verbose_name_plural = 'Countries'
        ordering = ['name']

    def __str__(self):
        return self.name

    def get_absolute_url(self):
        return reverse('sysconfig:country-detail', kwargs={'pk': self.pk})


class State(TimeStampedModel):
    """
    State/Province master for location hierarchy.
    """
    country = models.ForeignKey(
        Country,
        on_delete=models.CASCADE,
        related_name='states',
        help_text='Country this state belongs to'
    )
    name = models.CharField(
        max_length=100,
        help_text='State/Province name'
    )
    code = models.CharField(
        max_length=10,
        help_text='State code'
    )
    gst_state_code = models.CharField(
        max_length=2,
        blank=True,
        help_text='GST state code (for India)'
    )
    is_active = models.BooleanField(
        default=True,
        help_text='Whether state is active'
    )

    class Meta:
        db_table = 'sysconfig_state'
        verbose_name = 'State'
        verbose_name_plural = 'States'
        unique_together = ['country', 'code']
        ordering = ['name']

    def __str__(self):
        return f"{self.name}, {self.country.code}"

    def get_absolute_url(self):
        return reverse('sysconfig:state-detail', kwargs={'pk': self.pk})


class City(TimeStampedModel):
    """
    City master for location hierarchy.
    """
    state = models.ForeignKey(
        State,
        on_delete=models.CASCADE,
        related_name='cities',
        help_text='State this city belongs to'
    )
    name = models.CharField(
        max_length=100,
        help_text='City name'
    )
    pincode = models.CharField(
        max_length=10,
        blank=True,
        validators=[validate_pincode],
        help_text='Primary pincode for the city'
    )
    is_active = models.BooleanField(
        default=True,
        help_text='Whether city is active'
    )

    class Meta:
        db_table = 'sysconfig_city'
        verbose_name = 'City'
        verbose_name_plural = 'Cities'
        unique_together = ['state', 'name']
        ordering = ['name']

    def __str__(self):
        return f"{self.name}, {self.state.name}"

    def get_absolute_url(self):
        return reverse('sysconfig:city-detail', kwargs={'pk': self.pk})

    @property
    def full_location(self):
        """Get full location string: City, State, Country."""
        return f"{self.name}, {self.state.name}, {self.state.country.name}"
