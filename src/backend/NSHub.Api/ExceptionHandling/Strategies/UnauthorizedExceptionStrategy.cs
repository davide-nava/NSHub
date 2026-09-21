// <copyright file="UnauthorizedExceptionStrategy.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NSHub.Api.ExceptionHandling.Strategies;

public class UnauthorizedExceptionStrategy(ProblemDetailsFactory problemDetailsFactory) : IExceptionStrategy
{
    public void HandleException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var problemDetails = problemDetailsFactory.CreateProblemDetails(context.HttpContext, StatusCodes.Status401Unauthorized);
        context.Result = new UnauthorizedObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
