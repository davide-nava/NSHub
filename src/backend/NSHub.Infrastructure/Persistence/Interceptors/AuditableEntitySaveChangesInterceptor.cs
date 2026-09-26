using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Common;

namespace NSHub.Infrastructure.Persistence.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeService _dateTimeService;

    public AuditableEntitySaveChangesInterceptor(
        ICurrentUserService currentUserService,
        IDateTimeService dateTimeService)
    {
        _currentUserService = currentUserService;
        _dateTimeService = dateTimeService;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        var now = _dateTimeService.UtcNow;
        var userId = _currentUserService.UserId;
        var tenantId = _currentUserService.TenantId;

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.Entity is IAuditableEntity auditable)
            {
                if (entry.State == EntityState.Added)
                {
                    auditable.DateInsert = now;
                    auditable.DateUpdate = now;
                    auditable.UserInsertId = userId;
                    auditable.UserUpdateId = userId;

                    if (entry.Entity is ITenantEntity tenantEntity && !tenantEntity.TenantId.HasValue)
                    {
                        tenantEntity.TenantId = tenantId;
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    auditable.DateUpdate = now;
                    auditable.UserUpdateId = userId;
                }
                else if (entry.State == EntityState.Deleted && entry.Entity is ISoftDeletable softDeletable)
                {
                    entry.State = EntityState.Modified;
                    softDeletable.DateDelete = now;
                    softDeletable.UserDeleteId = userId;
                    auditable.DateUpdate = now;
                    auditable.UserUpdateId = userId;
                }
            }
        }
    }
}
