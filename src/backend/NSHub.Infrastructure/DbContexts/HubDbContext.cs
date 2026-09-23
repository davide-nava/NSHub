// <copyright file="TenantDbContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using NSHub.Application.Entities;

namespace NSHub.Infrastructure.DbContexts;

/// <summary>
/// Multi-tenant database context for system entities including tenants, settings, languages, and notifications.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="TenantDbContext"/> class.
/// </remarks>
/// <param name="options">The database context options.</param>
/// <param name="logger">The logger instance.</param>
public class TenantDbContext(DbContextOptions<TenantDbContext> options, ILogger logger) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the database set for languages.
    /// </summary>
    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    /// <summary>
    /// Gets or sets the database set for settings.
    /// </summary>
    public virtual DbSet<Setting> Settings { get; set; }

    /// <summary>
    /// Gets or sets the database set for users.
    /// </summary>
    public virtual DbSet<User> Users { get; set; }

    /// <summary>
    /// Gets or sets the database set for notifications.
    /// </summary>
    public virtual DbSet<Notification> Notifications { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ArgumentNullException.ThrowIfNull(optionsBuilder);

        _ = optionsBuilder.LogTo(
            action =>
            {
                if (logger.IsEnabled(LogLevel.Error))
                {
                    logger.LogError("{Action}", action);
                }
            })
            .EnableDetailedErrors()
            .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        //.EnableSensitiveDataLogging()

        base.OnConfiguring(optionsBuilder);
    }

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        _ = configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}
