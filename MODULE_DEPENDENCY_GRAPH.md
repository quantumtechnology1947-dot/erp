# MODULE DEPENDENCY GRAPH & IMPLEMENTATION ORDER
## Django ERP Migration - Dependency-Aware Implementation

**Generated:** 2025-11-06

---

## DEPENDENCY HIERARCHY

### Visual Representation

```
LEVEL 0: FOUNDATION (No Dependencies)
┌─────────────────────────────────────────────────────┐
│ sysconfig (System Configuration)                    │
│ - Company, FinancialYear, Country, State, City      │
│                                                      │
│ accounts.auth (Authentication Only)                 │
│ - User, UserProfile, Role, Permission               │
└─────────────────────────────────────────────────────┘
                        ↓
LEVEL 1: MASTER DATA (Depends on Level 0)
┌─────────────────────────────────────────────────────┐
│ hr (Human Resources)                                │
│ - Employee, Department, Designation                 │
│   Depends on: sysconfig.Company                     │
│                                                      │
│ sales.masters (Sales Master Data)                   │
│ - Customer, CustomerCategory                        │
│   Depends on: sysconfig.City                        │
│                                                      │
│ procurement.masters (Procurement Masters)           │
│ - Supplier, BusinessNature, BusinessType            │
│   Depends on: sysconfig.City                        │
│                                                      │
│ design.masters (Item Master)                        │
│ - Item, Unit, ItemCategory                          │
│   Depends on: sysconfig.Company                     │
└─────────────────────────────────────────────────────┘
                        ↓
LEVEL 2: OPERATIONAL FOUNDATION (Depends on Level 1)
┌─────────────────────────────────────────────────────┐
│ inventory.foundation (Stock Foundation)             │
│ - Warehouse, ItemLocation, Vehicle                  │
│   Depends on: design.Item, sysconfig                │
│                                                      │
│ quality.setup (Quality Standards)                   │
│ - QualityParameter, InspectionChecklist             │
│   Depends on: design.Item                           │
│                                                      │
│ projects.setup (Project Setup)                      │
│ - ProjectTemplate, ResourceType                     │
│   Depends on: hr.Employee                           │
└─────────────────────────────────────────────────────┘
                        ↓
LEVEL 3: TRANSACTIONAL (Depends on Level 2)
┌─────────────────────────────────────────────────────┐
│ procurement.transactions (Procurement Workflow)     │
│ - PurchaseRequisition, PurchaseOrder                │
│   Depends on: procurement.Supplier, design.Item     │
│                                                      │
│ sales.transactions (Sales Workflow)                 │
│ - Quotation, WorkOrder                              │
│   Depends on: sales.Customer, design.Item           │
│                                                      │
│ design.transactions (BOM & ECN)                     │
│ - BOM, ECN                                          │
│   Depends on: design.Item                           │
│                                                      │
│ planning (Material Planning)                        │
│ - ProductionPlan, MaterialProcess                   │
│   Depends on: design.BOM, sales.WorkOrder           │
└─────────────────────────────────────────────────────┘
                        ↓
LEVEL 4: INVENTORY & QUALITY (Depends on Level 3)
┌─────────────────────────────────────────────────────┐
│ inventory.transactions (Stock Movement)             │
│ - GRN, GIN, MRS, MIN, MRN, DeliveryChallan         │
│   Depends on: procurement.PO, sales.WO, quality     │
│                                                      │
│ quality.transactions (Quality Control)              │
│ - GoodsQualityNote, RejectionNote                  │
│   Depends on: inventory.GRN                         │
│                                                      │
│ machinery (Machinery & Maintenance)                 │
│ - Machine, PreventiveMaintenance                    │
│   Depends on: hr.Employee, inventory                │
└─────────────────────────────────────────────────────┘
                        ↓
LEVEL 5: FINANCIAL INTEGRATION (Depends on Level 4)
┌─────────────────────────────────────────────────────┐
│ accounts.transactions (Financial Accounting)        │
│ - Invoice, Voucher, BankReconciliation              │
│   Depends on: sales.WO, procurement.PO, inventory   │
│                                                      │
│ costing (Material Costing)                          │
│ - MaterialCost, CostingSheet                        │
│   Depends on: design.BOM, inventory, accounts       │
│                                                      │
│ projects.transactions (Project Execution)           │
│ - ManpowerPlan, OnSiteAttendance, MaterialCreditNote│
│   Depends on: hr.Employee, inventory, accounts      │
└─────────────────────────────────────────────────────┘
                        ↓
LEVEL 6: REPORTING & ANALYTICS (Depends on All)
┌─────────────────────────────────────────────────────┐
│ mis (Management Information System)                 │
│ - Budget, FinancialReport, VarianceAnalysis         │
│   Depends on: ALL modules                           │
│                                                      │
│ reports (Consolidated Reports)                      │
│ - CrossModuleReports, CustomReports                 │
│   Depends on: ALL modules                           │
│                                                      │
│ daily_reporting (Daily Reporting System)            │
│ - DesignPlan, ManufacturingPlan, VendorPlan         │
│   Depends on: projects, design, procurement         │
└─────────────────────────────────────────────────────┘
                        ↓
LEVEL 7: AUXILIARY SERVICES (Independent)
┌─────────────────────────────────────────────────────┐
│ assets (Asset Management)                           │
│ - AssetPR, AssetPO                                  │
│   Depends on: procurement (pattern only)            │
│                                                      │
│ scheduler (Event Scheduling)                        │
│ - Event, Meeting, GatePass, IOU                     │
│   Depends on: hr.Employee                           │
│                                                      │
│ visitor (Visitor Management)                        │
│ - VisitorGatePass, Visitor                          │
│   Depends on: hr.Employee                           │
│                                                      │
│ chatting (Internal Messaging)                       │
│ - ChatRoom, Message                                 │
│   Depends on: auth.User                             │
│                                                      │
│ appraisal (Performance Appraisal)                   │
│ - PerformanceAppraisal, AppraisalForm               │
│   Depends on: hr.Employee                           │
│                                                      │
│ subcontracting (Sub-contracting)                    │
│ - SubcontractOrder                                  │
│   Depends on: procurement.Supplier                  │
│                                                      │
│ mroffice (Material Request Office)                  │
│ - MaterialRequest                                   │
│   Depends on: inventory                             │
│                                                      │
│ support (System Support)                            │
│ - SystemCredentials, Configuration                  │
│   Depends on: auth.User                             │
└─────────────────────────────────────────────────────┘
```

