// <copyright file="NotFoundExceptionStrategy.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NSHub.Api.ExceptionHandling.Strategies;

/// <summary>
/// Strategy for handling not found exceptions and producing 404 Not Found responses.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NotFoundExceptionStrategy"/> class.
/// </remarks>
/// <param name="problemDetailsFactory">The factory used to create problem details instances.</param>
public class NotFoundExceptionStrategy(ProblemDetailsFactory problemDetailsFactory) : IExceptionStrategy
{
    /// <inheritdoc/>
    public void HandleException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var problemDetails = problemDetailsFactory.CreateProblemDetails(context.HttpContext, statusCode: StatusCodes.Status404NotFound, detail: context.Exception.Message);
        context.Result = new NotFoundObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
