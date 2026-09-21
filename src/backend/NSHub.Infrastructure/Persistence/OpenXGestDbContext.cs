// <copyright file="OpenXGestDbContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Common;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Persistence;

public class OpenXGestDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();
    public DbSet<TimeCorrectionAudit> TimeCorrectionAudits => Set<TimeCorrectionAudit>();

    // IAM
    public DbSet<NSHub.Domain.Identity.Entities.User> Users => Set<NSHub.Domain.Identity.Entities.User>();
    public DbSet<NSHub.Domain.Identity.Entities.Role> Roles => Set<NSHub.Domain.Identity.Entities.Role>();
    public DbSet<NSHub.Domain.Identity.Entities.UserRole> UserRoles => Set<NSHub.Domain.Identity.Entities.UserRole>();
    public DbSet<NSHub.Domain.Identity.Entities.UserClaim> UserClaims => Set<NSHub.Domain.Identity.Entities.UserClaim>();

    // Tickets
    public DbSet<NSHub.Domain.Tickets.Entities.Ticket> Tickets => Set<NSHub.Domain.Tickets.Entities.Ticket>();
    public DbSet<NSHub.Domain.Tickets.Entities.TicketComment> TicketComments => Set<NSHub.Domain.Tickets.Entities.TicketComment>();

    // Warehouse
    public DbSet<NSHub.Domain.Warehouse.Entities.Article> Articles => Set<NSHub.Domain.Warehouse.Entities.Article>();
    public DbSet<NSHub.Domain.Warehouse.Entities.StockLocation> StockLocations => Set<NSHub.Domain.Warehouse.Entities.StockLocation>();
    public DbSet<NSHub.Domain.Warehouse.Entities.InventoryStock> InventoryStocks => Set<NSHub.Domain.Warehouse.Entities.InventoryStock>();
    public DbSet<NSHub.Domain.Warehouse.Entities.InventoryMovement> InventoryMovements => Set<NSHub.Domain.Warehouse.Entities.InventoryMovement>();

    // Invoicing
    public DbSet<NSHub.Domain.Invoicing.Entities.Invoice> Invoices => Set<NSHub.Domain.Invoicing.Entities.Invoice>();
    public DbSet<NSHub.Domain.Invoicing.Entities.InvoiceLine> InvoiceLines => Set<NSHub.Domain.Invoicing.Entities.InvoiceLine>();

    // CMS
    public DbSet<NSHub.Domain.Cms.Entities.Page> CmsPages => Set<NSHub.Domain.Cms.Entities.Page>();
    public DbSet<NSHub.Domain.Cms.Entities.PageTag> CmsPageTags => Set<NSHub.Domain.Cms.Entities.PageTag>();

    public OpenXGestDbContext(DbContextOptions<OpenXGestDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Applica le configurazioni Fluent API
        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Aggiunge shadow properties per tutte le entità che derivano da BaseEntity
        foreach (var clrType in modelBuilder.Model.GetEntityTypes()
                     .Select(t => t.ClrType)
                     .Where(t => typeof(BaseEntity).IsAssignableFrom(t)))
        {
            _ = modelBuilder.Entity(clrType)
                .Property<DateTime>("CreatedAt")
                .IsRequired();

            _ = modelBuilder.Entity(clrType)
                .Property<string>("CreatedBy")
                .HasMaxLength(255)
                .IsRequired();

            _ = modelBuilder.Entity(clrType)
                .Property<DateTime?>("LastModifiedAt");

            _ = modelBuilder.Entity(clrType)
                .Property<string?>("LastModifiedBy")
                .HasMaxLength(255);
        }
    }
}
