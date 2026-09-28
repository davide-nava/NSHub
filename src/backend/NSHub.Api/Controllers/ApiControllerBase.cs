// <copyright file="ApiControllerBase.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    /// Gets or sets the MediatR sender instance resolved from the current HTTP request services.
    /// </summary>
    protected ISender Mediator => mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    /// <summary>
    /// Gets the MediatR sender instance (alias for Mediator).
    /// </summary>
    protected ISender Sender => Mediator;

    /// <summary>
    /// Evaluates a typed result, returning an Ok result on success or a ProblemDetails object on failure.
    /// </summary>
    /// <typeparam name="T">The result payload type.</typeparam>
    /// <param name="result">The domain/application result to evaluate.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response.</returns>
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        ArgumentNullException.ThrowIfNull(result);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return CreateProblemDetails(result.Errors);
    }

    /// <summary>
    /// Evaluates an untyped result, returning an Ok result on success or a ProblemDetails object on failure.
    /// </summary>
    /// <param name="result">The domain/application result to evaluate.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response.</returns>
    protected IActionResult HandleResult(Result result)
    {
        ArgumentNullException.ThrowIfNull(result);

        if (result.IsSuccess)
        {
            return Ok();
        }

        return CreateProblemDetails(result.Errors);
    }

    private BadRequestObjectResult CreateProblemDetails(IReadOnlyList<string> errors)
    {
        var primaryError = errors.Count > 0 ? errors[0] : "An error occurred.";
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Bad Request",
            Detail = primaryError,
            Instance = HttpContext.Request.Path,
            Type = "https://httpstatuses.com/400",
        };

        if (errors.Count > 1)
        {
            problemDetails.Extensions["errors"] = errors;
        }

        return BadRequest(problemDetails);
    }
}
