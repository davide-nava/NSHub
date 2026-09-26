using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Common;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Persistence.Interceptors;

namespace NSHub.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor;

    public Guid? CurrentTenantId => _currentUserService.TenantId;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ICurrentUserService currentUserService,
        AuditableEntitySaveChangesInterceptor auditableInterceptor)
        : base(options)
    {
        _currentUserService = currentUserService;
        _auditableInterceptor = auditableInterceptor;
    }

    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<AddressType> AddressTypes => Set<AddressType>();
    public DbSet<AgreementType> AgreementTypes => Set<AgreementType>();
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<ArticleBrand> ArticleBrands => Set<ArticleBrand>();
    public DbSet<ArticleCategory> ArticleCategories => Set<ArticleCategory>();
    public DbSet<ArticleCategoryMap> ArticleCategoryMaps => Set<ArticleCategoryMap>();
    public DbSet<ArticleGroup> ArticleGroups => Set<ArticleGroup>();
    public DbSet<ArticleGroupMap> ArticleGroupMaps => Set<ArticleGroupMap>();
    public DbSet<ArticleGroupType> ArticleGroupTypes => Set<ArticleGroupType>();
    public DbSet<ArticleMachine> ArticleMachines => Set<ArticleMachine>();
    public DbSet<ArticleType> ArticleTypes => Set<ArticleType>();
    public DbSet<AspNetRoleClaims> AspNetRoleClaimses => Set<AspNetRoleClaims>();
    public DbSet<AspNetRoles> AspNetRoleses => Set<AspNetRoles>();
    public DbSet<AspNetUserClaims> AspNetUserClaimses => Set<AspNetUserClaims>();
    public DbSet<AspNetUserLogins> AspNetUserLoginses => Set<AspNetUserLogins>();
    public DbSet<AspNetUserPasskeys> AspNetUserPasskeyses => Set<AspNetUserPasskeys>();
    public DbSet<AspNetUserRoles> AspNetUserRoleses => Set<AspNetUserRoles>();
    public DbSet<AspNetUsers> AspNetUserses => Set<AspNetUsers>();
    public DbSet<AspNetUserTokens> AspNetUserTokenses => Set<AspNetUserTokens>();
    public DbSet<Bank> Banks => Set<Bank>();
    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<CashBook> CashBooks => Set<CashBook>();
    public DbSet<CncError> CncErrors => Set<CncError>();
    public DbSet<ContactChannelType> ContactChannelTypes => Set<ContactChannelType>();
    public DbSet<ContactMechanism> ContactMechanisms => Set<ContactMechanism>();
    public DbSet<Courier> Couriers => Set<Courier>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<DeliveryNote> DeliveryNotes => Set<DeliveryNote>();
    public DbSet<DeliveryNoteRow> DeliveryNoteRows => Set<DeliveryNoteRow>();
    public DbSet<DncText> DncTexts => Set<DncText>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<DocumentGroup> DocumentGroups => Set<DocumentGroup>();
    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
    public DbSet<Dressing1> Dressing1s => Set<Dressing1>();
    public DbSet<Dressing2> Dressing2s => Set<Dressing2>();
    public DbSet<Dressing3> Dressing3s => Set<Dressing3>();
    public DbSet<DressingName1> DressingName1s => Set<DressingName1>();
    public DbSet<DressingName2> DressingName2s => Set<DressingName2>();
    public DbSet<DressingName3> DressingName3s => Set<DressingName3>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<FxText> FxTexts => Set<FxText>();
    public DbSet<FxTextType> FxTextTypes => Set<FxTextType>();
    public DbSet<Intervention> Interventions => Set<Intervention>();
    public DbSet<InterventionAttachment> InterventionAttachments => Set<InterventionAttachment>();
    public DbSet<InterventionUser> InterventionUsers => Set<InterventionUser>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceRow> InvoiceRows => Set<InvoiceRow>();
    public DbSet<InvoiceType> InvoiceTypes => Set<InvoiceType>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Machine> Machines => Set<Machine>();
    public DbSet<MachineAxisEncoder> MachineAxisEncoders => Set<MachineAxisEncoder>();
    public DbSet<MachineBuilder> MachineBuilders => Set<MachineBuilder>();
    public DbSet<MachineEvent> MachineEvents => Set<MachineEvent>();
    public DbSet<MachineEventType> MachineEventTypes => Set<MachineEventType>();
    public DbSet<MachineMechanicalAssembly> MachineMechanicalAssemblies => Set<MachineMechanicalAssembly>();
    public DbSet<MachineMotor> MachineMotors => Set<MachineMotor>();
    public DbSet<MachinePlcVariable> MachinePlcVariables => Set<MachinePlcVariable>();
    public DbSet<MachineScrew> MachineScrews => Set<MachineScrew>();
    public DbSet<MachineType> MachineTypes => Set<MachineType>();
    public DbSet<MonthlyCost> MonthlyCosts => Set<MonthlyCost>();
    public DbSet<Nation> Nations => Set<Nation>();
    public DbSet<Nck> Ncks => Set<Nck>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderRow> OrderRows => Set<OrderRow>();
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<Party> Parties => Set<Party>();
    public DbSet<PartyRelationship> PartyRelationships => Set<PartyRelationship>();
    public DbSet<PartyType> PartyTypes => Set<PartyType>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<PaymentSchedule> PaymentSchedules => Set<PaymentSchedule>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<PlcType> PlcTypes => Set<PlcType>();
    public DbSet<PlcVariable> PlcVariables => Set<PlcVariable>();
    public DbSet<PlcVariableGroupType> PlcVariableGroupTypes => Set<PlcVariableGroupType>();
    public DbSet<PlcVariableType> PlcVariableTypes => Set<PlcVariableType>();
    public DbSet<PriceList> PriceLists => Set<PriceList>();
    public DbSet<PriceListItem> PriceListItems => Set<PriceListItem>();
    public DbSet<Quotation> Quotations => Set<Quotation>();
    public DbSet<QuotationRow> QuotationRows => Set<QuotationRow>();
    public DbSet<RelationshipType> RelationshipTypes => Set<RelationshipType>();
    public DbSet<RuntimeSystem> RuntimeSystems => Set<RuntimeSystem>();
    public DbSet<Setting> Settings => Set<Setting>();
    public DbSet<Shipment> Shipments => Set<Shipment>();
    public DbSet<ShipmentArticle> ShipmentArticles => Set<ShipmentArticle>();
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<SystemBootMessage> SystemBootMessages => Set<SystemBootMessage>();
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<TicketComment> TicketComments => Set<TicketComment>();
    public DbSet<TicketIntervention> TicketInterventions => Set<TicketIntervention>();
    public DbSet<TicketShipment> TicketShipments => Set<TicketShipment>();
    public DbSet<TicketStatus> TicketStatuses => Set<TicketStatus>();
    public DbSet<TicketStatusType> TicketStatusTypes => Set<TicketStatusType>();
    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();
    public DbSet<TimeTrackingAgreement> TimeTrackingAgreements => Set<TimeTrackingAgreement>();
    public DbSet<TransportCareDeliveryNote> TransportCareDeliveryNotes => Set<TransportCareDeliveryNote>();
    public DbSet<TransportReasonDeliveryNote> TransportReasonDeliveryNotes => Set<TransportReasonDeliveryNote>();
    public DbSet<UnitOfMeasure> UnitOfMeasures => Set<UnitOfMeasure>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Vat> Vats => Set<Vat>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<WarehouseOrganization> WarehouseOrganizations => Set<WarehouseOrganization>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Configure Global Query Filters for Soft Delete and Multi-Tenancy
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;
            var parameter = Expression.Parameter(clrType, "e");
            Expression? filter = null;

            if (typeof(ISoftDeletable).IsAssignableFrom(clrType))
            {
                var dateDeleteProp = Expression.Property(parameter, nameof(ISoftDeletable.DateDelete));
                var nullConst = Expression.Constant(null, typeof(DateTime?));
                filter = Expression.Equal(dateDeleteProp, nullConst);
            }

            if (typeof(ITenantEntity).IsAssignableFrom(clrType))
            {
                var tenantProp = Expression.Property(parameter, nameof(ITenantEntity.TenantId));
                var currentTenantExpr = Expression.Property(Expression.Constant(this), nameof(CurrentTenantId));
                var hasTenantCheck = Expression.Property(currentTenantExpr, nameof(Nullable<Guid>.HasValue));
                var notHasTenant = Expression.Not(hasTenantCheck);
                var tenantEquals = Expression.Equal(tenantProp, currentTenantExpr);
                var tenantFilter = Expression.OrElse(notHasTenant, tenantEquals);

                filter = filter == null ? tenantFilter : Expression.AndAlso(filter, tenantFilter);
            }

            if (filter != null)
            {
                var lambda = Expression.Lambda(filter, parameter);
                modelBuilder.Entity(clrType).HasQueryFilter(lambda);
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}