---

## DETAILED DEPENDENCY MATRIX

### Level 0: Foundation

| App | Dependencies | Key Models | Must Implement First |
|-----|--------------|------------|---------------------|
| `sysconfig` | None | Company, FinancialYear, Country, State, City | ✅ YES |
| `accounts.auth` | None | User, UserProfile, Role, ModulePermission | ✅ YES |

**Implementation Order:** 1st (Week 3-4)

---

### Level 1: Master Data

| App | Dependencies | Key Models | Depends On |
|-----|--------------|------------|------------|
| `hr` | sysconfig | Employee, Department, Designation, Grade, HolidayMaster | Company |
| `sales.masters` | sysconfig | Customer, CustomerCategory, CustomerSubCategory | City (State, Country) |
| `procurement.masters` | sysconfig | Supplier, BusinessNature, BusinessType | City (State, Country) |
| `design.masters` | sysconfig | Item, Unit, ItemCategory, BoughtOutCategory | Company |

**Implementation Order:** 2nd (Week 5-6)

**Cross-Dependencies:**
- All depend on `sysconfig.Company`
- Customer/Supplier depend on `sysconfig.City`
- Employee depends on `Department` (same app)

---

### Level 2: Operational Foundation

| App | Dependencies | Key Models | Depends On |
|-----|--------------|------------|------------|
| `inventory.foundation` | design, sysconfig | Warehouse, ItemLocation, VehicleMaster, Stock | Item, Company |
| `quality.setup` | design | QualityParameter, InspectionChecklist | Item |
| `projects.setup` | hr, sysconfig | ProjectTemplate, ResourceType | Employee, Company |

**Implementation Order:** 3rd (Week 7-9)

**Cross-Dependencies:**
- Inventory depends on `design.Item` (must exist first)
- Quality depends on `design.Item`
- Projects depend on `hr.Employee`

---

### Level 3: Transactional

| App | Dependencies | Key Models | Depends On |
|-----|--------------|------------|------------|
| `procurement.transactions` | procurement.masters, design, hr | PurchaseRequisition, SPR, PurchaseOrder, RateLock | Supplier, Item, Employee (for approval) |
| `sales.transactions` | sales.masters, design, hr | Quotation, CustomerPO, WorkOrder, Dispatch | Customer, Item, Employee |
| `design.transactions` | design.masters | BOM, BOMComponent, ECN | Item |
| `planning` | design.transactions, sales.transactions | ProductionPlan, MaterialProcess, BOMPlanning | BOM, WorkOrder |

