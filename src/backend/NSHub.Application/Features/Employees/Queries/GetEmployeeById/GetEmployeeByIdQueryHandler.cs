// <copyright file="GetEmployeeByIdQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.DTOs;

namespace NSHub.Application.Features.Employees.Queries.GetEmployeeById;

/// <summary>
/// MediatR request handler for retrieving an employee by Id.
/// </summary>
public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;

    public GetEmployeeByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Result<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (employee is null)
        {
            return Result<EmployeeDto>.Failure([$"Employee with ID '{request.Id}' was not found."]);
        }

        return Result<EmployeeDto>.Success(EmployeeDto.FromEntity(employee));
    }
}
