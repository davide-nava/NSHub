// <copyright file="TimeEntryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.DbContexts;
using TimeAttRepo = NSHub.Application.Features.TimeAttendance.Repositories;
using TimeTrackRepo = NSHub.Application.Features.TimeTracking.Repositories;

namespace NSHub.Infrastructure.Repositories;

/// <summary>
/// Entity Framework Core repository implementation for time entry entities.
/// </summary>
/// <param name="dbContext">The application database context.</param>
public class TimeEntryRepository(ApplicationDbContext dbContext) :
    Repository<TimeEntry>(dbContext),
    TimeAttRepo.ITimeEntryRepository,
    TimeTrackRepo.ITimeEntryRepository
{
    /// <inheritdoc/>
    public async Task<TimeEntry?> GetActiveEntryAsync(Guid employeeId, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(
            e => e.EmployeeId == employeeId && e.ClockOutUtc == null,
            cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<TimeEntry>> GetEntriesByDateRangeAsync(
        Guid employeeId,
        DateTime start,
        DateTime end,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Where(e => e.EmployeeId == employeeId && e.ClockInUtc >= start && e.ClockInUtc <= end)
            .OrderBy(e => e.ClockInUtc)
            .ToListAsync(cancellationToken);
    }
}
