// <copyright file="IApplicationDbContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Entities;

namespace NSHub.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Address> Addresses { get; }
    DbSet<AddressType> AddressTypes { get; }
    DbSet<AgreementType> AgreementTypes { get; }
    DbSet<Article> Articles { get; }
    DbSet<ArticleBrand> ArticleBrands { get; }
    DbSet<ArticleCategory> ArticleCategories { get; }
    DbSet<ArticleCategoryMap> ArticleCategoryMaps { get; }
    DbSet<ArticleGroup> ArticleGroups { get; }
    DbSet<ArticleGroupMap> ArticleGroupMaps { get; }
    DbSet<ArticleGroupType> ArticleGroupTypes { get; }
    DbSet<ArticleMachine> ArticleMachines { get; }
    DbSet<ArticleType> ArticleTypes { get; }
    DbSet<AspNetRoleClaims> AspNetRoleClaimses { get; }
    DbSet<AspNetRoles> AspNetRoleses { get; }
    DbSet<AspNetUserClaims> AspNetUserClaimses { get; }
    DbSet<AspNetUserLogins> AspNetUserLoginses { get; }
    DbSet<AspNetUserPasskeys> AspNetUserPasskeyses { get; }
    DbSet<AspNetUserRoles> AspNetUserRoleses { get; }
    DbSet<AspNetUsers> AspNetUserses { get; }
    DbSet<AspNetUserTokens> AspNetUserTokenses { get; }
    DbSet<Bank> Banks { get; }
    DbSet<BankAccount> BankAccounts { get; }
    DbSet<Brand> Brands { get; }
    DbSet<CashBook> CashBooks { get; }
    DbSet<CncError> CncErrors { get; }
    DbSet<ContactChannelType> ContactChannelTypes { get; }
    DbSet<ContactMechanism> ContactMechanisms { get; }
    DbSet<Courier> Couriers { get; }
    DbSet<Customer> Customers { get; }
    DbSet<DeliveryNote> DeliveryNotes { get; }
    DbSet<DeliveryNoteRow> DeliveryNoteRows { get; }
    DbSet<DncText> DncTexts { get; }
    DbSet<Document> Documents { get; }
    DbSet<DocumentGroup> DocumentGroups { get; }
    DbSet<DocumentType> DocumentTypes { get; }
    DbSet<Dressing1> Dressing1s { get; }
    DbSet<Dressing2> Dressing2s { get; }
    DbSet<Dressing3> Dressing3s { get; }
    DbSet<DressingName1> DressingName1s { get; }
    DbSet<DressingName2> DressingName2s { get; }
    DbSet<DressingName3> DressingName3s { get; }
    DbSet<Employee> Employees { get; }
    DbSet<FxText> FxTexts { get; }
    DbSet<FxTextType> FxTextTypes { get; }
    DbSet<Intervention> Interventions { get; }
    DbSet<InterventionAttachment> InterventionAttachments { get; }
    DbSet<InterventionUser> InterventionUsers { get; }
    DbSet<Invoice> Invoices { get; }
    DbSet<InvoiceRow> InvoiceRows { get; }
    DbSet<InvoiceType> InvoiceTypes { get; }
    DbSet<Language> Languages { get; }
    DbSet<Machine> Machines { get; }
    DbSet<MachineAxisEncoder> MachineAxisEncoders { get; }
    DbSet<MachineBuilder> MachineBuilders { get; }
    DbSet<MachineEvent> MachineEvents { get; }
    DbSet<MachineEventType> MachineEventTypes { get; }
    DbSet<MachineMechanicalAssembly> MachineMechanicalAssemblies { get; }
    DbSet<MachineMotor> MachineMotors { get; }
    DbSet<MachinePlcVariable> MachinePlcVariables { get; }
    DbSet<MachineScrew> MachineScrews { get; }
    DbSet<MachineType> MachineTypes { get; }
    DbSet<MonthlyCost> MonthlyCosts { get; }
    DbSet<Nation> Nations { get; }
    DbSet<Nck> Ncks { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderRow> OrderRows { get; }
    DbSet<Organization> Organizations { get; }
    DbSet<Party> Parties { get; }
    DbSet<PartyRelationship> PartyRelationships { get; }
    DbSet<PartyType> PartyTypes { get; }
    DbSet<Payment> Payments { get; }
    DbSet<PaymentSchedule> PaymentSchedules { get; }
    DbSet<Person> Persons { get; }
    DbSet<PlcType> PlcTypes { get; }
    DbSet<PlcVariable> PlcVariables { get; }
    DbSet<PlcVariableGroupType> PlcVariableGroupTypes { get; }
    DbSet<PlcVariableType> PlcVariableTypes { get; }
    DbSet<PriceList> PriceLists { get; }
    DbSet<PriceListItem> PriceListItems { get; }
    DbSet<Quotation> Quotations { get; }
    DbSet<QuotationRow> QuotationRows { get; }
    DbSet<RelationshipType> RelationshipTypes { get; }
    DbSet<RuntimeSystem> RuntimeSystems { get; }
    DbSet<Setting> Settings { get; }
    DbSet<Shipment> Shipments { get; }
    DbSet<ShipmentArticle> ShipmentArticles { get; }
    DbSet<StockMovement> StockMovements { get; }
    DbSet<Supplier> Suppliers { get; }
    DbSet<SystemBootMessage> SystemBootMessages { get; }
    DbSet<Tenant> Tenants { get; }
    DbSet<Ticket> Tickets { get; }
    DbSet<TicketComment> TicketComments { get; }
    DbSet<TicketIntervention> TicketInterventions { get; }
    DbSet<TicketShipment> TicketShipments { get; }
    DbSet<TicketStatus> TicketStatuses { get; }
    DbSet<TicketStatusType> TicketStatusTypes { get; }
    DbSet<TimeEntry> TimeEntries { get; }
    DbSet<TimeTrackingAgreement> TimeTrackingAgreements { get; }
    DbSet<TransportCareDeliveryNote> TransportCareDeliveryNotes { get; }
    DbSet<TransportReasonDeliveryNote> TransportReasonDeliveryNotes { get; }
    DbSet<UnitOfMeasure> UnitOfMeasures { get; }
    DbSet<User> Users { get; }
    DbSet<Vat> Vats { get; }
    DbSet<Warehouse> Warehouses { get; }
    DbSet<WarehouseOrganization> WarehouseOrganizations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
