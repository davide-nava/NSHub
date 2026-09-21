# NSHub Enterprise Architecture Blueprint: Modular Monolith Ecosystem

## 1. Executive Summary & Modular Monolith Philosophy

**NSHub** is an enterprise-grade ERP and operational management platform architected as a **Modular Monolith**. It unifies diverse enterprise capabilities into a single deployable solution while rigorously enforcing the autonomy, loose coupling, and strict encapsulation characteristic of Domain-Driven Design (DDD) Bounded Contexts.

### Architectural Invariants
- **High Cohesion, Loose Coupling**: Each Bounded Context owns its domain logic, state invariants, CQRS use cases, and persistence mappings.
- **In-Process Communication**: Cross-context interactions avoid direct relational joins across aggregate roots. Modules interact through strictly-typed Application contracts, shared kernel value objects, or asynchronous domain events.
- **Clean Architecture Dependency Inversion**:
  $$\text{Domain} \longleftarrow \text{Application} \longleftarrow \text{Infrastructure} \longleftarrow \text{API}$$
  - The **Domain** has zero external dependencies.
  - The **Application** layer depends solely on Domain abstractions.
  - The **Infrastructure** layer implements repository contracts, EF Core configurations, and external integrations.
  - The **API** orchestrates HTTP endpoints and dependency injection composition.

```
       ┌─────────────────────────────────────────────────────────┐
       │                       NSHub.Api                         │
       └────────────────────────────┬────────────────────────────┘
                                    │
                                    ▼
       ┌─────────────────────────────────────────────────────────┐
       │                   NSHub.Application                     │
       │  (CQRS Handlers, FluentValidation, Pipeline Behaviors)  │
       └────────────────────────────┬────────────────────────────┘
                                    │
                                    ▼
       ┌─────────────────────────────────────────────────────────┐
       │                      NSHub.Domain                       │
       │ (Aggregates, Strongly-Typed IDs, Invariants, Events)   │
       └────────────────────────────▲────────────────────────────┘
                                    │
       ┌────────────────────────────┴────────────────────────────┐
       │                   NSHub.Infrastructure                  │
       │    (EF Core, SQLite WAL, Repositories, Providers)       │
       └─────────────────────────────────────────────────────────┘
```

---

## 2. Comprehensive Bounded Context Catalog (15 Domains)

The NSHub enterprise scope is decomposed into 15 autonomous Bounded Contexts:

| # | Bounded Context | Business Capability & Scope | Primary Aggregates & Entities | Integration Touchpoints |
|---|---|---|---|---|
| **1** | **Identity & Access Management (IAM)** | Authentication, authorization, granular RBAC/claims, multi-tenancy isolation, security audit logging, GDPR compliance. | `User`, `Role`, `UserRole`, `UserClaim`, `Tenant` | All modules consume `UserId` and `TenantId`. |
| **2** | **Human Resources (HR)** | Employee lifecycle, master records, contracts, departments, compliance metrics, statutory limits. | `Employee`, `Department`, `Contract`, `Skill` | Consumed by TimeAttendance, Tickets, Projects, Portals. |
| **3** | **Time & Attendance** | Clock-in/out tracking (timbrature), geolocation capture, anomaly detection (missing checkout, overtime, rest periods). | `TimeEntry`, `TimeCorrectionAudit`, `WorkSchedule` | References `EmployeeId`, feeds Payroll/HR. |
| **4** | **Ticketing & Service Desk** | Customer support, multi-tier SLAs, incident resolution workflows, technician scheduling, rich comments. | `Ticket`, `TicketComment`, `SlaPolicy` | References `UserId` (technician/reporter), `CustomerId`. |
| **5** | **Inventory & Warehouse** | Multi-warehouse locations, stock balance tracking, stock reservations, inbound/outbound/transfer movements, reorder thresholds. | `Article`, `StockLocation`, `InventoryStock`, `InventoryMovement` | Triggered by Sales Invoicing, Procurement, Manufacturing. |
| **6** | **Sales, CRM & Invoicing** | Lead/opportunity tracking, customer master, quotations, sales orders, electronic invoicing (Fatturazione Elettronica ready), credit notes. | `Customer`, `Invoice`, `InvoiceLine`, `SalesOrder`, `PriceList` | Consumes `ArticleId`, triggers `InventoryMovement`, posts to Finance. |
| **7** | **Procurement & Vendor Management** | Purchase requisitions (RDA), supplier master, vendor RFQ comparisons, purchase orders, goods receipt matching. | `Vendor`, `PurchaseRequisition`, `PurchaseOrder`, `GoodsReceipt` | Updates Inventory stock, feeds Finance AP. |
| **8** | **Finance & Accounting** | General ledger, Accounts Payable (AP), Accounts Receivable (AR), chart of accounts, payment schedules (scadenziario), VAT reporting. | `LedgerAccount`, `JournalEntry`, `PaymentSchedule`, `VatRegister` | Consumes finalized Invoices and Procurement receipts. |
| **9** | **Manufacturing (MES/MRP)** | Bill of Materials (BOM), work centers, routing steps, production orders, material requirements planning, scrap tracking. | `BillOfMaterials`, `ProductionOrder`, `WorkCenter`, `RoutingStep` | Reserves Inventory items, triggers stock movements upon completion. |
| **10** | **Project & Portfolio Management** | Work Breakdown Structure (WBS), project phases, Gantt planning, timesheets, resource allocation, project P&L profitability. | `Project`, `ProjectPhase`, `Task`, `Timesheet`, `Milestone` | Correlates `EmployeeId`, `TimeEntryId`, and Invoiced amounts. |
| **11** | **Document Management & Workflow** | Secure document archiving, metadata categorization, version control, cryptographic hashing, digital signatures, approval chains. | `Document`, `DocumentVersion`, `ApprovalWorkflow`, `AuditLog` | Attaches to Invoices, Contracts, NCRs, Tickets. |
| **12** | **E-Commerce & Omnichannel** | Digital catalog synchronization, incoming orders, courier integration, shipment tracking webhooks, marketplace connectors. | `Channel`, `ChannelListing`, `DispatchOrder`, `TrackingEvent` | Ingests orders into Sales, syncs stock with Warehouse. |
| **13** | **Quality & Compliance** | Non-conformity reports (NCR), internal/external audits, Corrective and Preventive Actions (CAPA), ISO compliance evidence. | `NonConformityReport`, `CapaAction`, `QualityAudit` | Links to Manufacturing production orders, Vendor deliveries. |
| **14** | **Self-Service Portals** | Dedicated experiences: Customer Portal (orders, tickets, invoice downloads), Vendor Portal (RFQs, orders), Employee Portal (leaves, punches). | `PortalSession`, `PortalInvitation`, `DelegatedAccess` | Exposes tailored subsets of IAM, HR, Invoicing, and Tickets. |
| **15** | **BI & AI Copilot** | Analytical read models, star schema projections, natural language enterprise assistants, anomaly detection, predictive forecasting. | `KpiSnapshot`, `AnalyticalProjection`, `CopilotPromptSession` | Read-only consumer across all transaction aggregates. |

---

## 3. Shared Kernel & Core Invariants

The **Shared Kernel** (`NSHub.Domain.Common`) supplies the foundational primitives without leaking domain-specific business rules:

1. **Entity & AggregateRoot Abstractions**:
   - `Entity<TId>`: Base class encapsulating a strongly-typed ID and in-memory domain events (`IReadOnlyCollection<object> DomainEvents`).
   - `AggregateRoot<TId>`: Marker and foundation enforcing transactional boundaries; child entities can only be accessed or mutated through root methods.
2. **Strongly-Typed Identifiers**:
   - Declared as `readonly record struct` (e.g., `UserId`, `EmployeeId`, `TicketId`, `ArticleId`, `InvoiceId`).
   - Prevents primitive obsession bugs (e.g., passing a `CustomerId` into a method expecting an `ArticleId`).
   - Converted to native GUIDs in SQLite/EF Core via dedicated `ValueConverter<TId, Guid>`.
3. **Immutability & Encapsulation**:
   - All state mutations are performed through intention-revealing methods (`ClockOut`, `AddComment`, `ReserveStock`, `IssueInvoice`).
   - All properties feature `private set` accessors.
   - Collections are exposed as `IReadOnlyCollection<T>` backed by private internal fields (`backingField`).
4. **Domain Invariant Exceptions**:
   - Invariants throw explicit domain exceptions (`DomainException`, `NegativeStockException`, `InvalidStateTransitionException`, `BusinessRuleValidationException`, `EntityNotFoundException`) instead of generic runtime exceptions.
5. **CQRS & Transaction Boundaries**:
   - Commands mutate single aggregate roots and return `Result` or `Result<T>`.
   - Queries perform efficient projections with `.AsNoTracking()`.
   - `IUnitOfWork` guarantees atomic persistence via EF Core `SaveChangesAsync`.

