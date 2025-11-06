"""
Tests for sysconfig models.
"""

import pytest
from datetime import date, timedelta
from django.core.exceptions import ValidationError
from django.db import IntegrityError
from apps.sysconfig.models import Country, State, City, Company, FinancialYear
from apps.core.models import User


@pytest.mark.django_db
class TestCountryModel:
    """Tests for Country model."""

    def test_create_country(self):
        """Test creating a country."""
        country = Country.objects.create(
            name='India',
            code='IND',
            phone_code='+91',
            currency_code='INR',
            currency_symbol='₹'
        )
        assert country.name == 'India'
        assert country.code == 'IND'
        assert str(country) == 'India'

    def test_country_unique_name(self):
        """Test that country name must be unique."""
        Country.objects.create(name='India', code='IND')
        with pytest.raises(IntegrityError):
            Country.objects.create(name='India', code='IN2')

    def test_country_unique_code(self):
        """Test that country code must be unique."""
        Country.objects.create(name='India', code='IND')
        with pytest.raises(IntegrityError):
            Country.objects.create(name='India2', code='IND')


@pytest.mark.django_db
class TestStateModel:
    """Tests for State model."""

    @pytest.fixture
    def country(self):
        """Create a test country."""
        return Country.objects.create(
            name='India',
            code='IND',
            currency_code='INR',
            currency_symbol='₹'
        )

    def test_create_state(self, country):
        """Test creating a state."""
        state = State.objects.create(
            country=country,
            name='Maharashtra',
            code='MH',
            gst_state_code='27'
        )
        assert state.name == 'Maharashtra'
        assert state.country == country
        assert str(state) == 'Maharashtra, IND'

    def test_state_unique_together(self, country):
        """Test that country+code combination must be unique."""
        State.objects.create(country=country, name='Maharashtra', code='MH')
        with pytest.raises(IntegrityError):
            State.objects.create(country=country, name='Maharashtra2', code='MH')


@pytest.mark.django_db
class TestCityModel:
    """Tests for City model."""

    @pytest.fixture
    def setup_location(self):
        """Create country and state for testing."""
        country = Country.objects.create(name='India', code='IND')
        state = State.objects.create(country=country, name='Maharashtra', code='MH')
        return {'country': country, 'state': state}

    def test_create_city(self, setup_location):
        """Test creating a city."""
        city = City.objects.create(
            state=setup_location['state'],
            name='Mumbai',
            pincode='400001'
        )
        assert city.name == 'Mumbai'
        assert city.state == setup_location['state']
        assert str(city) == 'Mumbai, Maharashtra'

    def test_city_full_location(self, setup_location):
        """Test full_location property."""
        city = City.objects.create(
            state=setup_location['state'],
            name='Mumbai',
            pincode='400001'
        )
        assert city.full_location == 'Mumbai, Maharashtra, India'

    def test_city_unique_together(self, setup_location):
        """Test that state+name combination must be unique."""
        City.objects.create(state=setup_location['state'], name='Mumbai')
        with pytest.raises(IntegrityError):
            City.objects.create(state=setup_location['state'], name='Mumbai')


