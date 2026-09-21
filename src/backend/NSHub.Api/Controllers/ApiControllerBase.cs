// <copyright file="ApiControllerBase.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSHub.Domain.Common;

namespace NSHub.Api.Controllers;

/// <summary>
/// Abstract base API controller providing shared MediatR dispatcher and standardized Result-to-IActionResult mapping.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? mediator;

    /// <summary>
    /// Gets the MediatR sender instance resolved from the current HTTP request services.
    /// </summary>
    protected ISender Mediator => mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    /// <summary>
    /// Evaluates a typed result, returning an Ok result on success or a ProblemDetails object on failure.
    /// </summary>
    /// <typeparam name="T">The result payload type.</typeparam>
    /// <param name="result">The domain/application result to evaluate.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response.</returns>
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return CreateProblemDetails(result.Error, result.Errors);
    }

    /// <summary>
    /// Evaluates an untyped result, returning an Ok result on success or a ProblemDetails object on failure.
    /// </summary>
    /// <param name="result">The domain/application result to evaluate.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response.</returns>
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
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.LegalViolation => StatusCodes.Status422UnprocessableEntity,
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
