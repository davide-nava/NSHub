// <copyright file="ApplicationDbContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Models;
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
    IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options), IApplicationDbContext
{
    /// <inheritdoc/>
    public DbSet<Address> Addresses => Set<Address>();

    /// <inheritdoc/>
    public DbSet<AddressType> AddressTypes => Set<AddressType>();

    /// <inheritdoc/>
    public DbSet<AgreementType> AgreementTypes => Set<AgreementType>();

    /// <inheritdoc/>
    public DbSet<Article> Articles => Set<Article>();

    /// <inheritdoc/>
    public DbSet<ArticleBrand> ArticleBrands => Set<ArticleBrand>();

    /// <inheritdoc/>
    public DbSet<ArticleCategory> ArticleCategories => Set<ArticleCategory>();

    /// <inheritdoc/>
    public DbSet<ArticleCategoryMap> ArticleCategoryMaps => Set<ArticleCategoryMap>();

    /// <inheritdoc/>
    public DbSet<ArticleGroup> ArticleGroups => Set<ArticleGroup>();

    /// <inheritdoc/>
    public DbSet<ArticleGroupMap> ArticleGroupMaps => Set<ArticleGroupMap>();

    /// <inheritdoc/>
    public DbSet<ArticleGroupType> ArticleGroupTypes => Set<ArticleGroupType>();

    /// <inheritdoc/>
    public DbSet<ArticleMachine> ArticleMachines => Set<ArticleMachine>();

    /// <inheritdoc/>
    public DbSet<ArticleType> ArticleTypes => Set<ArticleType>();

    /// <inheritdoc/>
    public DbSet<AspNetRoleClaims> AspNetRoleClaimses => Set<AspNetRoleClaims>();

    /// <inheritdoc/>
    public DbSet<AspNetRoles> AspNetRoleses => Set<AspNetRoles>();

    /// <inheritdoc/>
    public DbSet<AspNetUserClaims> AspNetUserClaimses => Set<AspNetUserClaims>();

    /// <inheritdoc/>
    public DbSet<AspNetUserLogins> AspNetUserLoginses => Set<AspNetUserLogins>();

    /// <inheritdoc/>
    public DbSet<AspNetUserPasskeys> AspNetUserPasskeyses => Set<AspNetUserPasskeys>();

    /// <inheritdoc/>
    public DbSet<AspNetUserRoles> AspNetUserRoleses => Set<AspNetUserRoles>();

    /// <inheritdoc/>
    public DbSet<AspNetUsers> AspNetUserses => Set<AspNetUsers>();

    /// <inheritdoc/>
    public DbSet<AspNetUserTokens> AspNetUserTokenses => Set<AspNetUserTokens>();

    /// <inheritdoc/>
    public DbSet<Bank> Banks => Set<Bank>();

    /// <inheritdoc/>
    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();

    /// <inheritdoc/>
    public DbSet<Brand> Brands => Set<Brand>();

    /// <inheritdoc/>
    public DbSet<CashBook> CashBooks => Set<CashBook>();

    /// <inheritdoc/>
    public DbSet<CncError> CncErrors => Set<CncError>();

    /// <inheritdoc/>
    public DbSet<ContactChannelType> ContactChannelTypes => Set<ContactChannelType>();

    /// <inheritdoc/>
    public DbSet<ContactMechanism> ContactMechanisms => Set<ContactMechanism>();

    /// <inheritdoc/>
    public DbSet<Courier> Couriers => Set<Courier>();

    /// <inheritdoc/>
    public DbSet<Customer> Customers => Set<Customer>();

    /// <inheritdoc/>
    public DbSet<DeliveryNote> DeliveryNotes => Set<DeliveryNote>();

    /// <inheritdoc/>
    public DbSet<DeliveryNoteRow> DeliveryNoteRows => Set<DeliveryNoteRow>();

    /// <inheritdoc/>
    public DbSet<DncText> DncTexts => Set<DncText>();

    /// <inheritdoc/>
    public DbSet<Document> Documents => Set<Document>();

    /// <inheritdoc/>
    public DbSet<DocumentGroup> DocumentGroups => Set<DocumentGroup>();

    /// <inheritdoc/>
    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();

    /// <inheritdoc/>
    public DbSet<Dressing1> Dressing1s => Set<Dressing1>();

    /// <inheritdoc/>
    public DbSet<Dressing2> Dressing2s => Set<Dressing2>();

    /// <inheritdoc/>
    public DbSet<Dressing3> Dressing3s => Set<Dressing3>();

    /// <inheritdoc/>
    public DbSet<DressingName1> DressingName1s => Set<DressingName1>();

    /// <inheritdoc/>
    public DbSet<DressingName2> DressingName2s => Set<DressingName2>();

    /// <inheritdoc/>
    public DbSet<DressingName3> DressingName3s => Set<DressingName3>();

    /// <inheritdoc/>
    public DbSet<Employee> Employees => Set<Employee>();

    /// <inheritdoc/>
    public DbSet<FxText> FxTexts => Set<FxText>();

    /// <inheritdoc/>
    public DbSet<FxTextType> FxTextTypes => Set<FxTextType>();

    /// <inheritdoc/>
    public DbSet<Intervention> Interventions => Set<Intervention>();

    /// <inheritdoc/>
    public DbSet<InterventionAttachment> InterventionAttachments => Set<InterventionAttachment>();

    /// <inheritdoc/>
    public DbSet<InterventionUser> InterventionUsers => Set<InterventionUser>();

    /// <inheritdoc/>
    public DbSet<Invoice> Invoices => Set<Invoice>();

    /// <inheritdoc/>
    public DbSet<InvoiceRow> InvoiceRows => Set<InvoiceRow>();

    /// <inheritdoc/>
    public DbSet<InvoiceType> InvoiceTypes => Set<InvoiceType>();

    /// <inheritdoc/>
    public DbSet<Language> Languages => Set<Language>();

    /// <inheritdoc/>
    public DbSet<Machine> Machines => Set<Machine>();

    /// <inheritdoc/>
    public DbSet<MachineAxisEncoder> MachineAxisEncoders => Set<MachineAxisEncoder>();

    /// <inheritdoc/>
    public DbSet<MachineBuilder> MachineBuilders => Set<MachineBuilder>();

    /// <inheritdoc/>
    public DbSet<MachineEvent> MachineEvents => Set<MachineEvent>();

    /// <inheritdoc/>
    public DbSet<MachineEventType> MachineEventTypes => Set<MachineEventType>();

    /// <inheritdoc/>
    public DbSet<MachineMechanicalAssembly> MachineMechanicalAssemblies => Set<MachineMechanicalAssembly>();

    /// <inheritdoc/>
    public DbSet<MachineMotor> MachineMotors => Set<MachineMotor>();

    /// <inheritdoc/>
    public DbSet<MachinePlcVariable> MachinePlcVariables => Set<MachinePlcVariable>();

    /// <inheritdoc/>
    public DbSet<MachineScrew> MachineScrews => Set<MachineScrew>();

    /// <inheritdoc/>
    public DbSet<MachineType> MachineTypes => Set<MachineType>();

    /// <inheritdoc/>
    public DbSet<MonthlyCost> MonthlyCosts => Set<MonthlyCost>();

    /// <inheritdoc/>
    public DbSet<Nation> Nations => Set<Nation>();

    /// <inheritdoc/>
    public DbSet<Nck> Ncks => Set<Nck>();

    /// <inheritdoc/>
    public DbSet<Order> Orders => Set<Order>();

    /// <inheritdoc/>
    public DbSet<OrderRow> OrderRows => Set<OrderRow>();

    /// <inheritdoc/>
    public DbSet<Organization> Organizations => Set<Organization>();

    /// <inheritdoc/>
    public DbSet<Party> Parties => Set<Party>();

    /// <inheritdoc/>
    public DbSet<PartyRelationship> PartyRelationships => Set<PartyRelationship>();

    /// <inheritdoc/>
    public DbSet<PartyType> PartyTypes => Set<PartyType>();

    /// <inheritdoc/>
    public DbSet<Payment> Payments => Set<Payment>();

    /// <inheritdoc/>
    public DbSet<PaymentSchedule> PaymentSchedules => Set<PaymentSchedule>();

    /// <inheritdoc/>
    public DbSet<Person> Persons => Set<Person>();

    /// <inheritdoc/>
    public DbSet<PlcType> PlcTypes => Set<PlcType>();

    /// <inheritdoc/>
    public DbSet<PlcVariable> PlcVariables => Set<PlcVariable>();

    /// <inheritdoc/>
    public DbSet<PlcVariableGroupType> PlcVariableGroupTypes => Set<PlcVariableGroupType>();

    /// <inheritdoc/>
    public DbSet<PlcVariableType> PlcVariableTypes => Set<PlcVariableType>();

    /// <inheritdoc/>
    public DbSet<PriceList> PriceLists => Set<PriceList>();

    /// <inheritdoc/>
    public DbSet<PriceListItem> PriceListItems => Set<PriceListItem>();

    /// <inheritdoc/>
    public DbSet<Quotation> Quotations => Set<Quotation>();

    /// <inheritdoc/>
    public DbSet<QuotationRow> QuotationRows => Set<QuotationRow>();

    /// <inheritdoc/>
    public DbSet<RelationshipType> RelationshipTypes => Set<RelationshipType>();

    /// <inheritdoc/>
    public DbSet<RuntimeSystem> RuntimeSystems => Set<RuntimeSystem>();

    /// <inheritdoc/>
    public DbSet<Setting> Settings => Set<Setting>();

    /// <inheritdoc/>
    public DbSet<Shipment> Shipments => Set<Shipment>();

    /// <inheritdoc/>
    public DbSet<ShipmentArticle> ShipmentArticles => Set<ShipmentArticle>();

    /// <inheritdoc/>
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();

    /// <inheritdoc/>
    public DbSet<Supplier> Suppliers => Set<Supplier>();

    /// <inheritdoc/>
    public DbSet<SystemBootMessage> SystemBootMessages => Set<SystemBootMessage>();

    /// <inheritdoc/>
    public DbSet<Tenant> Tenants => Set<Tenant>();

    /// <inheritdoc/>
    public DbSet<Ticket> Tickets => Set<Ticket>();

    /// <inheritdoc/>
    public DbSet<TicketComment> TicketComments => Set<TicketComment>();

    /// <inheritdoc/>
    public DbSet<TicketIntervention> TicketInterventions => Set<TicketIntervention>();

    /// <inheritdoc/>
    public DbSet<TicketShipment> TicketShipments => Set<TicketShipment>();

    /// <inheritdoc/>
    public DbSet<TicketStatus> TicketStatuses => Set<TicketStatus>();

    /// <inheritdoc/>
    public DbSet<TicketStatusType> TicketStatusTypes => Set<TicketStatusType>();

    /// <inheritdoc/>
    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();

    /// <inheritdoc/>
    public DbSet<TimeTrackingAgreement> TimeTrackingAgreements => Set<TimeTrackingAgreement>();

    /// <inheritdoc/>
    public DbSet<TransportCareDeliveryNote> TransportCareDeliveryNotes => Set<TransportCareDeliveryNote>();

    /// <inheritdoc/>
    public DbSet<TransportReasonDeliveryNote> TransportReasonDeliveryNotes => Set<TransportReasonDeliveryNote>();

    /// <inheritdoc/>
    public DbSet<UnitOfMeasure> UnitOfMeasures => Set<UnitOfMeasure>();

    /// <inheritdoc/>
    public new DbSet<User> Users => Set<User>();

    /// <inheritdoc/>
    public DbSet<Vat> Vats => Set<Vat>();

    /// <inheritdoc/>
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();

    /// <inheritdoc/>
    public DbSet<WarehouseOrganization> WarehouseOrganizations => Set<WarehouseOrganization>();

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        _ = builder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);
        _ = builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(builder);
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        ArgumentNullException.ThrowIfNull(configurationBuilder);
        _ = configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}

