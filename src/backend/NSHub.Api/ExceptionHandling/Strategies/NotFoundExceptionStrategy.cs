// <copyright file="NotFoundExceptionStrategy.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NSHub.Api.ExceptionHandling.Strategies;

public class NotFoundExceptionStrategy(ProblemDetailsFactory problemDetailsFactory) : IExceptionStrategy
{
    public void HandleException(ExceptionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var problemDetails = problemDetailsFactory.CreateProblemDetails(context.HttpContext, statusCode: StatusCodes.Status404NotFound, detail: context.Exception.Message);
        context.Result = new NotFoundObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
