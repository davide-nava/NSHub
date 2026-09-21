// <copyright file="ExceptionHandlingExtensions.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Api.ExceptionHandling.Factories;

namespace NSHub.Api.ExceptionHandling.Extensions;

/// <summary>
/// Provides extension methods for registering exception handling strategies and filters in the dependency injection container.
/// </summary>
public static class ExceptionHandlingExtensions
{
    /// <summary>
    /// Registers the exception strategy factory and execution context in the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddExceptionStrategy(this IServiceCollection services)
    {
        _ = services.AddSingleton<IExceptionStrategyFactory, ExceptionStrategyFactory>();
        _ = services.AddSingleton<IExceptionStrategyContext, ExceptionStrategyContext>();

        return services;
    }

    /// <summary>
    /// Registers exception handling strategies and appends the exception filter to MVC controllers.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddExceptionFilter(this IServiceCollection services)
    {
        _ = services.AddExceptionStrategy();
        _ = services.AddControllers(options => options.Filters.Add<ExeptionFilter>());

        return services;
    }
}
