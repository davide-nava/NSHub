// <copyright file="TenantDbContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using NSHub.Application.Entities;

namespace NSHub.Infrastructure.DbContexts;

public class TenantDbContext(DbContextOptions<TenantDbContext> options, ILogger logger) : DbContext(options)
{
    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

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

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        _ = configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}
