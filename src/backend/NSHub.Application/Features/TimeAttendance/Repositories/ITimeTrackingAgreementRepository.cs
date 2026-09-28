// <copyright file="ITimeTrackingAgreementRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.TimeAttendance.Repositories;

/// <summary>
/// Repository interface for time tracking agreement data access operations.
/// </summary>
public interface ITimeTrackingAgreementRepository : IRepository<TimeTrackingAgreement>
{
    /// <summary>
    /// Retrieves the active agreement for the given employee on a specific date.
    /// </summary>
    /// <param name="employeeId">The employee identifier.</param>
    /// <param name="date">The effective date.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The active agreement if found; otherwise, <see langword="null"/>.</returns>
    Task<TimeTrackingAgreement?> GetActiveAgreementAsync(Guid employeeId, DateTime date, CancellationToken cancellationToken = default);
}
