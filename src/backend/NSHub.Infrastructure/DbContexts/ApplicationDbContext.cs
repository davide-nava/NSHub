// <copyright file="ApplicationDbContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.DbContexts;

/// <summary>
/// Unified database context for application entities and identity management.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
/// </remarks>
/// <param name="options">The database context options.</param>
/// <param name="logger">The logger instance.</param>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger) :
    IdentityDbContext<IdentityUser>(options)
{

    /// <summary>
    /// Gets or sets the database set for addresses.
    /// </summary>
    public DbSet<Address> Addresses => Set<Address>();

    /// <summary>
    /// Gets or sets the database set for address types.
    /// </summary>
    public DbSet<AddressType> AddressTypes => Set<AddressType>();

    /// <summary>
    /// Gets or sets the database set for agreement types.
    /// </summary>
    public DbSet<AgreementType> AgreementTypes => Set<AgreementType>();

    /// <summary>
    /// Gets or sets the database set for articles.
    /// </summary>
    public DbSet<Article> Articles => Set<Article>();

/// <summary>
/// Gets or sets the database set for article brands.
/// </summary>
    public DbSet<ArticleBrand> ArticleBrands => Set<ArticleBrand>();

/// <summary>
/// Gets or sets the database set for article categories.
/// </summary>
    public DbSet<ArticleCategory> ArticleCategories => Set<ArticleCategory>();

/// <summary>
/// Gets or sets the database set for article category mappings.
/// </summary>
    public DbSet<ArticleCategoryMap> ArticleCategoryMaps => Set<ArticleCategoryMap>();

/// <summary>
/// Gets or sets the database set for article groups.
/// </summary>
    public DbSet<ArticleGroup> ArticleGroups => Set<ArticleGroup>();

    public DbSet<ArticleGroupMap> ArticleGroupMaps => Set<ArticleGroupMap>();

    public DbSet<ArticleGroupType> ArticleGroupTypes => Set<ArticleGroupType>();

    public DbSet<ArticleMachine> ArticleMachines => Set<ArticleMachine>();

    public DbSet<ArticleType> ArticleTypes => Set<ArticleType>();

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

    public new DbSet<User> Users => Set<User>();

    public DbSet<Vat> Vats => Set<Vat>();

    public DbSet<Warehouse> Warehouses => Set<Warehouse>();

    /// <summary>
    /// Gets or sets the database set for warehouse organizations.
    /// </summary>
    public DbSet<WarehouseOrganization> WarehouseOrganizations => Set<WarehouseOrganization>();

    /// <summary>
    /// Configures the model by applying entity configurations from the specified assemblies.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    /// <exception cref="ArgumentNullException">Thrown when the builder is null.</exception>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        _ = builder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);
        _ = builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(builder);
    }

    /// <summary>
    /// Configures the database context options, enabling detailed errors and logging actions to the provided logger.
    /// </summary>
    /// <param name="optionsBuilder">The database context options builder.</param>
    /// <exception cref="ArgumentNullException">Thrown when the options builder is null.</exception>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder);

        _ = optionsBuilder.LogTo(action =>
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError("{Action}", action);
            }
        })
            .EnableDetailedErrors();

        base.OnConfiguring(optionsBuilder);
    }

    /// <summary>
    /// Configures the conventions for the model, setting the precision for decimal properties to 18 digits with 6 decimal places.
    /// </summary>
    /// <param name="configurationBuilder">The model configuration builder.</param>
    /// <exception cref="ArgumentNullException">Thrown when the configuration builder is null.</exception>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        ArgumentNullException.ThrowIfNull(configurationBuilder);
        _ = configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}
