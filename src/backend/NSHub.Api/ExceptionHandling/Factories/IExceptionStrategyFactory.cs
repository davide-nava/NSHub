// <copyright file="IExceptionStrategyFactory.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Api.ExceptionHandling.Factories;

public interface IExceptionStrategyFactory
{
    IExceptionStrategy GetExceptionStrategy(Exception exception);
}
