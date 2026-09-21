// <copyright file="AuditLogInterceptor.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Persistence.Interceptors;

/// <summary>
/// EF Core interceptor that enforces:
/// 1. Strict prohibition of physical hard deletion on <see cref="TimeEntry"/> and <see cref="TimeCorrectionAudit"/>
/// in compliance with Swiss 5-year worktime retention requirements (Art. 73 para. 2 ArGV 1 / OLL 1).
/// 2. Automatic population of audit shadow properties (CreatedAt, CreatedBy, LastModifiedAt, LastModifiedBy).
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuditLogInterceptor"/> class.
/// </remarks>
/// <param name="currentUserService">The service providing current user information.</param>
/// <param name="dateTimeProvider">The date and time provider.</param>
public class AuditLogInterceptor(ICurrentUserService currentUserService, IDateTimeProvider dateTimeProvider) : SaveChangesInterceptor
{
    /// <inheritdoc/>
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        ApplyAuditAndEnforceSwissRetention(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    /// <inheritdoc/>
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditAndEnforceSwissRetention(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void ApplyAuditAndEnforceSwissRetention(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        var user = currentUserService.Email ?? currentUserService.UserId?.ToString() ?? "System";
        var nowUtc = dateTimeProvider.UtcNow;

        foreach (var entry in context.ChangeTracker.Entries())
        {
            // Swiss legal requirement (Art. 73 para. 2 ArGV 1 / OLL 1):
            // Prohibition of physical deletion (Hard Delete) to ensure 5-year retention
            if (entry.State == EntityState.Deleted && entry.Entity is TimeEntry or TimeCorrectionAudit)
            {
                throw new InvalidOperationException(
                    "Physical deletion of time entries or corrections is prohibited under Swiss labor law (Art. 73 para. 2 ArGV 1: mandatory retention for at least 5 years).");
            }

            // Shadow Properties
            if (entry.Metadata.FindProperty("CreatedAt") != null && entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = nowUtc;
                entry.Property("CreatedBy").CurrentValue = user;
            }

            if (entry.Metadata.FindProperty("LastModifiedAt") != null &&
                (entry.State == EntityState.Added || entry.State == EntityState.Modified))
            {
                entry.Property("LastModifiedAt").CurrentValue = nowUtc;
                entry.Property("LastModifiedBy").CurrentValue = user;
            }
        }
    }
}
