// <copyright file="EmployeeRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Common;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Persistence.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="Employee"/> entities.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
/// </remarks>
/// <param name="context">The database context.</param>
public class EmployeeRepository(OpenXGestDbContext context) : IEmployeeRepository, Domain.Repositories.IEmployeeRepository
{
    /// <inheritdoc/>
    public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var targetId = new NSHub.Domain.HR.ValueObjects.EmployeeId(id);
        return await context.Employees.FirstOrDefaultAsync(e => e.Id == targetId, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Employee?> GetByIdAsync(NSHub.Domain.HR.ValueObjects.EmployeeId id, CancellationToken cancellationToken = default)
    {
        return await context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await context.Employees.FirstOrDefaultAsync(e => e.Email.ToLower() == email.ToLower(), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Employees
            .OrderBy(e => e.LastName)
            .ThenBy(e => e.FirstName)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task AddAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        _ = await context.Employees.AddAsync(employee, cancellationToken);
    }

    /// <inheritdoc/>
    public void Update(Employee employee)
    {
        if (context.Entry(employee).State == EntityState.Detached)
        {
            _ = context.Employees.Attach(employee);
        }
    }
}

/// <summary>
/// Unit of work implementation for committing transactions via <see cref="OpenXGestDbContext"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UnitOfWork"/> class.
/// </remarks>
/// <param name="context">The database context.</param>
public class UnitOfWork(OpenXGestDbContext context) : IUnitOfWork
{
    /// <inheritdoc/>
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
