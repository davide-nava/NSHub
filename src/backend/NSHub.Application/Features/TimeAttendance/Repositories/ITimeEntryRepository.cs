// <copyright file="ITimeEntryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.TimeAttendance.Repositories;

/// <summary>
/// Repository interface for time entry data access operations.
/// </summary>
public interface ITimeEntryRepository : IRepository<TimeEntry>
{
    /// <summary>
    /// Retrieves the current active (open) time entry for an employee, if any.
    /// </summary>
    /// <param name="employeeId">The employee identifier.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The active time entry, or <see langword="null"/> if none exists.</returns>
    Task<TimeEntry?> GetActiveEntryAsync(Guid employeeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all time entries for an employee within the specified date range.
    /// </summary>
    /// <param name="employeeId">The employee identifier.</param>
    /// <param name="start">The range start date and time.</param>
    /// <param name="end">The range end date and time.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A collection of matching time entries.</returns>
    Task<IReadOnlyList<TimeEntry>> GetEntriesByDateRangeAsync(Guid employeeId, DateTime start, DateTime end, CancellationToken cancellationToken = default);
}
