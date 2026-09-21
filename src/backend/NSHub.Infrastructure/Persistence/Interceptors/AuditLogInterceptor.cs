// <copyright file="AuditLogInterceptor.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Persistence.Interceptors;

/// <summary>
/// Intercettore EF Core per:
/// 1. Blocco assoluto di eliminazioni fisiche su TimeEntry e TimeCorrectionAudit in conformità
///    all'obbligo di conservazione quinquennale dei dati sulle ore di lavoro (Art. 73 cpv. 2 OLL 1).
/// 2. Popolamento automatico delle shadow audit properties (CreatedAt, CreatedBy, LastModifiedAt, LastModifiedBy).
/// </summary>
public class AuditLogInterceptor(ICurrentUserService currentUserService, IDateTimeProvider dateTimeProvider) : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        ApplyAuditAndEnforceSwissRetention(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

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
            // VINCOLO LEGALE SVIZZERO (Art. 73 cpv. 2 OLL 1):
            // Divieto di eliminazione fisica (Hard Delete) per garantire la conservazione quinquennale
            if (entry.State == EntityState.Deleted && entry.Entity is TimeEntry or TimeCorrectionAudit)
            {
                throw new InvalidOperationException(
                    "L'eliminazione fisica delle registrazioni o delle rettifiche orarie è vietata dal Diritto del lavoro svizzero (Art. 73 cpv. 2 OLL 1: obbligo di conservazione per almeno 5 anni).");
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
