// <copyright file="ApplicationDbContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSHub.Application.NSHub.Models;

namespace NSHub.Infrastructure.DbContexts;

/// <summary>
/// Identity database context for managing application authentication and identity entities.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
/// </remarks>
/// <param name="options">The database context options.</param>
/// <param name="logger">The logger instance.</param>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger) :
    IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        _ = builder.ApplyConfigurationsFromAssembly(typeof(TenantDbContext).Assembly);

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
                .EnableDetailedErrors()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        //.EnableSensitiveDataLogging()

        base.OnConfiguring(optionsBuilder);
    }
}

