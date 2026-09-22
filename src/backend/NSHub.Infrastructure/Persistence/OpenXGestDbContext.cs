// <copyright file="OpenXGestDbContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Common;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Persistence;

/// <summary>
/// Core database context for business domain entities across HR, IAM, Tickets, Warehouse, Invoicing, and CMS.
/// </summary>
public class OpenXGestDbContext : DbContext
{
    /// <summary>
    /// Gets the database set for employees.
    /// </summary>
    public DbSet<Employee> Employees => Set<Employee>();

    /// <summary>
    /// Gets the database set for time entries.
    /// </summary>
    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();

    /// <summary>
    /// Gets the database set for time correction audit logs.
    /// </summary>
    public DbSet<TimeCorrectionAudit> TimeCorrectionAudits => Set<TimeCorrectionAudit>();

    // IAM
    /// <summary>
    /// Gets the database set for IAM users.
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    /// Gets the database set for IAM roles.
    /// </summary>
    public DbSet<Role> Roles => Set<Role>();

    /// <summary>
    /// Gets the database set for IAM user roles.
    /// </summary>
    public DbSet<UserRole> UserRoles => Set<UserRole>();

    /// <summary>
    /// Gets the database set for IAM user claims.
    /// </summary>
    public DbSet<UserClaim> UserClaims => Set<UserClaim>();

    // Tickets
    /// <summary>
    /// Gets the database set for tickets.
    /// </summary>
    public DbSet<Ticket> Tickets => Set<Ticket>();

    /// <summary>
    /// Gets the database set for ticket comments.
    /// </summary>
    public DbSet<TicketComment> TicketComments => Set<TicketComment>();

    // Warehouse
    /// <summary>
    /// Gets the database set for warehouse articles.
    /// </summary>
    public DbSet<NSHub.Domain.Warehouse.Entities.Article> Articles => Set<NSHub.Domain.Warehouse.Entities.Article>();

    /// <summary>
    /// Gets the database set for warehouse stock locations.
    /// </summary>
    public DbSet<StockLocation> StockLocations => Set<StockLocation>();

    /// <summary>
    /// Gets the database set for warehouse inventory stocks.
    /// </summary>
    public DbSet<InventoryStock> InventoryStocks => Set<InventoryStock>();

    /// <summary>
    /// Gets the database set for warehouse inventory movements.
    /// </summary>
    public DbSet<InventoryMovement> InventoryMovements => Set<InventoryMovement>();

    // Invoicing
    /// <summary>
    /// Gets the database set for invoices.
    /// </summary>
    public DbSet<Invoice> Invoices => Set<Invoice>();

    /// <summary>
    /// Gets the database set for invoice lines.
    /// </summary>
    public DbSet<InvoiceLine> InvoiceLines => Set<InvoiceLine>();

    // CMS
    /// <summary>
    /// Gets the database set for CMS pages.
    /// </summary>
    public DbSet<Page> CmsPages => Set<Page>();

    /// <summary>
    /// Gets the database set for CMS page tags.
    /// </summary>
    public DbSet<PageTag> CmsPageTags => Set<PageTag>();

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenXGestDbContext"/> class.
    /// </summary>
    /// <param name="options">The database context options.</param>
    public OpenXGestDbContext(DbContextOptions<OpenXGestDbContext> options) : base(options)
    {
    }

    /// <inheritdoc/>
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
