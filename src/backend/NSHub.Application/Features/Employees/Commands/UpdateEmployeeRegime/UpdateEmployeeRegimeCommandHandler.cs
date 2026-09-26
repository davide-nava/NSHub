// <copyright file="UpdateEmployeeRegimeCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeRegime;

/// <summary>
/// MediatR request handler for updating an employee's Swiss OLL 1 regime.
/// </summary>
public class UpdateEmployeeRegimeCommandHandler : IRequestHandler<UpdateEmployeeRegimeCommand, Result>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeRegimeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Result> Handle(UpdateEmployeeRegimeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);

        if (employee is null)
        {
            return Result.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        employee.SetRegime(request.Regime);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
