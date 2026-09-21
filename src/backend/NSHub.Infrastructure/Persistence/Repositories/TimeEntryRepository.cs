// <copyright file="TimeEntryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Persistence.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="TimeEntry"/> records and time correction audits.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="TimeEntryRepository"/> class.
/// </remarks>
/// <param name="context">The database context.</param>
public class TimeEntryRepository(OpenXGestDbContext context) : ITimeEntryRepository
{
    /// <inheritdoc/>
    public async Task<TimeEntry?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.TimeEntries
            .Include(t => t.AuditTrail)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TimeEntry?> GetActiveEntryForEmployeeAsync(Guid employeeId, CancellationToken cancellationToken = default)
    {
        return await context.TimeEntries
            .Include(t => t.AuditTrail)
            .Where(t => t.EmployeeId == employeeId && t.ClockOutUtc == null)
            .OrderByDescending(t => t.ClockInUtc)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TimeEntry?> GetPreviousEntryBeforeAsync(Guid employeeId, DateTime utcTimestamp, CancellationToken cancellationToken = default)
    {
        return await context.TimeEntries
            .Where(t => t.EmployeeId == employeeId && t.ClockInUtc < utcTimestamp)
            .OrderByDescending(t => t.ClockInUtc)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<TimeEntry>> GetEntriesForEmployeeRangeAsync(
        Guid employeeId,
        DateTime startUtc,
        DateTime endUtc,
        CancellationToken cancellationToken = default)
    {
        return await context.TimeEntries
            .Include(t => t.AuditTrail)
            .Where(t => t.EmployeeId == employeeId && t.ClockInUtc >= startUtc && t.ClockInUtc <= endUtc)
            .OrderBy(t => t.ClockInUtc)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task AddAsync(TimeEntry timeEntry, CancellationToken cancellationToken = default)
    {
        _ = await context.TimeEntries.AddAsync(timeEntry, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task AddCorrectionAuditAsync(TimeCorrectionAudit audit, CancellationToken cancellationToken = default)
    {
        _ = await context.TimeCorrectionAudits.AddAsync(audit, cancellationToken);
    }

    /// <inheritdoc/>
    public void Update(TimeEntry timeEntry)
    {
        if (context.Entry(timeEntry).State == EntityState.Detached)
        {
            _ = context.TimeEntries.Attach(timeEntry);
        }
    }
}
