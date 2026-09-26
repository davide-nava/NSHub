// <copyright file="UpdateEmployeeContractCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.DTOs;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeContract;

/// <summary>
/// Handler for <see cref="UpdateEmployeeContractCommand"/>.
/// </summary>
public sealed class UpdateEmployeeContractCommandHandler : IRequestHandler<UpdateEmployeeContractCommand, Result<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeContractCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Result<EmployeeDto>> Handle(UpdateEmployeeContractCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);

        if (employee is null)
        {
            return Result<EmployeeDto>.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        employee.SetContract(request.WeeklyHours, request.Limit);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<EmployeeDto>.Success(EmployeeDto.FromEntity(employee));
    }
}
