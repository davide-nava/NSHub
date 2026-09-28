// <copyright file="UnauthorizedExceptionStrategy.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NSHub.Api.ExceptionHandling.Strategies;

/// <summary>
/// Strategy for handling unauthorized exceptions and producing 401 Unauthorized responses.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UnauthorizedExceptionStrategy"/> class.
/// </remarks>
/// <param name="problemDetailsFactory">The factory used to create problem details instances.</param>
public class UnauthorizedExceptionStrategy(ProblemDetailsFactory problemDetailsFactory) : IExceptionStrategy
{
    /// <inheritdoc/>
    public void HandleException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var problemDetails = problemDetailsFactory.CreateProblemDetails(context.HttpContext, StatusCodes.Status401Unauthorized);
        context.Result = new UnauthorizedObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
