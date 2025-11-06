# COMPREHENSIVE DJANGO MIGRATION PLAN
## ASP.NET ERP → Django + HTMX + Tailwind CSS + SAP S/4 HANA

**Generated:** 2025-11-06
**Source System:** ASP.NET 3.5 ERP (25 modules, 1,065 pages)
**Target Stack:** Django 5.x + HTMX + Tailwind CSS + SAP S/4 HANA
**Architecture:** Class-Based Views, Django Built-ins, Zero Redundancy

---

## EXECUTIVE SUMMARY

This document outlines the complete migration strategy for transforming a legacy ASP.NET 3.5 ERP system into a modern Django-based application. The migration will be executed in **dependency-aware phases** to ensure data integrity, functional parity, and comprehensive testing at each stage.

**Key Metrics:**
- **Source Modules:** 25 (excluding Admin - Django built-in)
- **Target Django Apps:** 24
- **Total ASPX Pages:** 1,065
- **Estimated Django Views:** ~500 (consolidated with CBVs)
- **Database Tables:** ~200+ (to be discovered)
- **Crystal Reports:** 164 (to be migrated to Django reports)

---

## TABLE OF CONTENTS

1. [Technology Stack](#technology-stack)
2. [Django Project Architecture](#django-project-architecture)
3. [Module-to-App Mapping](#module-to-app-mapping)
4. [Database Schema Strategy](#database-schema-strategy)
5. [Module Dependency Graph](#module-dependency-graph)
6. [Migration Phases](#migration-phases)
7. [Django Conventions & Best Practices](#django-conventions--best-practices)
8. [Testing Strategy](#testing-strategy)
9. [Implementation Roadmap](#implementation-roadmap)
10. [SAP S/4 HANA Integration](#sap-s4-hana-integration)

---

## TECHNOLOGY STACK

### Frontend
- **HTMX:** Dynamic interactions without JavaScript
- **Tailwind CSS:** Utility-first styling (NO custom CSS)
- **Alpine.js:** Minimal JavaScript (only when absolutely necessary)
- **Django Templates:** Server-side rendering

### Backend
- **Django 5.1:** Python web framework
- **Class-Based Views (CBVs):** Generic views for CRUD operations
- **Django REST Framework (DRF):** API endpoints for HTMX
- **Django ORM:** Database abstraction layer
- **Celery:** Background task processing
- **Redis:** Caching and session management

### Database
- **Primary:** SAP S/4 HANA (via SAP HANA Python Client)
- **Session/Cache:** Redis
- **Development:** SQLite (for initial testing)

### Infrastructure
- **Docker:** Containerization
- **Docker Compose:** Multi-container orchestration
- **Gunicorn:** WSGI server
- **Nginx:** Reverse proxy
- **GitHub Actions:** CI/CD pipeline

---

## DJANGO PROJECT ARCHITECTURE

### Project Structure
```
erp_project/
├── manage.py
├── erp_project/                    # Main project settings
│   ├── __init__.py
│   ├── settings/
│   │   ├── __init__.py
│   │   ├── base.py                 # Common settings
│   │   ├── development.py          # Dev environment
│   │   ├── production.py           # Production environment
│   │   └── testing.py              # Test environment
│   ├── urls.py                     # Root URL configuration
│   ├── wsgi.py
│   └── asgi.py
├── apps/                           # All Django apps
│   ├── core/                       # Shared utilities
│   │   ├── models.py               # Abstract base models
│   │   ├── mixins.py               # View mixins
│   │   ├── utils.py                # Helper functions
│   │   ├── validators.py           # Custom validators
│   │   └── middleware.py           # Custom middleware
│   ├── accounts/                   # Financial accounting
│   ├── inventory/                  # Stock management
│   ├── sales/                      # Sales & distribution
│   ├── procurement/                # Material management
│   ├── hr/                         # Human resources
│   ├── quality/                    # Quality control
│   ├── projects/                   # Project management
│   ├── design/                     # Design & BOM
│   ├── planning/                   # Material planning
│   ├── costing/                    # Material costing
│   ├── machinery/                  # Machinery maintenance
│   ├── mis/                        # Management reports
│   ├── assets/                     # Asset management
│   ├── reports/                    # Consolidated reports
│   ├── scheduler/                  # Event scheduling
│   ├── visitor/                    # Visitor management
│   ├── chatting/                   # Internal messaging
│   ├── appraisal/                  # Performance appraisal
│   ├── subcontracting/             # Sub-contracting
│   ├── daily_reporting/            # Daily reporting system
│   ├── mroffice/                   # MR Office
│   ├── sysconfig/                  # System configuration
│   └── support/                    # System support
├── templates/                      # Global templates
│   ├── base.html                   # Base template
│   ├── components/                 # Reusable HTMX components
│   ├── partials/                   # Template partials
│   └── layouts/                    # Page layouts
├── static/                         # Static files
│   ├── css/                        # Tailwind output
│   ├── js/                         # Minimal JS
│   └── images/                     # Static images
├── media/                          # User uploads
├── locale/                         # i18n translations
├── tests/                          # Integration tests
├── requirements/
│   ├── base.txt
│   ├── development.txt
│   ├── production.txt
│   └── testing.txt
├── docker/
│   ├── Dockerfile
│   ├── docker-compose.yml
│   └── nginx/
├── tailwind.config.js              # Tailwind configuration
├── package.json                    # Node.js dependencies
├── pytest.ini                      # Pytest configuration
└── README.md                       # Project documentation
```

### Each Django App Structure
```
apps/[app_name]/
├── __init__.py
├── models.py                       # Django models
├── views.py                        # Class-based views
├── urls.py                         # App URL patterns
├── forms.py                        # Django forms
├── admin.py                        # Django admin config
├── serializers.py                  # DRF serializers (if needed)
├── filters.py                      # Django-filter classes
├── signals.py                      # Django signals
├── managers.py                     # Custom model managers
├── querysets.py                    # Custom querysets
├── services.py                     # Business logic layer
├── templates/[app_name]/           # App-specific templates
│   ├── [model]_list.html
│   ├── [model]_detail.html
│   ├── [model]_form.html
│   └── partials/                   # HTMX partials
├── static/[app_name]/              # App-specific static files
├── migrations/                     # Database migrations
├── tests/                          # App tests
│   ├── __init__.py
│   ├── test_models.py
│   ├── test_views.py
│   ├── test_forms.py
│   └── test_services.py
└── management/                     # Custom management commands
    └── commands/
```

---

## MODULE-TO-APP MAPPING

### Mapping Table (24 Django Apps)

| # | ASP.NET Module | Django App Name | Priority | Pages | Key Models |
|---|----------------|-----------------|----------|-------|------------|
| 1 | SysAdmin | `sysconfig` | P0 | 9 | FinancialYear, Country, State, City |
| 2 | Accounts | `accounts` | P0 | 133 | Invoice, Voucher, BankAccount, AccountHead |
| 3 | Inventory | `inventory` | P1 | 149 | Item, Stock, Location, GRN, GIN, MRS, MIN |
| 4 | MaterialManagement | `procurement` | P1 | 120 | Supplier, PurchaseOrder, PurchaseRequisition, SPR |
| 5 | SalesDistribution | `sales` | P1 | 82 | Customer, WorkOrder, Quotation, Dispatch |
| 6 | HR | `hr` | P1 | 76 | Employee, Department, Designation, Payroll |
| 7 | Design | `design` | P2 | 74 | BOM, Item, ECN, BoughtOutItem |
| 8 | ProjectManagement | `projects` | P2 | 61 | Project, ManpowerPlan, VendorAssembly |
| 9 | QualityControl | `quality` | P2 | 30 | QualityNote, RejectionNote, Inspection |
| 10 | MIS | `mis` | P2 | 41 | Budget, FinancialReport, SalesAnalysis |
| 11 | Machinery | `machinery` | P3 | 39 | Machine, PreventiveMaintenance, Schedule |
| 12 | MaterialPlanning | `planning` | P2 | 15 | ProductionPlan, MaterialProcess |
| 13 | MaterialCosting | `costing` | P3 | 8 | MaterialCost, CostCategory |
| 14 | DailyReportingSystem | `daily_reporting` | P3 | 27 | DesignPlan, ManufacturingPlan, VendorPlan |
| 15 | ASSET | `assets` | P3 | 15 | AssetPO, AssetPR, AssetSupplier |
| 16 | Report | `reports` | P3 | 31 | ConsolidatedReports (views only) |
| 17 | Scheduler | `scheduler` | P4 | 5 | Event, Meeting, GatePass, IOU |
| 18 | Chatting | `chatting` | P4 | 2 | ChatRoom, Message |
| 19 | Visitor | `visitor` | P4 | 3 | VisitorGatePass, Visitor |
| 20 | Appriatiate | `appraisal` | P4 | 6 | Appraisal, AppraisalForm |
| 21 | SubContractingOut | `subcontracting` | P4 | 1 | SubcontractOrder |
| 22 | MROffice | `mroffice` | P4 | 3 | MaterialRequest |
| 23 | SysSupport | `support` | P4 | 10 | SystemCredentials, Configuration |
| 24 | ForgotPassword | `accounts` | P0 | 1 | (Integrated into accounts) |

**Note:** Admin module is handled by Django's built-in admin interface

---

## DATABASE SCHEMA STRATEGY

### Table Naming Convention (Django Standard)
```
ASP.NET: tblACC_BankVoucher_Received_Masters
Django:  accounts_bankvoucher
```

### Django Model Naming Patterns
- **Singular, PascalCase:** `BankVoucher` (not `BankVouchers`)
- **Clear relationships:** Use ForeignKey, ManyToMany with related_name
- **Abstract base models:** TimeStampedModel, SoftDeleteModel, CompanyScoped

### Core Abstract Models
```python
# apps/core/models.py

class TimeStampedModel(models.Model):
    """Auto-managed created/modified timestamps"""
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    class Meta:
        abstract = True

class SoftDeleteModel(models.Model):
    """Soft delete functionality"""
    is_deleted = models.BooleanField(default=False)
    deleted_at = models.DateTimeField(null=True, blank=True)
    deleted_by = models.ForeignKey(
        'auth.User',
        null=True,
        blank=True,
        on_delete=models.SET_NULL,
        related_name='%(class)s_deletions'
    )

    class Meta:
        abstract = True

class CompanyScopedModel(models.Model):
    """Multi-company support"""
    company = models.ForeignKey(
        'sysconfig.Company',
        on_delete=models.CASCADE,
        related_name='%(class)s_records'
    )

    class Meta:
        abstract = True

class AuditMixin(models.Model):
    """Full audit trail"""
    created_by = models.ForeignKey(
        'auth.User',
        on_delete=models.SET_NULL,
        null=True,
        related_name='%(class)s_created'
    )
    updated_by = models.ForeignKey(
        'auth.User',
        on_delete=models.SET_NULL,
        null=True,
        related_name='%(class)s_updated'
    )

    class Meta:
        abstract = True

class ApprovalWorkflowModel(models.Model):
    """Multi-level approval workflow"""
    STATUS_CHOICES = [
        ('draft', 'Draft'),
        ('submitted', 'Submitted'),
        ('checked', 'Checked'),
        ('approved', 'Approved'),
        ('authorized', 'Authorized'),
        ('rejected', 'Rejected'),
    ]

    status = models.CharField(max_length=20, choices=STATUS_CHOICES, default='draft')
    checked_by = models.ForeignKey('auth.User', null=True, on_delete=models.SET_NULL, related_name='%(class)s_checked')
    checked_at = models.DateTimeField(null=True, blank=True)
    approved_by = models.ForeignKey('auth.User', null=True, on_delete=models.SET_NULL, related_name='%(class)s_approved')
    approved_at = models.DateTimeField(null=True, blank=True)
    authorized_by = models.ForeignKey('auth.User', null=True, on_delete=models.SET_NULL, related_name='%(class)s_authorized')
    authorized_at = models.DateTimeField(null=True, blank=True)
    rejection_reason = models.TextField(blank=True)

    class Meta:
        abstract = True
```

### Database Relationships Map
```
FinancialYear (sysconfig)
    ↓ (many)
Company (sysconfig)
    ↓ (one-to-many)
├── Customer (sales) ←→ WorkOrder (sales) → Invoice (accounts)
├── Supplier (procurement) ←→ PurchaseOrder (procurement) → GRN (inventory) → Invoice (accounts)
├── Employee (hr) → Payroll (hr) → BankVoucher (accounts)
├── Item (design) ←→ BOM (design) → MaterialPlan (planning) → ProductionOrder
├── Project (projects) ←→ WorkOrder (sales) → ManpowerPlan (projects)
├── QualityNote (quality) ← GRN (inventory)
└── Budget (mis) → All modules
```

---

## MODULE DEPENDENCY GRAPH

### Level 0: Foundation (No dependencies)
- **sysconfig:** FinancialYear, Company, Country, State, City
- **accounts:** ChartOfAccounts, AccountHead, PaymentTerms

### Level 1: Master Data (Depends on Level 0)
- **hr:** Employee, Department, Designation
- **sales:** Customer
- **procurement:** Supplier
- **design:** Item Master, Unit

### Level 2: Transactional (Depends on Level 1)
- **inventory:** Stock, Location, Item Movement
- **quality:** Quality standards
- **projects:** Project setup

### Level 3: Operational (Depends on Level 2)
- **sales:** WorkOrder, Quotation
- **procurement:** PurchaseRequisition, PurchaseOrder
- **design:** BOM creation
- **planning:** Material Planning
- **machinery:** Maintenance scheduling

### Level 4: Financial Integration (Depends on Level 3)
- **accounts:** Invoicing, Vouchers, Bank reconciliation
- **costing:** Material costing calculations

### Level 5: Reporting & Analytics (Depends on all)
- **mis:** Management reports
- **reports:** Consolidated reports
- **daily_reporting:** Daily tracking

### Level 6: Auxiliary Services (Independent)
- **chatting:** Messaging
- **visitor:** Visitor management
- **scheduler:** Event scheduling
- **appraisal:** Performance reviews
- **support:** System utilities

---

## MIGRATION PHASES

### PHASE 0: Foundation Setup (Week 1-2)
**Objective:** Establish Django project structure and core infrastructure

**Tasks:**
1. Create Django project with settings modularization
2. Set up Docker development environment
3. Configure Tailwind CSS + HTMX
4. Implement core abstract models
5. Set up Redis for caching/sessions
6. Configure SAP HANA database connection
7. Create base templates (base.html, navigation, partials)
8. Set up pytest framework
9. Configure CI/CD pipeline (GitHub Actions)
10. Create custom User model extending AbstractUser

**Testing:**
- Unit tests for core utilities
- Docker container health checks
- Database connection tests (SAP HANA)
- Template rendering tests

**Deliverables:**
- Working Django project skeleton
- Docker compose environment
- Base template system
- Testing framework

---

### PHASE 1: Core System Admin & Authentication (Week 3-4)
**Apps:** `sysconfig`, `accounts` (authentication only)

**Models:**
```python
# sysconfig/models.py
- Company
- FinancialYear
- Country
- State
- City
- SystemConfiguration

# accounts/models.py (auth only)
- UserProfile (extends User)
- Department
- Role
- ModulePermission
```

**Views (CBVs):**
- Company CRUD (ListView, CreateView, UpdateView, DeleteView)
- FinancialYear CRUD with detail views
- Location management (Country/State/City)
- User management (using Django's built-in User model)
- Role & Permission management

**HTMX Features:**
- Modal forms for create/edit
- Inline editing for quick updates
- Cascading dropdowns (Country → State → City)
- Live search/filtering

**Testing:**
- Model validation tests
- Permission tests
- CRUD operation tests
- HTMX interaction tests

---

### PHASE 2: Master Data - HR & Contacts (Week 5-6)
**Apps:** `hr`, `sales` (masters only), `procurement` (masters only)

**Models:**
```python
# hr/models.py
- Employee
- Department
- Designation
- Grade
- BusinessGroup
- SwapCard
- HolidayMaster

# sales/models.py
- Customer
- CustomerCategory
- CustomerSubCategory

# procurement/models.py
- Supplier
- BusinessNature
- BusinessType
- ServiceCoverageArea
```

**Views:**
- Employee CRUD with photo upload
- Department hierarchy view
- Customer master with contact details
- Supplier master with ratings
- Dashboard views for each module

**HTMX Features:**
- Employee quick search
- Photo upload with preview
- Hierarchical department selector
- Supplier rating system

**Testing:**
- Employee data validation
- Customer/Supplier uniqueness
- Photo upload functionality
- Department hierarchy

---

### PHASE 3: Inventory Foundation (Week 7-9)
**Apps:** `inventory`, `design` (item master only)

**Models:**
```python
# design/models.py
- Item (shared across modules)
- Unit
- ItemCategory
- BoughtOutCategory

# inventory/models.py
- ItemLocation
- Stock
- VehicleMaster
- Warehouse
- StockAdjustment
```

**Views:**
- Item master CRUD
- Stock level monitoring (ListView with filters)
- Location management
- Warehouse setup
- Stock adjustment forms

**HTMX Features:**
- Real-time stock level updates
- Item search with autocomplete
- Multi-location stock view
- Stock alerts

**Testing:**
- Stock calculation accuracy
- Negative stock prevention
- Location assignment validation
- Item code uniqueness

---

### PHASE 4: Procurement Workflow (Week 10-12)
**Apps:** `procurement` (full implementation)

**Models:**
```python
# procurement/models.py
- PurchaseRequisition
- PurchaseRequisitionItem
- SpecialPurposeRequisition
- PurchaseOrder
- PurchaseOrderItem
- RateLock
- SupplierRate
```

**Views:**
- PR creation with multi-item entry
- PR approval workflow (Check → Approve → Authorize)
- PO generation from approved PR
- Rate management
- Supplier evaluation
- Print views for PR/PO

**HTMX Features:**
- Dynamic item row addition
- Approval action modals
- PR to PO conversion wizard
- Rate comparison table

**Testing:**
- Workflow state transitions
- PR to PO conversion accuracy
- Approval permission checks
- Rate lock validation

---

### PHASE 5: Inventory Transactions (Week 13-15)
**Apps:** `inventory` (transactions), `quality` (basic QC)

**Models:**
```python
# inventory/models.py
- GoodsReceivedNote (GRN)
- GoodsInwardNote (GIN)
- MaterialRequisitionSlip (MRS)
- MaterialIssueNote (MIN)
- MaterialReturnNote (MRN)
- DeliveryChallan
- WorkOrderIssueSlip

# quality/models.py
- GoodsQualityNote
- MaterialReturnQualityNote
- RejectionNote
```

**Views:**
- GRN creation from PO
- GIN processing
- MRS/MIN workflow
- MRN handling
- QC inspection forms
- Rejection processing

**HTMX Features:**
- PO-based GRN generation
- Auto-populate item details
- QC checklist with pass/fail
- Batch/Serial number tracking

**Testing:**
- Stock movement accuracy
- Transaction sequence validation
- QC workflow tests
- Rejection reversal tests

---

### PHASE 6: Sales & Distribution (Week 16-18)
**Apps:** `sales` (full implementation)

**Models:**
```python
# sales/models.py
- CustomerEnquiry
- Quotation
- QuotationItem
- CustomerPO
- WorkOrder
- WorkOrderItem
- WorkOrderRelease
- WorkOrderDispatch
- WOCategory
```

**Views:**
- Enquiry management
- Quotation generation
- Customer PO entry
- Work Order creation
- WO release workflow
- Dispatch management
- Work Order close/open

**HTMX Features:**
- Quotation calculator
- WO timeline visualization
- Dispatch tracking
- Customer portal (read-only)

**Testing:**
- Enquiry to quotation flow
- WO lifecycle management
- Dispatch quantity validation
- Customer PO matching

---

### PHASE 7: Design & BOM (Week 19-21)
**Apps:** `design` (full implementation), `planning`

**Models:**
```python
# design/models.py
- BillOfMaterials (BOM)
- BOMComponent
- ECN (Engineering Change Note)
- ECNReason
- ItemHistory

# planning/models.py
- ProductionPlan
- MaterialProcess
- BOMPlanning
```

**Views:**
- BOM hierarchical editor
- Multi-level BOM view
- ECN workflow
- BOM costing calculator
- Material planning dashboard

**HTMX Features:**
- Nested BOM tree view
- Drag-drop BOM editor
- ECN approval workflow
- Auto-calculation of material requirements

**Testing:**
- BOM hierarchy validation
- Circular reference prevention
- ECN version control
- Material explosion calculation

---

### PHASE 8: Accounting & Finance (Week 22-25)
**Apps:** `accounts` (full implementation)

**Models:**
```python
# accounts/models.py
- SalesInvoice
- PurchaseInvoice
- BillBooking
- CashVoucher
- BankVoucher
- PaymentVoucher
- ReceiptVoucher
- ProformaInvoice
- BankReconciliation
- CreditorsMaster
- DebtorsMaster
- AssetRegister
- TaxConfiguration (GST/IGST/SGST)
```

**Views:**
- Invoice generation (Sales/Purchase)
- Bill booking
- Voucher entry (Cash/Bank/Journal)
- Payment/Receipt processing
- Bank reconciliation
- Balance sheet
- P&L statement
- Debtor/Creditor aging

**HTMX Features:**
- Auto-calculate tax
- Invoice preview
- Bank statement upload & match
- Payment allocation

**Testing:**
- Double-entry validation
- Tax calculation accuracy
- Bank reconciliation matching
- Balance sheet balancing

---

### PHASE 9: Project Management (Week 26-27)
**Apps:** `projects`

**Models:**
```python
# projects/models.py
- Project
- ManpowerPlanning
- OnSiteAttendance
- MaterialCreditNote
- ProjectPurchaseRequisition
- VendorAssembly
```

**Views:**
- Project creation & tracking
- Manpower allocation
- Attendance tracking
- Vendor assembly management
- Project reports

**HTMX Features:**
- Gantt chart visualization
- Resource allocation matrix
- Attendance entry forms
- Vendor performance dashboard

**Testing:**
- Project timeline validation
- Resource conflict detection
- Attendance calculation
- Vendor tracking

---

### PHASE 10: Manufacturing & Machinery (Week 28-29)
**Apps:** `machinery`, `costing`, `daily_reporting`

**Models:**
```python
# machinery/models.py
- Machine
- PreventiveMaintenance
- MaintenanceSchedule
- ScheduleInput/Output/Process

# costing/models.py
- MaterialCost
- CostCategory
- CostingSheet

# daily_reporting/models.py
- DesignPlan
- ManufacturingPlan
- VendorPlan
- DailyReport
```

**Views:**
- Machine registry
- PM scheduling
- Work order costing
- Daily progress tracking
- Department-wise planning

**HTMX Features:**
- Maintenance calendar
- Cost breakdown charts
- Daily report submission
- Progress tracking dashboards

**Testing:**
- PM schedule generation
- Cost calculation accuracy
- Daily report aggregation

---

### PHASE 11: MIS & Reporting (Week 30-31)
**Apps:** `mis`, `reports`

**Models:**
```python
# mis/models.py
- FinancialBudget
- BudgetByWorkOrder
- BudgetByDepartment
- BudgetByDistribution

# reports/models.py
- (Mostly views, no models)
- SavedReport
- ReportSchedule
```

**Views:**
- Budget creation & tracking
- Sales analysis reports
- Purchase analysis reports
- Variance analysis
- Consolidated reports
- Custom report builder

**HTMX Features:**
- Interactive charts (Chart.js)
- Report parameter forms
- Export to PDF/Excel
- Scheduled report delivery

**Testing:**
- Budget calculation accuracy
- Report data accuracy
- Export functionality
- Chart rendering

---

### PHASE 12: Auxiliary Modules (Week 32-33)
**Apps:** `assets`, `scheduler`, `visitor`, `chatting`, `appraisal`, `subcontracting`, `mroffice`, `support`

**Models:**
```python
# assets/models.py
- AssetPurchaseRequisition
- AssetPurchaseOrder

# scheduler/models.py
- Event
- Meeting
- GatePassSchedule
- IOU

# visitor/models.py
- VisitorGatePass
- Visitor

# chatting/models.py
- ChatRoom
- ChatMessage

# appraisal/models.py
- PerformanceAppraisal
- AppraisalForm

# support/models.py
- SystemCredentials
- SupportTicket
```

**Views:**
- Asset procurement workflow
- Event scheduling calendar
- Visitor gate pass generation
- Chat interface
- Appraisal forms
- System configuration

**HTMX Features:**
- Calendar view for events
- Real-time chat (WebSocket)
- Gate pass printing
- Appraisal workflow

**Testing:**
- Asset workflow
- Event scheduling
- Chat message delivery
- Gate pass generation

---

### PHASE 13: SAP S/4 HANA Integration (Week 34-36)
**Integration Points:**
- Customer master sync
- Supplier master sync
- Material master sync
- Purchase order integration
- Sales invoice posting
- Financial data sync
- Real-time inventory updates

**Implementation:**
```python
# apps/core/sap_integration.py
- SAP HANA database router
- OData API integration
- Real-time sync services
- Conflict resolution
- Error handling & logging
```

**Testing:**
- Data sync accuracy
- Conflict resolution
- Error recovery
- Performance benchmarks

---

### PHASE 14: Migration & Testing (Week 37-40)
**Data Migration:**
1. Export ASP.NET SQL Server data
2. Transform to Django model format
3. Import to SAP HANA
4. Validate data integrity
5. Historical data preservation

**Testing:**
- End-to-end workflow tests
- Performance testing
- Security testing
- User acceptance testing (UAT)
- Load testing

**Deliverables:**
- Complete data migration
- UAT sign-off
- Performance benchmarks
- Security audit report

---

## DJANGO CONVENTIONS & BEST PRACTICES

### 1. Class-Based Views (CBVs)
**Standard CRUD Pattern:**
```python
# apps/sales/views.py
from django.views.generic import ListView, DetailView, CreateView, UpdateView, DeleteView
from django.contrib.auth.mixins import LoginRequiredMixin, PermissionRequiredMixin
from django.urls import reverse_lazy
from .models import Customer
from .forms import CustomerForm

class CustomerListView(LoginRequiredMixin, PermissionRequiredMixin, ListView):
    model = Customer
    template_name = 'sales/customer_list.html'
    context_object_name = 'customers'
    permission_required = 'sales.view_customer'
    paginate_by = 25

    def get_queryset(self):
        queryset = super().get_queryset()
        search = self.request.GET.get('search')
        if search:
            queryset = queryset.filter(name__icontains=search)
        return queryset.select_related('city__state__country')

class CustomerCreateView(LoginRequiredMixin, PermissionRequiredMixin, CreateView):
    model = Customer
    form_class = CustomerForm
    template_name = 'sales/customer_form.html'
    permission_required = 'sales.add_customer'
    success_url = reverse_lazy('sales:customer-list')

    def form_valid(self, form):
        form.instance.created_by = self.request.user
        form.instance.company = self.request.user.profile.company
        return super().form_valid(form)
```

### 2. HTMX Integration
**Template Example:**
```html
<!-- templates/sales/customer_list.html -->
{% extends "base.html" %}

{% block content %}
<div class="container mx-auto px-4 py-8">
    <div class="flex justify-between items-center mb-6">
        <h1 class="text-3xl font-bold">Customers</h1>
        <button
            hx-get="{% url 'sales:customer-create' %}"
            hx-target="#modal-container"
            hx-swap="innerHTML"
            class="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600">
            Add Customer
        </button>
    </div>

    <!-- Search with HTMX -->
    <input
        type="text"
        name="search"
        hx-get="{% url 'sales:customer-list' %}"
        hx-trigger="keyup changed delay:500ms"
        hx-target="#customer-table"
        hx-swap="innerHTML"
        placeholder="Search customers..."
        class="w-full px-4 py-2 border rounded mb-4">

    <!-- Customer Table -->
    <div id="customer-table">
        {% include 'sales/partials/customer_table.html' %}
    </div>
</div>

<!-- Modal Container -->
<div id="modal-container"></div>
{% endblock %}
```

### 3. Model Best Practices
```python
# apps/sales/models.py
from django.db import models
from django.core.validators import MinValueValidator
from django.urls import reverse
from apps.core.models import TimeStampedModel, AuditMixin, CompanyScopedModel

class Customer(TimeStampedModel, AuditMixin, CompanyScopedModel):
    """Customer master data"""

    customer_id = models.CharField(max_length=20, unique=True, db_index=True)
    name = models.CharField(max_length=200)
    email = models.EmailField(blank=True)
    phone = models.CharField(max_length=20, blank=True)
    address = models.TextField()
    city = models.ForeignKey('sysconfig.City', on_delete=models.PROTECT)
    pincode = models.CharField(max_length=10)
    gstin = models.CharField(max_length=15, blank=True)
    category = models.ForeignKey('CustomerCategory', on_delete=models.PROTECT)
    credit_limit = models.DecimalField(
        max_digits=12,
        decimal_places=2,
        validators=[MinValueValidator(0)]
    )
    is_active = models.BooleanField(default=True)

    class Meta:
        ordering = ['name']
        verbose_name = 'Customer'
        verbose_name_plural = 'Customers'
        permissions = [
            ('view_customer_credit', 'Can view customer credit details'),
            ('approve_customer', 'Can approve new customers'),
        ]
        indexes = [
            models.Index(fields=['customer_id']),
            models.Index(fields=['name']),
            models.Index(fields=['company', 'is_active']),
        ]

    def __str__(self):
        return f"{self.name} [{self.customer_id}]"

    def get_absolute_url(self):
        return reverse('sales:customer-detail', kwargs={'pk': self.pk})

    def get_outstanding_balance(self):
        """Calculate outstanding balance"""
        # Business logic here
        return self.invoices.filter(is_paid=False).aggregate(
            total=models.Sum('amount')
        )['total'] or 0
```

### 4. Forms with Validation
```python
# apps/sales/forms.py
from django import forms
from .models import Customer

class CustomerForm(forms.ModelForm):
    class Meta:
        model = Customer
        fields = [
            'customer_id', 'name', 'email', 'phone',
            'address', 'city', 'pincode', 'gstin',
            'category', 'credit_limit'
        ]
        widgets = {
            'customer_id': forms.TextInput(attrs={
                'class': 'w-full px-4 py-2 border rounded',
                'placeholder': 'Auto-generated if empty'
            }),
            'name': forms.TextInput(attrs={
                'class': 'w-full px-4 py-2 border rounded',
                'required': True
            }),
            'address': forms.Textarea(attrs={
                'class': 'w-full px-4 py-2 border rounded',
                'rows': 3
            }),
        }

    def clean_gstin(self):
        gstin = self.cleaned_data.get('gstin')
        if gstin and len(gstin) != 15:
            raise forms.ValidationError('GSTIN must be 15 characters')
        return gstin.upper() if gstin else ''

    def save(self, commit=True):
        instance = super().save(commit=False)
        if not instance.customer_id:
            instance.customer_id = self.generate_customer_id()
        if commit:
            instance.save()
        return instance

    def generate_customer_id(self):
        """Auto-generate customer ID"""
        last_customer = Customer.objects.order_by('-id').first()
        if last_customer:
            return f"CUST{int(last_customer.customer_id[4:]) + 1:05d}"
        return "CUST00001"
```

### 5. URL Patterns
```python
# apps/sales/urls.py
from django.urls import path
from . import views

app_name = 'sales'

urlpatterns = [
    # Customer URLs
    path('customers/', views.CustomerListView.as_view(), name='customer-list'),
    path('customers/create/', views.CustomerCreateView.as_view(), name='customer-create'),
    path('customers/<int:pk>/', views.CustomerDetailView.as_view(), name='customer-detail'),
    path('customers/<int:pk>/edit/', views.CustomerUpdateView.as_view(), name='customer-update'),
    path('customers/<int:pk>/delete/', views.CustomerDeleteView.as_view(), name='customer-delete'),

    # Work Order URLs
    path('workorders/', views.WorkOrderListView.as_view(), name='workorder-list'),
    path('workorders/create/', views.WorkOrderCreateView.as_view(), name='workorder-create'),
    path('workorders/<int:pk>/', views.WorkOrderDetailView.as_view(), name='workorder-detail'),

    # HTMX partials
    path('htmx/customer-table/', views.CustomerTablePartialView.as_view(), name='htmx-customer-table'),
]
```

### 6. Services Layer (Business Logic)
```python
# apps/sales/services.py
from django.db import transaction
from .models import WorkOrder, WorkOrderItem
from apps.inventory.models import Stock
from apps.accounts.models import SalesInvoice

class WorkOrderService:
    """Business logic for Work Orders"""

    @transaction.atomic
    def create_workorder_from_quotation(self, quotation, user):
        """Create work order from approved quotation"""
        workorder = WorkOrder.objects.create(
            customer=quotation.customer,
            quotation=quotation,
            created_by=user,
            company=user.profile.company
        )

        for quote_item in quotation.items.all():
            WorkOrderItem.objects.create(
                workorder=workorder,
                item=quote_item.item,
                quantity=quote_item.quantity,
                rate=quote_item.rate,
                amount=quote_item.amount
            )

        return workorder

    @transaction.atomic
    def release_workorder(self, workorder, release_quantity, released_by):
        """Release work order for production"""
        if workorder.status != 'approved':
            raise ValueError('Only approved work orders can be released')

        # Reserve inventory
        for wo_item in workorder.items.all():
            Stock.objects.reserve_stock(
                item=wo_item.item,
                quantity=release_quantity * wo_item.quantity,
                reference_type='workorder',
                reference_id=workorder.id
            )

        workorder.status = 'released'
        workorder.released_by = released_by
        workorder.save()

        return workorder
```

### 7. Testing Structure
```python
# apps/sales/tests/test_views.py
from django.test import TestCase, Client
from django.urls import reverse
from django.contrib.auth import get_user_model
from apps.sales.models import Customer
from apps.sysconfig.models import Company, City

User = get_user_model()

class CustomerViewTests(TestCase):
    def setUp(self):
        self.client = Client()
        self.user = User.objects.create_user(
            username='testuser',
            password='testpass123'
        )
        self.company = Company.objects.create(name='Test Company')
        self.city = City.objects.create(name='Test City')

    def test_customer_list_view(self):
        """Test customer list view loads correctly"""
        self.client.login(username='testuser', password='testpass123')
        response = self.client.get(reverse('sales:customer-list'))
        self.assertEqual(response.status_code, 200)
        self.assertTemplateUsed(response, 'sales/customer_list.html')

    def test_customer_create_view(self):
        """Test customer creation"""
        self.client.login(username='testuser', password='testpass123')
        data = {
            'name': 'New Customer',
            'email': 'customer@example.com',
            'city': self.city.id,
            'credit_limit': 100000
        }
        response = self.client.post(reverse('sales:customer-create'), data)
        self.assertEqual(response.status_code, 302)
        self.assertTrue(Customer.objects.filter(name='New Customer').exists())
```

---

## TESTING STRATEGY

### Test Pyramid
```
         /\
        /  \  E2E Tests (10%)
       /    \
      /------\ Integration Tests (30%)
     /        \
    /----------\ Unit Tests (60%)
   /____________\
```

### Testing Levels

#### 1. Unit Tests (60%)
- Model validation
- Form validation
- Utility functions
- Custom validators
- Manager methods

#### 2. Integration Tests (30%)
- View tests
- URL routing
- Template rendering
- Form submission
- HTMX interactions

#### 3. End-to-End Tests (10%)
- Complete workflows
- Cross-module integration
- User journeys
- Performance tests

### Test Commands
```bash
# Run all tests
pytest

# Run specific app tests
pytest apps/sales/tests/

# Run with coverage
pytest --cov=apps --cov-report=html

# Run parallel
pytest -n auto

# Run integration tests only
pytest -m integration

# Run unit tests only
pytest -m unit
```

### Continuous Testing
- Pre-commit hooks for basic tests
- CI pipeline runs full test suite
- Coverage threshold: 80% minimum
- Automated regression testing

---

## IMPLEMENTATION ROADMAP

### Timeline Overview (40 weeks = 10 months)

| Phase | Duration | Apps | Key Deliverables |
|-------|----------|------|------------------|
| 0 | 2 weeks | Foundation | Django project setup |
| 1 | 2 weeks | sysconfig, auth | User management |
| 2 | 2 weeks | hr, sales, procurement | Master data |
| 3 | 3 weeks | inventory, design | Stock management |
| 4 | 3 weeks | procurement | PR/PO workflow |
| 5 | 3 weeks | inventory, quality | Transactions |
| 6 | 3 weeks | sales | Sales workflow |
| 7 | 3 weeks | design, planning | BOM & Planning |
| 8 | 4 weeks | accounts | Financial accounting |
| 9 | 2 weeks | projects | Project management |
| 10 | 2 weeks | machinery, costing | Manufacturing |
| 11 | 2 weeks | mis, reports | Reporting |
| 12 | 2 weeks | 8 auxiliary apps | Misc modules |
| 13 | 3 weeks | SAP integration | HANA integration |
| 14 | 4 weeks | Migration & UAT | Production ready |

**Total: 40 weeks**

---

## SAP S/4 HANA INTEGRATION

### Database Router
```python
# erp_project/db_router.py

class SAPHANARouter:
    """Route database operations to SAP HANA"""

    route_app_labels = {
        'accounts', 'inventory', 'sales',
        'procurement', 'hr', 'projects'
    }

    def db_for_read(self, model, **hints):
        if model._meta.app_label in self.route_app_labels:
            return 'sap_hana'
        return 'default'

    def db_for_write(self, model, **hints):
        if model._meta.app_label in self.route_app_labels:
            return 'sap_hana'
        return 'default'

    def allow_migrate(self, db, app_label, model_name=None, **hints):
        if app_label in self.route_app_labels:
            return db == 'sap_hana'
        return db == 'default'
```

### SAP HANA Connection
```python
# erp_project/settings/production.py

DATABASES = {
    'default': {
        'ENGINE': 'django.db.backends.sqlite3',
        'NAME': BASE_DIR / 'db.sqlite3',
    },
    'sap_hana': {
        'ENGINE': 'django_hana',
        'NAME': 'ERP_DB',
        'USER': os.environ.get('SAP_HANA_USER'),
        'PASSWORD': os.environ.get('SAP_HANA_PASSWORD'),
        'HOST': os.environ.get('SAP_HANA_HOST'),
        'PORT': os.environ.get('SAP_HANA_PORT', '30015'),
        'OPTIONS': {
            'autocommit': True,
            'use_legacy_datetime': False,
        }
    }
}

DATABASE_ROUTERS = ['erp_project.db_router.SAPHANARouter']
```

### OData API Integration
```python
# apps/core/sap_odata.py

import requests
from django.conf import settings

class SAPODataClient:
    """SAP OData API client for real-time sync"""

    def __init__(self):
        self.base_url = settings.SAP_ODATA_URL
        self.username = settings.SAP_ODATA_USER
        self.password = settings.SAP_ODATA_PASSWORD

    def get_customer(self, customer_id):
        """Fetch customer from SAP"""
        url = f"{self.base_url}/CustomerSet('{customer_id}')"
        response = requests.get(
            url,
            auth=(self.username, self.password),
            headers={'Accept': 'application/json'}
        )
        return response.json()

    def create_sales_order(self, order_data):
        """Create sales order in SAP"""
        url = f"{self.base_url}/SalesOrderSet"
        response = requests.post(
            url,
            json=order_data,
            auth=(self.username, self.password),
            headers={'Content-Type': 'application/json'}
        )
        return response.json()
```

---

## MIGRATION EXECUTION STEPS

### Step 1: Data Analysis
```bash
# Analyze ASP.NET database
python manage.py analyze_aspnet_db --connection "Server=.;Database=ERP_DB"

# Generate Django models from SQL Server schema
python manage.py inspectdb --database aspnet_source > legacy_models.py
```

### Step 2: Data Extraction
```bash
# Export all tables to JSON
python manage.py export_aspnet_data --output /tmp/aspnet_export/

# Validate exported data
python manage.py validate_export --path /tmp/aspnet_export/
```

### Step 3: Data Transformation
```bash
# Transform ASP.NET data to Django format
python manage.py transform_data \
    --input /tmp/aspnet_export/ \
    --output /tmp/django_import/ \
    --mapping migration_mapping.yaml
```

### Step 4: Data Import
```bash
# Import to Django
python manage.py import_django_data --path /tmp/django_import/

# Verify data integrity
python manage.py verify_import --detailed
```

### Step 5: Validation
```bash
# Run all tests
pytest --cov=apps

# Compare record counts
python manage.py compare_record_counts \
    --aspnet "Server=.;Database=ERP_DB" \
    --django default

# Generate migration report
python manage.py migration_report --output migration_report.pdf
```

---

## DEPLOYMENT CHECKLIST

### Pre-Production
- [ ] All tests passing (100%)
- [ ] Code coverage > 80%
- [ ] Security audit completed
- [ ] Performance benchmarks met
- [ ] UAT sign-off received
- [ ] Data migration validated
- [ ] Rollback plan documented
- [ ] Staff training completed

### Production Deployment
- [ ] Database backups taken
- [ ] SAP HANA connection tested
- [ ] Static files collected
- [ ] Environment variables set
- [ ] SSL certificates installed
- [ ] Monitoring configured
- [ ] Logging enabled
- [ ] Email notifications set up

### Post-Deployment
- [ ] Smoke tests passed
- [ ] User login verification
- [ ] Critical workflows tested
- [ ] Performance monitoring active
- [ ] Error tracking enabled
- [ ] Backup verification
- [ ] Documentation updated
- [ ] Stakeholder communication sent

---

## CONCLUSION

This migration plan provides a comprehensive, dependency-aware roadmap for transforming the legacy ASP.NET ERP system into a modern Django application. By following Django conventions, leveraging class-based views, and implementing HTMX for dynamic interactions, we will create a robust, maintainable, and scalable ERP system.

**Key Success Factors:**
1. **Phased Approach:** Incremental delivery with testing at each phase
2. **Django Best Practices:** CBVs, ORM, built-in features
3. **HTMX Integration:** Modern UX without complex JavaScript
4. **Comprehensive Testing:** 80%+ code coverage
5. **SAP HANA Integration:** Enterprise-grade database
6. **Zero Redundancy:** DRY principle throughout

**Next Steps:**
1. Review and approve this plan
2. Set up development environment (Phase 0)
3. Begin Phase 1 implementation
4. Weekly progress reviews
5. Continuous integration and testing

---

**Document Version:** 1.0
**Last Updated:** 2025-11-06
**Status:** Ready for Implementation