**Implementation Order:** 4th-7th (Week 10-21)

**Cross-Dependencies:**
- PR/PO depend on Supplier + Item
- WO depends on Customer + Item + BOM
- Planning depends on BOM + WorkOrder
- All approval workflows depend on `hr.Employee`

**Critical Workflows:**
```
PurchaseRequisition (PR)
  ↓ Check → Approve → Authorize (hr.Employee roles)
PurchaseOrder (PO)
  ↓ Check → Approve → Authorize
Ready for GRN (inventory)
```

---

### Level 4: Inventory & Quality

| App | Dependencies | Key Models | Depends On |
|-----|--------------|------------|------------|
| `inventory.transactions` | procurement, sales, quality, planning | GRN, GIN, MRS, MIN, MRN, DeliveryChallan, WIS, GSN | PO, WO, Item, Location |
| `quality.transactions` | inventory, design | GoodsQualityNote, MRQN, RejectionNote | GRN, Item |
| `machinery` | hr, inventory, design | Machine, PreventiveMaintenance, MaintenanceSchedule | Employee, Item |

**Implementation Order:** 5th (Week 13-15)

**Cross-Dependencies:**
- GRN created from approved PO
- GQN (Quality Note) created from GRN
- MIN (Issue) created from approved MRS (Requisition)
- MRN (Return) references MIN

**Critical Workflow:**
```
PO (approved)
  → GRN (Goods Receipt)
  → GQN (Quality Inspection)
  → Stock Update (if passed)
  → MRQN + Rejection (if failed)
```

---

### Level 5: Financial Integration

| App | Dependencies | Key Models | Depends On |
|-----|--------------|------------|------------|
| `accounts.transactions` | sales, procurement, inventory, hr | SalesInvoice, PurchaseInvoice, BillBooking, CashVoucher, BankVoucher, PaymentVoucher, ReceiptVoucher, BankReconciliation | WO, PO, GRN, Employee |
| `costing` | design, inventory, accounts, planning | MaterialCost, CostCategory, CostingSheet | BOM, Stock, Invoice |
| `projects.transactions` | projects.setup, hr, inventory, accounts | Project, ManpowerPlan, OnSiteAttendance, MaterialCreditNote | Employee, Stock, Invoice |

**Implementation Order:** 8th-9th (Week 22-27)

**Cross-Dependencies:**
- Sales Invoice created from completed WorkOrder
- Purchase Invoice created from GRN + PO
- Payroll (hr) creates Bank Vouchers
- Costing depends on BOM + actual consumption
- Project costing depends on attendance + material consumption

**Critical Workflow:**
```
WorkOrder (completed)
  → Dispatch
  → Sales Invoice (accounts)
  → Payment Receipt
  → Bank Voucher

PurchaseOrder
  → GRN (inventory)
  → Purchase Invoice (accounts)
  → Payment Voucher
  → Bank Voucher
```

---

### Level 6: Reporting & Analytics

| App | Dependencies | Key Models | Depends On |
|-----|--------------|------------|------------|
| `mis` | ALL modules | FinancialBudget, BudgetByWO, BudgetByDept, VarianceAnalysis | All transactional data |
| `reports` | ALL modules | (Views only, no models) SavedReport, ReportSchedule | All modules |
| `daily_reporting` | projects, design, procurement, hr | DesignPlan, ManufacturingPlan, VendorPlan, DailyReport | Project, BOM, Supplier, Employee |

**Implementation Order:** 11th (Week 30-31)

**Cross-Dependencies:**
- MIS requires complete transactional data from all modules
- Reports pull data from all modules
- Daily Reporting aggregates data from projects, design, procurement

**Note:** These apps are READ-HEAVY with minimal writes, primarily for analytics.

---

### Level 7: Auxiliary Services

