// <copyright file="DependencyInjectionExtension.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using NSHub.ApplicationCore.Interfaces;

using Scrutor;

namespace NSHub.ApplicationCore.Extensions;

public static class DependencyInjectionExtension
{
    public static WebApplicationBuilder AddApplicationCoreShareBuilder(this WebApplicationBuilder builder)
    {

        return builder;
    }

    public static WebApplicationBuilder AddApplicationMappers(this WebApplicationBuilder builder)
    {
        builder.Services.Scan(scan => scan
            .FromAssemblyOf<ProductMapper>()
             //.AddClasses(c => c.Where(t => t.Name.EndsWith("Mapper")))
             .AddClasses(c => c.AssignableTo(typeof(IMapper<,>)))
            .AsSelf()
            .WithSingletonLifetime());

        return builder;
    }
}
