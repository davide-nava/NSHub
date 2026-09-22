// <copyright file="IEmployeeRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for employee aggregate persistence.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Retrieves an employee by their strongly-typed identifier.
    /// </summary>
    Task<Employee?> GetByIdAsync(EmployeeId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an employee by their email address.
    /// </summary>
    Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all employees.
    /// </summary>
    Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new employee to the repository.
    /// </summary>
    Task AddAsync(Employee employee, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing employee.
    /// </summary>
    void Update(Employee employee);
}
