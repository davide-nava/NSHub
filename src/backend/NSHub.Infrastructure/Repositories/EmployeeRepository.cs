// <copyright file="EmployeeRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.DbContexts;
using EmpRepo = NSHub.Application.Features.Employees.Repositories;
using OrgRepo = NSHub.Application.Features.Organization.Repositories;

namespace NSHub.Infrastructure.Repositories;

/// <summary>
/// Entity Framework Core repository implementation for employee entities.
/// </summary>
/// <param name="dbContext">The application database context.</param>
public class EmployeeRepository(ApplicationDbContext dbContext) :
    Repository<Employee>(dbContext),
    EmpRepo.IEmployeeRepository,
    OrgRepo.IEmployeeRepository
{
    /// <inheritdoc/>
    public async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(email);
        var normalized = email.ToLower();
        return await DbSet.AnyAsync(e => e.Email.ToLower() == normalized, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Employee?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(email);
        var normalized = email.ToLower();
        return await DbSet.FirstOrDefaultAsync(e => e.Email.ToLower() == normalized, cancellationToken);
    }
}