@pytest.mark.django_db
class TestCompanyModel:
    """Tests for Company model."""

    @pytest.fixture
    def setup_location_and_user(self):
        """Create location hierarchy and user for testing."""
        country = Country.objects.create(name='India', code='IND')
        state = State.objects.create(country=country, name='Maharashtra', code='MH')
        city = City.objects.create(state=state, name='Mumbai', pincode='400001')
        user = User.objects.create_user(username='testuser', password='testpass123')
        return {'city': city, 'user': user}

    def test_create_company(self, setup_location_and_user):
        """Test creating a company."""
        company = Company.objects.create(
            name='Test Company Pvt Ltd',
            code='TC001',
            address='123 Test Street',
            city=setup_location_and_user['city'],
            pincode='400001',
            phone='+91-9876543210',
            email='test@example.com',
            gst_number='27AAAAA0000A1Z5',
            pan_number='AAAAA0000A',
            created_by=setup_location_and_user['user']
        )
        assert company.name == 'Test Company Pvt Ltd'
        assert company.code == 'TC001'
        assert company.is_active is True
        assert company.is_deleted is False

    def test_company_unique_name(self, setup_location_and_user):
        """Test that company name must be unique."""
        Company.objects.create(
            name='Test Company',
            code='TC001',
            address='123 Test Street',
            city=setup_location_and_user['city'],
            pincode='400001',
            phone='+91-9876543210',
            email='test@example.com',
            gst_number='27AAAAA0000A1Z5',
            pan_number='AAAAA0000A'
        )
        with pytest.raises(IntegrityError):
            Company.objects.create(
                name='Test Company',
                code='TC002',
                address='123 Test Street',
                city=setup_location_and_user['city'],
                pincode='400001',
                phone='+91-9876543210',
                email='test2@example.com',
                gst_number='27AAAAA0000A1Z6',
                pan_number='AAAAA0000B'
            )

    def test_company_soft_delete(self, setup_location_and_user):
        """Test soft deletion of company."""
        company = Company.objects.create(
            name='Test Company',
            code='TC001',
            address='123 Test Street',
            city=setup_location_and_user['city'],
            pincode='400001',
            phone='+91-9876543210',
            email='test@example.com',
            gst_number='27AAAAA0000A1Z5',
            pan_number='AAAAA0000A'
        )
        company.soft_delete(user=setup_location_and_user['user'])
        assert company.is_deleted is True
        assert company.deleted_at is not None
        assert company.deleted_by == setup_location_and_user['user']

    def test_company_restore(self, setup_location_and_user):
        """Test restoring a soft-deleted company."""
        company = Company.objects.create(
            name='Test Company',
            code='TC001',
            address='123 Test Street',
            city=setup_location_and_user['city'],
            pincode='400001',
            phone='+91-9876543210',
            email='test@example.com',
            gst_number='27AAAAA0000A1Z5',
            pan_number='AAAAA0000A'
        )
        company.soft_delete()
        company.restore()
        assert company.is_deleted is False
        assert company.deleted_at is None
        assert company.deleted_by is None


@pytest.mark.django_db
class TestFinancialYearModel:
    """Tests for FinancialYear model."""

    @pytest.fixture
    def setup_company(self):
        """Create company for testing."""
        country = Country.objects.create(name='India', code='IND')
        state = State.objects.create(country=country, name='Maharashtra', code='MH')
        city = City.objects.create(state=state, name='Mumbai', pincode='400001')
        company = Company.objects.create(
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
        return company

    def test_create_financial_year(self, setup_company):
        """Test creating a financial year."""
        fy = FinancialYear.objects.create(
            company=setup_company,
            year='2024-2025',
            start_date=date(2024, 4, 1),
            end_date=date(2025, 3, 31),
            is_active=True
        )
        assert fy.year == '2024-2025'
        assert fy.is_active is True
        assert str(fy) == 'TC001 - 2024-2025'

    def test_financial_year_unique_together(self, setup_company):
        """Test that company+year combination must be unique."""
        FinancialYear.objects.create(
            company=setup_company,
            year='2024-2025',
            start_date=date(2024, 4, 1),
            end_date=date(2025, 3, 31)
        )
        with pytest.raises(IntegrityError):
            FinancialYear.objects.create(
                company=setup_company,
                year='2024-2025',
                start_date=date(2024, 4, 1),
                end_date=date(2025, 3, 31)
            )

    def test_only_one_active_fy_per_company(self, setup_company):
        """Test that only one FY can be active per company."""
        fy1 = FinancialYear.objects.create(
            company=setup_company,
            year='2023-2024',
            start_date=date(2023, 4, 1),
            end_date=date(2024, 3, 31),
            is_active=True
        )
        fy2 = FinancialYear.objects.create(
            company=setup_company,
            year='2024-2025',
            start_date=date(2024, 4, 1),
            end_date=date(2025, 3, 31),
            is_active=True
        )
        # Refresh fy1 from database
        fy1.refresh_from_db()
        # fy1 should now be inactive
        assert fy1.is_active is False
        assert fy2.is_active is True
