// <copyright file="IExceptionStrategy.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc.Filters;

namespace NSHub.Api.ExceptionHandling;

public interface IExceptionStrategy
{
    void HandleException(ExceptionContext context);
}
