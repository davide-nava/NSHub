// <copyright file="AuthController.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NSHub.Application.Features.Auth.Commands;
using NSHub.Application.Features.Auth.DTOs;

namespace NSHub.Api.Controllers;

/// <summary>
/// Controller providing authentication and token generation endpoints.
/// </summary>
[Route("api/v1/auth")]
public class AuthController : ApiControllerBase
{
    /// <summary>
    /// Authenticates user or employee credentials and generates a JWT bearer token.
    /// </summary>
    /// <param name="command">The login credentials command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The authentication response with token on success; otherwise 401 Unauthorized.</returns>
    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return HandleResult(result);
    }
}