| App | Dependencies | Key Models | Depends On |
|-----|--------------|------------|------------|
| `assets` | procurement (pattern) | AssetPurchaseRequisition, AssetPurchaseOrder, AssetSupplier | Supplier (concept), Employee |
| `scheduler` | hr | Event, Meeting, GatePass, IOU | Employee |
| `visitor` | hr | VisitorGatePass, Visitor | Employee (host) |
| `chatting` | auth | ChatRoom, ChatMessage | User |
| `appraisal` | hr | PerformanceAppraisal, AppraisalForm | Employee |
| `subcontracting` | procurement | SubcontractOrder | Supplier |
| `mroffice` | inventory | MaterialRequest | Item, Stock |
| `support` | auth | SystemCredentials, Configuration, SupportTicket | User |

**Implementation Order:** 12th (Week 32-33)

**Cross-Dependencies:**
- Most depend only on User or Employee
- Can be implemented independently
- Lower priority as they're auxiliary functions

---

## IMPLEMENTATION SEQUENCE (Optimized)

### Phase Order with Rationale

| Phase | Week | Apps | Rationale |
|-------|------|------|-----------|
| 0 | 1-2 | Foundation Setup | Django project, Docker, Tailwind, HTMX, Redis, testing framework |
| 1 | 3-4 | `sysconfig`, `accounts.auth` | Foundation for all other modules; user management critical |
| 2 | 5-6 | `hr`, `sales.masters`, `procurement.masters`, `design.masters` | Master data needed for transactions |
| 3 | 7-9 | `inventory.foundation`, `quality.setup`, `projects.setup` | Operational foundation for stock management |
| 4 | 10-12 | `procurement.transactions` | PR/PO workflow needed for inventory receipts |
| 5 | 13-15 | `inventory.transactions`, `quality.transactions` | GRN/GIN/MRS/MIN core to operations |
| 6 | 16-18 | `sales.transactions` | WO workflow; depends on BOM (next phase) |
| 7 | 19-21 | `design.transactions`, `planning` | BOM & material planning; feeds into costing |
| 8 | 22-25 | `accounts.transactions` | Financial integration; depends on all operational data |
| 9 | 26-27 | `projects.transactions`, `machinery` | Project tracking and maintenance |
| 10 | 28-29 | `costing`, `daily_reporting` | Cost analysis and daily progress |
| 11 | 30-31 | `mis`, `reports` | Reporting and analytics on complete dataset |
| 12 | 32-33 | 8 auxiliary apps | Supporting services |
| 13 | 34-36 | SAP S/4 HANA Integration | Enterprise integration |
| 14 | 37-40 | Data Migration & UAT | Production readiness |

---

## CRITICAL PATH ANALYSIS

### Blocking Dependencies (Must Complete Before Others)

```
sysconfig → BLOCKS ALL MODULES
   ↓
design.Item → BLOCKS inventory, procurement, sales, quality
   ↓
procurement.Supplier → BLOCKS procurement.PO
hr.Employee → BLOCKS approval workflows
   ↓
procurement.PO → BLOCKS inventory.GRN
sales.WorkOrder → BLOCKS inventory.MIN, accounts.SalesInvoice
   ↓
inventory.GRN → BLOCKS quality.GQN, accounts.PurchaseInvoice
   ↓
accounts.Invoice → BLOCKS accounts.Vouchers
   ↓
ALL transactions → BLOCKS mis, reports
```

### Parallel Development Opportunities

**Can be developed simultaneously:**

1. **After Level 0 (sysconfig):**
   - hr, sales.masters, procurement.masters, design.masters (all in parallel)

2. **After Level 1 (master data):**
   - inventory.foundation, quality.setup, projects.setup (all in parallel)

3. **After Level 3 (procurement + sales transactions):**
   - inventory.transactions + quality.transactions (parallel)
   - sales.WorkOrder processing (parallel)

4. **After Level 5 (financial):**
   - projects, machinery, costing, daily_reporting (all in parallel)

5. **Level 7 (Auxiliary):**
   - All 8 apps can be developed in parallel

---

## RISK MITIGATION

### High-Risk Dependencies

| Dependency | Risk | Mitigation |
|------------|------|------------|
| `design.Item` used everywhere | Single point of failure | Implement early (Phase 2), comprehensive testing |
| `hr.Employee` for approvals | Approval workflows blocked | Implement in Phase 2, create test fixtures |
| `procurement.PO` → `inventory.GRN` | Broken link breaks inventory | Integration tests, transaction atomicity |
| `sales.WO` → `accounts.Invoice` | Financial data integrity | Double-entry validation, referential integrity |
| SAP HANA integration | Complex, late-stage | Develop abstraction layer early, mock SAP in tests |

