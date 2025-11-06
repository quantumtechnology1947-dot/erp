"""
Admin configuration for sysconfig app.
"""

from django.contrib import admin
from .models import Company, FinancialYear, Country, State, City


@admin.register(Company)
class CompanyAdmin(admin.ModelAdmin):
    """Admin interface for Company model."""
    list_display = ['name', 'code', 'gst_number', 'city', 'is_active', 'created_at']
    list_filter = ['is_active', 'city__state__country', 'created_at']
    search_fields = ['name', 'code', 'gst_number', 'pan_number', 'email']
    readonly_fields = ['created_at', 'updated_at', 'created_by', 'updated_by']
    fieldsets = (
        ('Basic Information', {
            'fields': ('name', 'code', 'is_active', 'logo')
        }),
        ('Contact Information', {
            'fields': ('address', 'city', 'pincode', 'phone', 'email', 'website')
        }),
        ('Tax Information', {
            'fields': ('gst_number', 'pan_number', 'tan_number', 'cin_number')
        }),
        ('Business Details', {
            'fields': ('established_date', 'industry')
        }),
        ('Audit Information', {
            'fields': ('created_at', 'updated_at', 'created_by', 'updated_by'),
            'classes': ('collapse',)
        }),
    )


@admin.register(FinancialYear)
class FinancialYearAdmin(admin.ModelAdmin):
    """Admin interface for FinancialYear model."""
    list_display = ['year', 'company', 'start_date', 'end_date', 'is_active', 'is_locked']
    list_filter = ['is_active', 'is_locked', 'company', 'start_date']
    search_fields = ['year', 'company__name']
    readonly_fields = ['created_at', 'updated_at', 'created_by', 'updated_by']
    fieldsets = (
        ('Basic Information', {
            'fields': ('company', 'year', 'start_date', 'end_date')
        }),
        ('Status', {
            'fields': ('is_active', 'is_locked')
        }),
        ('Audit Information', {
            'fields': ('created_at', 'updated_at', 'created_by', 'updated_by'),
            'classes': ('collapse',)
        }),
    )


@admin.register(Country)
class CountryAdmin(admin.ModelAdmin):
    """Admin interface for Country model."""
    list_display = ['name', 'code', 'phone_code', 'currency_code', 'is_active']
    list_filter = ['is_active']
    search_fields = ['name', 'code']


@admin.register(State)
class StateAdmin(admin.ModelAdmin):
    """Admin interface for State model."""
    list_display = ['name', 'code', 'country', 'gst_state_code', 'is_active']
    list_filter = ['is_active', 'country']
    search_fields = ['name', 'code', 'gst_state_code']


@admin.register(City)
class CityAdmin(admin.ModelAdmin):
    """Admin interface for City model."""
    list_display = ['name', 'state', 'pincode', 'is_active']
    list_filter = ['is_active', 'state__country', 'state']
    search_fields = ['name', 'pincode', 'state__name']
