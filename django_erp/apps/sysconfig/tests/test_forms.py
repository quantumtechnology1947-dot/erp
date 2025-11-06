"""
Tests for sysconfig forms.
"""

import pytest
from datetime import date
from apps.sysconfig.forms import (
    CompanyForm, FinancialYearForm, CountryForm, StateForm, CityForm
)
from apps.sysconfig.models import Country, State, City, Company


@pytest.mark.django_db
class TestCountryForm:
    """Tests for CountryForm."""

    def test_valid_country_form(self):
        """Test form with valid data."""
        form_data = {
            'name': 'India',
            'code': 'IND',
            'phone_code': '+91',
            'currency_code': 'INR',
            'currency_symbol': '₹',
            'is_active': True
        }
        form = CountryForm(data=form_data)
        assert form.is_valid()

    def test_country_form_missing_required_field(self):
        """Test form with missing required field."""
        form_data = {
            'name': 'India',
            # Missing 'code'
        }
        form = CountryForm(data=form_data)
        assert not form.is_valid()
        assert 'code' in form.errors


@pytest.mark.django_db
class TestStateForm:
    """Tests for StateForm."""

    @pytest.fixture
    def country(self):
        """Create a test country."""
        return Country.objects.create(name='India', code='IND')

    def test_valid_state_form(self, country):
        """Test form with valid data."""
        form_data = {
            'country': country.pk,
            'name': 'Maharashtra',
            'code': 'MH',
            'gst_state_code': '27',
            'is_active': True
        }
        form = StateForm(data=form_data)
        assert form.is_valid()


@pytest.mark.django_db
class TestCityForm:
    """Tests for CityForm."""

    @pytest.fixture
    def state(self):
        """Create a test state."""
        country = Country.objects.create(name='India', code='IND')
        return State.objects.create(country=country, name='Maharashtra', code='MH')

    def test_valid_city_form(self, state):
        """Test form with valid data."""
        form_data = {
            'state': state.pk,
            'name': 'Mumbai',
            'pincode': '400001',
            'is_active': True
        }
        form = CityForm(data=form_data)
        assert form.is_valid()


@pytest.mark.django_db
class TestCompanyForm:
    """Tests for CompanyForm."""

    @pytest.fixture
    def city(self):
        """Create a test city."""
        country = Country.objects.create(name='India', code='IND')
        state = State.objects.create(country=country, name='Maharashtra', code='MH')
        return City.objects.create(state=state, name='Mumbai', pincode='400001')

    def test_valid_company_form(self, city):
        """Test form with valid data."""
        form_data = {
            'name': 'Test Company Pvt Ltd',
            'code': 'TC001',
            'address': '123 Test Street',
            'city': city.pk,
            'pincode': '400001',
            'phone': '+91-9876543210',
            'email': 'test@example.com',
            'website': 'https://example.com',
            'gst_number': '27AAAAA0000A1Z5',
            'pan_number': 'AAAAA0000A',
            'tan_number': 'ABCD12345E',
            'is_active': True
        }
        form = CompanyForm(data=form_data)
        assert form.is_valid()

    def test_company_form_invalid_email(self, city):
        """Test form with invalid email."""
        form_data = {
            'name': 'Test Company',
            'code': 'TC001',
            'address': '123 Test Street',
            'city': city.pk,
            'pincode': '400001',
            'phone': '+91-9876543210',
            'email': 'invalid-email',
            'gst_number': '27AAAAA0000A1Z5',
            'pan_number': 'AAAAA0000A',
        }
        form = CompanyForm(data=form_data)
        assert not form.is_valid()
        assert 'email' in form.errors


@pytest.mark.django_db
class TestFinancialYearForm:
    """Tests for FinancialYearForm."""

    @pytest.fixture
    def company(self):
        """Create a test company."""
        country = Country.objects.create(name='India', code='IND')
        state = State.objects.create(country=country, name='Maharashtra', code='MH')
        city = City.objects.create(state=state, name='Mumbai', pincode='400001')
        return Company.objects.create(
            name='Test Company',
            code='TC001',
            address='123 Test Street',
            city=city,
            pincode='400001',
            phone='+91-9876543210',
            email='test@example.com',
            gst_number='27AAAAA0000A1Z5',
            pan_number='AAAAA0000A'
        )

    def test_valid_financial_year_form(self, company):
        """Test form with valid data."""
        form_data = {
            'company': company.pk,
            'year': '2024-2025',
            'start_date': date(2024, 4, 1),
            'end_date': date(2025, 3, 31),
            'is_active': True,
            'is_locked': False
        }
        form = FinancialYearForm(data=form_data)
        assert form.is_valid()

    def test_financial_year_form_end_before_start(self, company):
        """Test form validation: end_date must be after start_date."""
        form_data = {
            'company': company.pk,
            'year': '2024-2025',
            'start_date': date(2025, 3, 31),
            'end_date': date(2024, 4, 1),
            'is_active': True
        }
        form = FinancialYearForm(data=form_data)
        assert not form.is_valid()
        assert 'Start date must be before end date' in str(form.errors)
