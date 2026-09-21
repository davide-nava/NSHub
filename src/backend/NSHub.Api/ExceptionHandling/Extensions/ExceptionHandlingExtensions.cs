// <copyright file="ExceptionHandlingExtensions.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Api.ExceptionHandling.Factories;

namespace NSHub.Api.ExceptionHandling.Extensions;

public static class ExceptionHandlingExtensions
{
    public static IServiceCollection AddExceptionStrategy(this IServiceCollection services)
    {
        _ = services.AddSingleton<IExceptionStrategyFactory, ExceptionStrategyFactory>();
        _ = services.AddSingleton<IExceptionStrategyContext, ExceptionStrategyContext>();

        return services;
    }

    public static IServiceCollection AddExceptionFilter(this IServiceCollection services)
    {
        _ = services.AddExceptionStrategy();
        _ = services.AddControllers(options => options.Filters.Add<ExeptionFilter>());

        return services;
    }
}
