// <copyright file="UnknownExceptionStrategy.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NSHub.Api.ExceptionHandling.Strategies;

/// <summary>
/// Fallback strategy for handling unhandled exceptions and producing 500 Internal Server Error responses.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UnknownExceptionStrategy"/> class.
/// </remarks>
/// <param name="problemDetailsFactory">The factory used to create problem details instances.</param>
public class UnknownExceptionStrategy(ProblemDetailsFactory problemDetailsFactory) : IExceptionStrategy
{
    /// <inheritdoc/>
    public void HandleException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var problemDetails = problemDetailsFactory.CreateProblemDetails(context.HttpContext, statusCode: StatusCodes.Status500InternalServerError);
        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = StatusCodes.Status500InternalServerError,
        };
        context.ExceptionHandled = true;
    }
}
