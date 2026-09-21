// <copyright file="UnknownExceptionStrategy.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NSHub.Api.ExceptionHandling.Strategies;

public class UnknownExceptionStrategy(ProblemDetailsFactory problemDetailsFactory) : IExceptionStrategy
{
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
