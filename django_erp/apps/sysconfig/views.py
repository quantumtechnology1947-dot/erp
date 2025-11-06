"""
Views for sysconfig app.
Using Django Class-Based Views for CRUD operations.
"""

from django.views.generic import ListView, DetailView, CreateView, UpdateView, DeleteView
from django.contrib.auth.mixins import LoginRequiredMixin, PermissionRequiredMixin
from django.urls import reverse_lazy
from django.contrib import messages

from apps.core.mixins import (
    AuditMixin,
    SuccessMessageMixin,
    HTMXMixin,
    SoftDeleteMixin
)
from .models import Company, FinancialYear, Country, State, City
from .forms import CompanyForm, FinancialYearForm, CountryForm, StateForm, CityForm


# ==================== Company Views ====================

class CompanyListView(LoginRequiredMixin, PermissionRequiredMixin, HTMXMixin, ListView):
    """List all companies."""
    model = Company
    template_name = 'sysconfig/company_list.html'
    htmx_template_name = 'sysconfig/partials/company_table.html'
    context_object_name = 'companies'
    permission_required = 'sysconfig.view_company'
    paginate_by = 25

    def get_queryset(self):
        """Filter companies with search."""
        queryset = super().get_queryset().filter(is_deleted=False).select_related('city__state__country')
        search = self.request.GET.get('search')
        if search:
            queryset = queryset.filter(name__icontains=search) | queryset.filter(code__icontains=search)
        return queryset.order_by('-created_at')


class CompanyDetailView(LoginRequiredMixin, PermissionRequiredMixin, DetailView):
    """View company details."""
    model = Company
    template_name = 'sysconfig/company_detail.html'
    context_object_name = 'company'
    permission_required = 'sysconfig.view_company'

    def get_queryset(self):
        return super().get_queryset().select_related('city__state__country')


class CompanyCreateView(LoginRequiredMixin, PermissionRequiredMixin, AuditMixin, SuccessMessageMixin, CreateView):
    """Create new company."""
    model = Company
    form_class = CompanyForm
    template_name = 'sysconfig/company_form.html'
    permission_required = 'sysconfig.add_company'
    success_url = reverse_lazy('sysconfig:company-list')
    success_message = '%(name)s has been created successfully.'


class CompanyUpdateView(LoginRequiredMixin, PermissionRequiredMixin, AuditMixin, SuccessMessageMixin, UpdateView):
    """Update existing company."""
    model = Company
    form_class = CompanyForm
    template_name = 'sysconfig/company_form.html'
    permission_required = 'sysconfig.change_company'
    success_url = reverse_lazy('sysconfig:company-list')
    success_message = '%(name)s has been updated successfully.'


class CompanyDeleteView(LoginRequiredMixin, PermissionRequiredMixin, SoftDeleteMixin, DeleteView):
    """Delete (soft delete) company."""
    model = Company
    template_name = 'sysconfig/company_confirm_delete.html'
    permission_required = 'sysconfig.delete_company'
    success_url = reverse_lazy('sysconfig:company-list')


# ==================== Financial Year Views ====================

class FinancialYearListView(LoginRequiredMixin, PermissionRequiredMixin, HTMXMixin, ListView):
    """List all financial years."""
    model = FinancialYear
    template_name = 'sysconfig/financialyear_list.html'
    htmx_template_name = 'sysconfig/partials/financialyear_table.html'
    context_object_name = 'financial_years'
    permission_required = 'sysconfig.view_financialyear'
    paginate_by = 25

    def get_queryset(self):
        """Filter with search and company."""
        queryset = super().get_queryset().filter(is_deleted=False).select_related('company')

        search = self.request.GET.get('search')
        if search:
            queryset = queryset.filter(year__icontains=search)

        company_id = self.request.GET.get('company')
        if company_id:
            queryset = queryset.filter(company_id=company_id)

        return queryset.order_by('-start_date')


class FinancialYearDetailView(LoginRequiredMixin, PermissionRequiredMixin, DetailView):
    """View financial year details."""
    model = FinancialYear
    template_name = 'sysconfig/financialyear_detail.html'
    context_object_name = 'financial_year'
    permission_required = 'sysconfig.view_financialyear'


class FinancialYearCreateView(LoginRequiredMixin, PermissionRequiredMixin, AuditMixin, SuccessMessageMixin, CreateView):
    """Create new financial year."""
    model = FinancialYear
    form_class = FinancialYearForm
    template_name = 'sysconfig/financialyear_form.html'
    permission_required = 'sysconfig.add_financialyear'
    success_url = reverse_lazy('sysconfig:financialyear-list')
    success_message = 'Financial Year %(year)s has been created successfully.'


