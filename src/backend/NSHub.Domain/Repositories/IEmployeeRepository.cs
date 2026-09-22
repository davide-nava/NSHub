// <copyright file="IEmployeeRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for employee aggregate persistence.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Retrieves an employee by their strongly-typed identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<Employee?> GetByIdAsync(EmployeeId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an employee by their email address.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all employees.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new employee to the repository.
    /// </summary>
    /// <param name="employee"></param>
    /// <param name="cancellationToken"></param>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    public Task AddAsync(Employee employee, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing employee.
    /// </summary>
    /// <param name="employee"></param>
    public void Update(Employee employee);
}
