// <copyright file="ITimeEntryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for TimeEntry aggregate persistence.
/// </summary>
public interface ITimeEntryRepository
{
    /// <summary>
    /// Retrieves a time entry by its identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<TimeEntry?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the active, unclosed time entry for an employee if present.
    /// </summary>
    /// <param name="employeeId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<TimeEntry?> GetActiveEntryForEmployeeAsync(Guid employeeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the most recent completed shift preceding the specified timestamp.
    /// </summary>
    /// <param name="employeeId"></param>
    /// <param name="utcTimestamp"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<TimeEntry?> GetPreviousEntryBeforeAsync(Guid employeeId, DateTime utcTimestamp, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves time entries for an employee within a date range.
    /// </summary>
    /// <param name="employeeId"></param>
    /// <param name="startUtc"></param>
    /// <param name="endUtc"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<List<TimeEntry>> GetEntriesForEmployeeRangeAsync(Guid employeeId, DateTime startUtc, DateTime endUtc, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new time entry.
    /// </summary>
    /// <param name="timeEntry"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task AddAsync(TimeEntry timeEntry, CancellationToken cancellationToken = default);

    /// <summary>
    /// Persists a statutory time correction audit trail record.
    /// </summary>
    /// <param name="audit"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task AddCorrectionAuditAsync(TimeCorrectionAudit audit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing time entry.
    /// </summary>
    /// <param name="timeEntry"></param>
    public void Update(TimeEntry timeEntry);
}
