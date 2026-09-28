// <copyright file="IEmployeeRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.Organization.Repositories;

/// <summary>
/// Repository interface for employee data access operations.
/// </summary>
public interface IEmployeeRepository : IRepository<Employee>
{
    /// <summary>
    /// Determines whether an employee with the specified email exists.
    /// </summary>
    /// <param name="email">The email to check.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns><see langword="true"/> if an employee exists with the email; otherwise, <see langword="false"/>.</returns>
    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an employee by their email address.
    /// </summary>
    /// <param name="email">The email address.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The matching employee, or <see langword="null"/> if not found.</returns>
    Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}
