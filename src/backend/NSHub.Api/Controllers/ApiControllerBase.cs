// <copyright file="ApiControllerBase.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSHub.Domain.Common;

namespace NSHub.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? mediator;
    protected ISender Mediator => mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return CreateProblemDetails(result.Error, result.Errors);
    }

    protected IActionResult HandleResult(Result result)
    {
        if (result.IsSuccess)
        {
            return Ok();
        }

        return CreateProblemDetails(result.Error, result.Errors);
    }

    private IActionResult CreateProblemDetails(Error primaryError, IReadOnlyList<Error> errors)
    {
        var statusCode = primaryError.Type switch
        {
            ErrorType.VALIDATION => StatusCodes.Status400BadRequest,
            ErrorType.NOT_FOUND => StatusCodes.Status404NotFound,
            ErrorType.CONFLICT => StatusCodes.Status409Conflict,
            ErrorType.UNAUTHORIZED => StatusCodes.Status401Unauthorized,
            ErrorType.FORBIDDEN => StatusCodes.Status403Forbidden,
            ErrorType.LEGAL_VIOLATION => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status400BadRequest,
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = primaryError.Code,
            Detail = primaryError.Description,
            Instance = HttpContext.Request.Path,
            Type = $"https://httpstatuses.com/{statusCode}",
        };

        if (errors.Count > 1)
        {
            problemDetails.Extensions["errors"] = errors.Select(e => new
            {
                code = e.Code,
                description = e.Description,
                type = e.Type.ToString(),
            });
        }

        return StatusCode(statusCode, problemDetails);
    }
}
