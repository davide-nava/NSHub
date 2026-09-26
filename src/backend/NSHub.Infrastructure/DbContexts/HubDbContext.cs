// <copyright file="HubDbContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.DbContexts;

/// <summary>
/// Multi-tenant database context for system entities including tenants, settings, languages, and users.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="TenantDbContext"/> class.
/// </remarks>
/// <param name="options">The database context options.</param>
/// <param name="logger">The logger instance.</param>
public class TenantDbContext(DbContextOptions<TenantDbContext> options, ILogger<TenantDbContext> logger) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the database set for languages.
    /// </summary>
    public virtual DbSet<Language> Languages { get; set; } = null!;

    /// <summary>
    /// Gets or sets the database set for tenants.
    /// </summary>
    public virtual DbSet<Tenant> Tenants { get; set; } = null!;

    /// <summary>
    /// Gets or sets the database set for settings.
    /// </summary>
    public virtual DbSet<Setting> Settings { get; set; } = null!;

    /// <summary>
    /// Gets or sets the database set for users.
    /// </summary>
    public virtual DbSet<User> Users { get; set; } = null!;

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
            .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));

        base.OnConfiguring(optionsBuilder);
    }

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        ArgumentNullException.ThrowIfNull(configurationBuilder);
        _ = configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}
