"""
Forms for sysconfig app.
"""

from django import forms
from .models import Company, FinancialYear, Country, State, City


class CompanyForm(forms.ModelForm):
    """Form for creating/editing Company."""

    class Meta:
        model = Company
        fields = [
            'name', 'code', 'address', 'city', 'pincode',
            'phone', 'email', 'website', 'gst_number', 'pan_number',
            'tan_number', 'cin_number', 'established_date', 'industry',
            'logo', 'is_active'
        ]
        widgets = {
            'name': forms.TextInput(attrs={'class': 'form-input'}),
            'code': forms.TextInput(attrs={'class': 'form-input'}),
            'address': forms.Textarea(attrs={'class': 'form-input', 'rows': 3}),
            'city': forms.Select(attrs={'class': 'form-input'}),
            'pincode': forms.TextInput(attrs={'class': 'form-input'}),
            'phone': forms.TextInput(attrs={'class': 'form-input'}),
            'email': forms.EmailInput(attrs={'class': 'form-input'}),
            'website': forms.URLInput(attrs={'class': 'form-input'}),
            'gst_number': forms.TextInput(attrs={'class': 'form-input'}),
            'pan_number': forms.TextInput(attrs={'class': 'form-input'}),
            'tan_number': forms.TextInput(attrs={'class': 'form-input'}),
            'cin_number': forms.TextInput(attrs={'class': 'form-input'}),
            'established_date': forms.DateInput(attrs={'class': 'form-input', 'type': 'date'}),
            'industry': forms.TextInput(attrs={'class': 'form-input'}),
            'logo': forms.FileInput(attrs={'class': 'form-input'}),
        }


class FinancialYearForm(forms.ModelForm):
    """Form for creating/editing Financial Year."""

    class Meta:
        model = FinancialYear
        fields = ['company', 'year', 'start_date', 'end_date', 'is_active', 'is_locked']
        widgets = {
            'company': forms.Select(attrs={'class': 'form-input'}),
            'year': forms.TextInput(attrs={'class': 'form-input', 'placeholder': '2024-2025'}),
            'start_date': forms.DateInput(attrs={'class': 'form-input', 'type': 'date'}),
            'end_date': forms.DateInput(attrs={'class': 'form-input', 'type': 'date'}),
        }

    def clean(self):
        """Validate that start_date is before end_date."""
        cleaned_data = super().clean()
        start_date = cleaned_data.get('start_date')
        end_date = cleaned_data.get('end_date')

        if start_date and end_date and start_date >= end_date:
            raise forms.ValidationError('Start date must be before end date.')

        return cleaned_data


class CountryForm(forms.ModelForm):
    """Form for creating/editing Country."""

    class Meta:
        model = Country
        fields = ['name', 'code', 'phone_code', 'currency_code', 'currency_symbol', 'is_active']
        widgets = {
            'name': forms.TextInput(attrs={'class': 'form-input'}),
            'code': forms.TextInput(attrs={'class': 'form-input', 'placeholder': 'IND'}),
            'phone_code': forms.TextInput(attrs={'class': 'form-input', 'placeholder': '+91'}),
            'currency_code': forms.TextInput(attrs={'class': 'form-input', 'placeholder': 'INR'}),
            'currency_symbol': forms.TextInput(attrs={'class': 'form-input', 'placeholder': '₹'}),
        }


class StateForm(forms.ModelForm):
    """Form for creating/editing State."""

    class Meta:
        model = State
        fields = ['country', 'name', 'code', 'gst_state_code', 'is_active']
        widgets = {
            'country': forms.Select(attrs={'class': 'form-input'}),
            'name': forms.TextInput(attrs={'class': 'form-input'}),
            'code': forms.TextInput(attrs={'class': 'form-input'}),
            'gst_state_code': forms.TextInput(attrs={'class': 'form-input', 'placeholder': '27'}),
        }


class CityForm(forms.ModelForm):
    """Form for creating/editing City."""

    class Meta:
        model = City
        fields = ['state', 'name', 'pincode', 'is_active']
        widgets = {
            'state': forms.Select(attrs={'class': 'form-input'}),
            'name': forms.TextInput(attrs={'class': 'form-input'}),
            'pincode': forms.TextInput(attrs={'class': 'form-input'}),
        }
