// <copyright file="CreateEmployeeCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.Employees.Commands.CreateEmployee;

/// <summary>
/// Handler for <see cref="CreateEmployeeCommand"/>.
/// </summary>
public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Result<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var emailExists = await _context.Employees
            .AnyAsync(e => e.Email == request.Email, cancellationToken);

        if (emailExists)
        {
            return Result<EmployeeDto>.Failure(["An employee with the specified email already exists."]);
        }

        var employee = Employee.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Department,
            request.ContractualWeeklyHours,
            request.StatutoryWeeklyLimit,
            request.Oll1Regime,
            request.PreferredLanguage);

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<EmployeeDto>.Success(EmployeeDto.FromEntity(employee));
    }
}