---

## 4. Phase 1 Deep-Dive Modules Specification

### 4.1 Identity & Access Management (IAM)
- **Aggregates**: `User`, `Role`, `UserRole`, `UserClaim`
- **Key Invariants**:
  - Email uniqueness and lower-case normalization.
  - Password hashing utilizing PBKDF2 with unique cryptographic salt per user.
  - Brute force protection: Account locks automatically after $N$ consecutive failed attempts for a configurable lockout duration.
  - Explicit activation, suspension, and unlock state machine.
- **CQRS Operations**:
  - `RegisterUserCommand`: Validates email format, enforces password complexity, hashes credentials, and persists user.
  - `AuthenticateUserCommand`: Verifies credentials, manages lockout counters, generates authentication tokens.
  - `GetUserByIdQuery`: Returns safe user profile projection.

### 4.2 Human Resources (HR)
- **Aggregates**: `Employee`
- **Key Invariants**:
  - Personal identification: First name, last name, normalized corporate email.
  - Contractual guardrails: Weekly contractual hours must be between $1.0$ and $60.0$.
  - Statutory compliance: Association with legal statutory regimes (e.g., Swiss LL / OLL 1 weekly maximums).
  - Lifecycle state: Active status toggle with audit trail.
- **CQRS Operations**:
  - `CreateEmployeeCommand`: Enforces non-duplicate email, sets initial contractual parameters.
  - `UpdateEmployeeContractCommand`: Validates hours and regulatory limits.
  - `GetEmployeeByIdQuery`: Project employee contract summary.

### 4.3 Time & Attendance (TimeAttendance)
- **Aggregates**: `TimeEntry`, `TimeCorrectionAudit`
- **Key Invariants**:
  - Clock-in creates an open entry with UTC timestamp and optional punctual GPS coordinates.
  - Clock-out requires: $\text{ClockOutUtc} > \text{ClockInUtc}$, $\text{BreakMinutes} \ge 0$, and $\text{BreakMinutes} < \text{TotalDurationMinutes}$.
  - Anomaly detection: Flags daily amplitude exceeding legal thresholds (e.g., $> 14$ hours) or insufficient rest periods between consecutive shifts ($< 11$ hours).
  - Regulatory audits: Any post-facto correction requires a mandatory legal justification and captures operator ID, old values, new values, and UTC timestamp.
- **CQRS Operations**:
  - `ClockInCommand`: Initiates a new shift punch.
  - `ClockOutCommand`: Finalizes punch, calculates break deductions and compliance flags.
  - `GetEmployeeTimeEntriesQuery`: Queries historical attendance for an employee across a date window.

### 4.4 Ticketing & Service Desk
- **Aggregates**: `Ticket`, `TicketComment`
- **Key Invariants**:
  - State machine: $\text{Open} \rightarrow \text{InProgress} \rightarrow \text{Resolved} \rightarrow \text{Closed}$. Can reopen from `Resolved` to `InProgress`.
  - Terminal state: `Closed` tickets are strictly immutable; any modification attempt throws `InvalidStateTransitionException`.
  - Resolution: Cannot transition to `Resolved` without documenting a non-empty resolution summary.
  - Dynamic SLAs: Response and resolution deadlines are automatically computed upon ticket creation based on `TicketPriority` (`Low`, `Medium`, `High`, `Urgent`).
  - Comments: Supports public client communications and internal technician-only notes.
- **CQRS Operations**:
  - `CreateTicketCommand`: Initializes ticket and schedules SLA targets.
  - `AssignTicketCommand`: Assigns responsible technician and transitions status.
  - `ResolveTicketCommand`: Enforces resolution notes and marks SLA completion.
  - `GetTicketByIdQuery`: Projects full ticket aggregate including comments and SLA metrics.

### 4.5 Inventory & Warehouse Management
- **Aggregates**: `Article`, `StockLocation`, `InventoryStock`, `InventoryMovement`
- **Key Invariants**:
  - Negative Stock Prevention: Available stock is defined as $\text{Available} = \text{Balance} - \text{Reserved}$. Any outbound transaction or reservation exceeding available quantity throws `NegativeStockException`.
  - Stock Reservations: Allocates inventory for pending sales or production orders without physical dispatch.
  - Movement Ledger: Every inventory change generates an immutable `InventoryMovement` record (`Inbound`, `Outbound`, `Transfer`, `Adjustment`).
  - Stock Location tracking: Multi-warehouse aisle/shelf routing.