### Dependency Validation Checklist

Before moving to next phase:
- [ ] All models have migrations
- [ ] Foreign keys validated with database constraints
- [ ] Reverse relationships tested (`related_name`)
- [ ] Cascade delete behavior verified
- [ ] Integration tests pass for cross-app workflows
- [ ] Performance tests for joined queries
- [ ] Data integrity constraints enforced

---

## DATABASE FOREIGN KEY MAP

### Core Relationships

```python
# sysconfig
Company (1) ←→ (many) All modules

# design
Item (1) ←→ (many) BOM, Stock, PRItem, POItem, WOItem, InvoiceItem

# hr
Employee (1) ←→ (many) Approvals (checked_by, approved_by, authorized_by)

# procurement
Supplier (1) ←→ (many) PurchaseOrder
PurchaseOrder (1) ←→ (many) PurchaseOrderItem
PurchaseOrder (1) ←→ (many) GRN

# sales
Customer (1) ←→ (many) WorkOrder
WorkOrder (1) ←→ (many) WorkOrderItem
WorkOrder (1) ←→ (many) SalesInvoice

# inventory
GRN (1) ←→ (many) GoodsQualityNote
Stock (1) ←→ (many) StockMovement (GIN, MIN, MRS, MRN)

# accounts
Invoice (1) ←→ (many) PaymentVoucher
BankAccount (1) ←→ (many) BankVoucher
```

---

## TESTING DEPENDENCIES

### Test Data Creation Order

```python
# tests/factories.py (using factory_boy)

# Level 0
CompanyFactory → creates base company
FinancialYearFactory → creates active financial year
UserFactory → creates test users

# Level 1
EmployeeFactory → requires Company, User
CustomerFactory → requires Company, City
SupplierFactory → requires Company, City
ItemFactory → requires Company, Unit

# Level 2
StockFactory → requires Item, Warehouse
WarehouseFactory → requires Company

# Level 3
PurchaseRequisitionFactory → requires Supplier, Item, Employee (created_by)
WorkOrderFactory → requires Customer, Item, Employee

# Level 4
PurchaseOrderFactory → requires PurchaseRequisition, Supplier
GRNFactory → requires PurchaseOrder, Item

# Level 5
SalesInvoiceFactory → requires WorkOrder, Customer
PurchaseInvoiceFactory → requires GRN, PurchaseOrder

# Use in tests
def test_complete_procurement_workflow():
    company = CompanyFactory()
    employee = EmployeeFactory(company=company)
    supplier = SupplierFactory(company=company)
    item = ItemFactory(company=company)

    pr = PurchaseRequisitionFactory(
        company=company,
        created_by=employee.user,
        supplier=supplier
    )

    # ... rest of workflow
```

---

## MIGRATION DATA FLOW

### Data Migration Order

```
1. sysconfig: Company, FinancialYear, Location (Country/State/City)
2. auth: User, Role, Permission
3. hr: Department, Designation, Employee
4. design: Unit, ItemCategory, Item
5. sales: CustomerCategory, Customer
6. procurement: Supplier, BusinessNature
7. inventory: Warehouse, ItemLocation, Stock (opening balances)
8. procurement: PurchaseRequisition, PurchaseOrder (historical)
9. sales: Quotation, WorkOrder (historical)
10. inventory: GRN, GIN, MRS, MIN (historical transactions)
11. quality: QualityNote, RejectionNote
12. design: BOM, ECN
13. accounts: AccountHead, Invoice, Voucher (historical financial data)
14. projects: Project, ManpowerPlan
15. All other modules in any order
```

**Critical:** Must maintain referential integrity at each step.

---

## CONCLUSION

This dependency graph ensures:
1. **No circular dependencies**
2. **Clear implementation order**
3. **Parallel development opportunities**
4. **Risk mitigation strategies**
5. **Data integrity throughout migration**

**Follow this sequence strictly to avoid:**
- Foreign key constraint violations
- Missing reference data
- Broken workflows
- Data inconsistencies

---

**Next Steps:**
1. Review dependency graph with team
2. Assign apps to developers based on dependencies
3. Create test data factories for each level
4. Implement CI/CD pipeline to enforce dependency order
5. Begin Phase 0 (Foundation Setup)

---

**Document Version:** 1.0
**Last Updated:** 2025-11-06
**Status:** Ready for Implementation
