// <copyright file="DependencyInjection.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSHub.Application.Common.Behaviors;

namespace NSHub.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        _ = services.AddMediatR(cfg =>
        {
            _ = cfg.RegisterServicesFromAssembly(assembly);
            _ = cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            _ = cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        _ = services.AddValidatorsFromAssembly(assembly);

        // AddLocalization senza ResourcesPath affinché il namespace esatto del tipo ValidationMessages corrisponda
        _ = services.AddLocalization();

        return services;
    }
}