class FinancialYearUpdateView(LoginRequiredMixin, PermissionRequiredMixin, AuditMixin, SuccessMessageMixin, UpdateView):
    """Update existing financial year."""
    model = FinancialYear
    form_class = FinancialYearForm
    template_name = 'sysconfig/financialyear_form.html'
    permission_required = 'sysconfig.change_financialyear'
    success_url = reverse_lazy('sysconfig:financialyear-list')
    success_message = 'Financial Year %(year)s has been updated successfully.'


class FinancialYearDeleteView(LoginRequiredMixin, PermissionRequiredMixin, SoftDeleteMixin, DeleteView):
    """Delete (soft delete) financial year."""
    model = FinancialYear
    template_name = 'sysconfig/financialyear_confirm_delete.html'
    permission_required = 'sysconfig.delete_financialyear'
    success_url = reverse_lazy('sysconfig:financialyear-list')


# ==================== Country Views ====================

class CountryListView(LoginRequiredMixin, PermissionRequiredMixin, HTMXMixin, ListView):
    """List all countries."""
    model = Country
    template_name = 'sysconfig/country_list.html'
    htmx_template_name = 'sysconfig/partials/country_table.html'
    context_object_name = 'countries'
    permission_required = 'sysconfig.view_country'
    paginate_by = 25


class CountryCreateView(LoginRequiredMixin, PermissionRequiredMixin, SuccessMessageMixin, CreateView):
    """Create new country."""
    model = Country
    form_class = CountryForm
    template_name = 'sysconfig/country_form.html'
    permission_required = 'sysconfig.add_country'
    success_url = reverse_lazy('sysconfig:country-list')
    success_message = '%(name)s has been created successfully.'


class CountryUpdateView(LoginRequiredMixin, PermissionRequiredMixin, SuccessMessageMixin, UpdateView):
    """Update existing country."""
    model = Country
    form_class = CountryForm
    template_name = 'sysconfig/country_form.html'
    permission_required = 'sysconfig.change_country'
    success_url = reverse_lazy('sysconfig:country-list')
    success_message = '%(name)s has been updated successfully.'


# ==================== State Views ====================

class StateListView(LoginRequiredMixin, PermissionRequiredMixin, HTMXMixin, ListView):
    """List all states."""
    model = State
    template_name = 'sysconfig/state_list.html'
    htmx_template_name = 'sysconfig/partials/state_table.html'
    context_object_name = 'states'
    permission_required = 'sysconfig.view_state'
    paginate_by = 25

    def get_queryset(self):
        """Filter by country if provided."""
        queryset = super().get_queryset().select_related('country')

        country_id = self.request.GET.get('country')
        if country_id:
            queryset = queryset.filter(country_id=country_id)

        return queryset.order_by('name')


class StateCreateView(LoginRequiredMixin, PermissionRequiredMixin, SuccessMessageMixin, CreateView):
    """Create new state."""
    model = State
    form_class = StateForm
    template_name = 'sysconfig/state_form.html'
    permission_required = 'sysconfig.add_state'
    success_url = reverse_lazy('sysconfig:state-list')
    success_message = '%(name)s has been created successfully.'


class StateUpdateView(LoginRequiredMixin, PermissionRequiredMixin, SuccessMessageMixin, UpdateView):
    """Update existing state."""
    model = State
    form_class = StateForm
    template_name = 'sysconfig/state_form.html'
    permission_required = 'sysconfig.change_state'
    success_url = reverse_lazy('sysconfig:state-list')
    success_message = '%(name)s has been updated successfully.'


# ==================== City Views ====================

class CityListView(LoginRequiredMixin, PermissionRequiredMixin, HTMXMixin, ListView):
    """List all cities."""
    model = City
    template_name = 'sysconfig/city_list.html'
    htmx_template_name = 'sysconfig/partials/city_table.html'
    context_object_name = 'cities'
    permission_required = 'sysconfig.view_city'
    paginate_by = 25

    def get_queryset(self):
        """Filter by state if provided."""
        queryset = super().get_queryset().select_related('state__country')

        state_id = self.request.GET.get('state')
        if state_id:
            queryset = queryset.filter(state_id=state_id)

        search = self.request.GET.get('search')
        if search:
            queryset = queryset.filter(name__icontains=search)

        return queryset.order_by('name')


class CityCreateView(LoginRequiredMixin, PermissionRequiredMixin, SuccessMessageMixin, CreateView):
    """Create new city."""
    model = City
    form_class = CityForm
    template_name = 'sysconfig/city_form.html'
    permission_required = 'sysconfig.add_city'
    success_url = reverse_lazy('sysconfig:city-list')
    success_message = '%(name)s has been created successfully.'


class CityUpdateView(LoginRequiredMixin, PermissionRequiredMixin, SuccessMessageMixin, UpdateView):
    """Update existing city."""
    model = City
    form_class = CityForm
    template_name = 'sysconfig/city_form.html'
    permission_required = 'sysconfig.change_city'
    success_url = reverse_lazy('sysconfig:city-list')
    success_message = '%(name)s has been updated successfully.'
