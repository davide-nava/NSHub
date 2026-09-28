// <copyright file="LoginCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NSHub.Application.Features.Employees.Repositories;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Auth.DTOs;

namespace NSHub.Application.Features.Auth.Commands;

/// <summary>
/// MediatR request handler for processing employee login requests.
/// </summary>
public class LoginCommandHandler(IEmployeeRepository employeeRepository, IJwtTokenService jwtTokenService) : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
{
    /// <inheritdoc/>
    public async Task<Result<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        var employee = await employeeRepository.GetByEmailAsync(email, cancellationToken);

        if (employee == null)
        {
            return Result<AuthResponseDto>.Failure(["Invalid email or password."]);
        }

        var role = employee.Email.Contains("admin", StringComparison.OrdinalIgnoreCase) || employee.Email.Contains("hr", StringComparison.OrdinalIgnoreCase) ? "HRManager" : "Employee";
        var token = jwtTokenService.GenerateToken(employee, role);

        var dto = new AuthResponseDto(
            token,
            employee.Id,
            $"{employee.FirstName} {employee.LastName}".Trim(),
            employee.Email,
            role,
            employee.PreferredLanguage,
            employee.Oll1Regime
        );

        return Result<AuthResponseDto>.Success(dto);
    }
}
