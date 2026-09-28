// <copyright file="TimeTrackingAgreementRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NSHub.Application.Features.TimeAttendance.Repositories;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories;

/// <summary>
/// Entity Framework Core repository implementation for time tracking agreement entities.
/// </summary>
/// <param name="dbContext">The application database context.</param>
public class TimeTrackingAgreementRepository(ApplicationDbContext dbContext) :
    Repository<TimeTrackingAgreement>(dbContext),
    ITimeTrackingAgreementRepository
{
    /// <inheritdoc/>
    public async Task<TimeTrackingAgreement?> GetActiveAgreementAsync(
        Guid employeeId,
        DateTime date,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(
            a => a.EmployeeId == employeeId &&
                 a.ValidFrom <= date &&
                 (!a.ValidTo.HasValue || a.ValidTo >= date),
            cancellationToken);
    }
}
