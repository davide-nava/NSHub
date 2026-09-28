// <copyright file="ValidationExceptionStrategy.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NSHub.Api.ExceptionHandling.Strategies;

/// <summary>
/// Strategy for handling validation exceptions and producing 400 Bad Request responses with validation details.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ValidationExceptionStrategy"/> class.
/// </remarks>
/// <param name="problemDetailsFactory">The factory used to create problem details instances.</param>
public class ValidationExceptionStrategy(ProblemDetailsFactory problemDetailsFactory) : IExceptionStrategy
{
    /// <inheritdoc/>
    public void HandleException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        ProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);
        context.Result = new BadRequestObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
