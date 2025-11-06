"""
URL configuration for sysconfig app.
"""

from django.urls import path
from . import views

app_name = 'sysconfig'

urlpatterns = [
    # Company URLs
    path('companies/', views.CompanyListView.as_view(), name='company-list'),
    path('companies/create/', views.CompanyCreateView.as_view(), name='company-create'),
    path('companies/<int:pk>/', views.CompanyDetailView.as_view(), name='company-detail'),
    path('companies/<int:pk>/edit/', views.CompanyUpdateView.as_view(), name='company-update'),
    path('companies/<int:pk>/delete/', views.CompanyDeleteView.as_view(), name='company-delete'),

    # Financial Year URLs
    path('financial-years/', views.FinancialYearListView.as_view(), name='financialyear-list'),
    path('financial-years/create/', views.FinancialYearCreateView.as_view(), name='financialyear-create'),
    path('financial-years/<int:pk>/', views.FinancialYearDetailView.as_view(), name='financialyear-detail'),
    path('financial-years/<int:pk>/edit/', views.FinancialYearUpdateView.as_view(), name='financialyear-update'),
    path('financial-years/<int:pk>/delete/', views.FinancialYearDeleteView.as_view(), name='financialyear-delete'),

    # Country URLs
    path('countries/', views.CountryListView.as_view(), name='country-list'),
    path('countries/create/', views.CountryCreateView.as_view(), name='country-create'),
    path('countries/<int:pk>/edit/', views.CountryUpdateView.as_view(), name='country-update'),

    # State URLs
    path('states/', views.StateListView.as_view(), name='state-list'),
    path('states/create/', views.StateCreateView.as_view(), name='state-create'),
    path('states/<int:pk>/edit/', views.StateUpdateView.as_view(), name='state-update'),

    # City URLs
    path('cities/', views.CityListView.as_view(), name='city-list'),
    path('cities/create/', views.CityCreateView.as_view(), name='city-create'),
    path('cities/<int:pk>/edit/', views.CityUpdateView.as_view(), name='city-update'),
]
