// <copyright file="GetEmployeesQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.DTOs;

namespace NSHub.Application.Features.Employees.Queries.GetEmployees;

/// <summary>
/// MediatR request handler for retrieving all employees.
/// </summary>
public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, Result<List<EmployeeDto>>>
{
    private readonly IApplicationDbContext _context;

    public GetEmployeesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Result<List<EmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _context.Employees
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var dtos = employees.Select(EmployeeDto.FromEntity).ToList();
        return Result<List<EmployeeDto>>.Success(dtos);
    }
}
