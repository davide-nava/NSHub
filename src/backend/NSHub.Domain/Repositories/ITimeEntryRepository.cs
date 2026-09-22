// <copyright file="ITimeEntryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for TimeEntry aggregate persistence.
/// </summary>
public interface ITimeEntryRepository
{
    /// <summary>
    /// Retrieves a time entry by its identifier.
    /// </summary>
    Task<TimeEntry?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the active, unclosed time entry for an employee if present.
    /// </summary>
    Task<TimeEntry?> GetActiveEntryForEmployeeAsync(Guid employeeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the most recent completed shift preceding the specified timestamp.
    /// </summary>
    Task<TimeEntry?> GetPreviousEntryBeforeAsync(Guid employeeId, DateTime utcTimestamp, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves time entries for an employee within a date range.
    /// </summary>
    Task<List<TimeEntry>> GetEntriesForEmployeeRangeAsync(Guid employeeId, DateTime startUtc, DateTime endUtc, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new time entry.
    /// </summary>
    Task AddAsync(TimeEntry timeEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Persists a statutory time correction audit trail record.
    /// </summary>
    Task AddCorrectionAuditAsync(TimeCorrectionAudit audit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing time entry.
    /// </summary>
    void Update(TimeEntry timeEntry);
}