- **CQRS Operations**:
  - `CreateArticleCommand`: Registers product SKU, pricing, and safety stock threshold.
  - `RecordStockMovementCommand`: Executes physical receipt, dispatch, or inter-warehouse transfer with concurrency control.
  - `GetArticleStockQuery`: Queries real-time stock balances across all locations.

### 4.6 Sales & Invoicing
- **Aggregates**: `Invoice`, `InvoiceLine`
- **Key Invariants**:
  - State machine: $\text{Draft} \rightarrow \text{Issued} \rightarrow (\text{Paid} \lor \text{Cancelled})$.
  - Immutability: Once `Issued`, lines cannot be added, removed, or modified.
  - Precision tax calculation:
    $$\text{Net} = \text{Quantity} \times \text{UnitPrice} \times \left(1 - \frac{\text{DiscountPercent}}{100}\right)$$
    $$\text{Vat} = \text{Net} \times \left(\frac{\text{VatRatePercent}}{100}\right)$$
    $$\text{Gross} = \text{Net} + \text{Vat}$$
  - Sequential Numbering: Invoices in `Draft` have no invoice number; upon issuance, a sequential, audit-compliant document number is allocated via `IInvoiceNumberSequenceService`.
  - Issue prerequisites: An invoice cannot be issued without at least one valid line item.
- **CQRS Operations**:
  - `CreateInvoiceCommand`: Generates draft invoice for a customer.
  - `AddInvoiceLineCommand`: Adds priced items with tax rates while in draft.
  - `IssueInvoiceCommand`: Finalizes totals, locks lines, and assigns sequential numbering.
  - `GetInvoiceByIdQuery`: Projects detailed invoice header and line breakdowns.

### 4.7 Content Management System (CMS)
- **Aggregates**: `Page`, `PageTag`
- **Key Invariants**:
  - Slug Normalization: Generates clean, lowercase, URL-safe slugs with hyphens (e.g., `Enterprise Architecture Guide` $\rightarrow$ `enterprise-architecture-guide`).
  - Publishing lifecycle: $\text{Draft} \rightarrow \text{Review} \rightarrow \text{Published} \rightarrow \text{Archived}$.
  - Publishing timestamp: `PublishedAtUtc` is captured when entering `Published` status.
  - SEO & Taxonomy: Encapsulates meta title, description, Open Graph attributes, and tagging.
- **CQRS Operations**:
  - `CreatePageCommand`: Drafts new page content and computes initial slug.
  - `PublishPageCommand`: Executes lifecycle transition to `Published`.
  - `GetPageBySlugQuery`: High-performance public read projection by URL slug.

---

## 5. Persistence, Concurrency & SQLite WAL Architecture

1. **Write-Ahead Logging (WAL) Mode**:
   - Enforced on all SQLite connections via connection interceptor:
     ```sql
     PRAGMA journal_mode = WAL;
     PRAGMA synchronous = NORMAL;
     PRAGMA busy_timeout = 5000;
     ```
   - Facilitates concurrent readers without blocking active writers.
2. **Audit Shadow Properties**:
   - Entities inheriting from domain base classes automatically maintain EF Core shadow properties:
     - `CreatedAt` (`DateTime`, UTC)
     - `CreatedBy` (`string`, max 255)
     - `LastModifiedAt` (`DateTime?`, UTC)
     - `LastModifiedBy` (`string?`, max 255)
3. **Encapsulated Collections**:
   - Configured via EF Core `UsePropertyAccessMode(PropertyAccessMode.Field)` ensuring ORM hydration populates backing fields without bypassing aggregate encapsulation.
4. **Strongly-Typed ID Conversions**:
   - Standardized EF Core `ValueConverter<TId, Guid>` configured across all entity configurations.

---

## 6. Testing & Quality Assurance Strategy

- **Zero-Warning Tolerance**: Builds enforce `TreatWarningsAsErrors=true`, Roslynator, StyleCop, and SonarAnalyzers.
- **Domain Invariant Unit Tests**: Test every aggregate state machine, boundary rejection, and calculation rule.
- **MediatR Pipeline Tests**: Verify request handlers, validation pipeline rejections, and repository interactions using `FluentAssertions` and `Moq`.
- **Test Naming Standard**: `MethodName_Condition_ExpectedBehavior`.
