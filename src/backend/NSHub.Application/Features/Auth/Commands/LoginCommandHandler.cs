// <copyright file="LoginCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Localization;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.Auth.DTOs;
using NSHub.Application.Resources;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.Auth.Commands;

/// <summary>
/// MediatR request handler for processing employee login requests.
/// </summary>
public class LoginCommandHandler(
    IEmployeeRepository employeeRepository,
    IJwtTokenService jwtTokenService,
    IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
{
    public async Task<Result<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByEmailAsync(request.Email.Trim().ToLowerInvariant(), cancellationToken);
        if (employee == null)
        {
            return Result<AuthResponseDto>.Failure(Error.Unauthorized("Auth.InvalidCredentials", localizer["InvalidCredentials"]));
        }

        // Determine role based on department or email identifier
        var role = employee.Email.Contains("admin", StringComparison.OrdinalIgnoreCase) || employee.Email.Contains("hr", StringComparison.OrdinalIgnoreCase) ? "HRManager" : "Employee";
        var token = jwtTokenService.GenerateToken(employee, role);

        var dto = new AuthResponseDto(
            token,
            employee.Id,
            $"{employee.FirstName} {employee.LastName}",
            employee.Email,
            role,
            employee.PreferredLanguage,
            employee.Oll1Regime
        );

        return Result<AuthResponseDto>.Success(dto);
    }
}
