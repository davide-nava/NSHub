// <copyright file="DependencyInjectionExtension.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;

namespace PlanetHub.Api.ApplicationCore.Extensions;

public static class DependencyInjectionExtension
{
    public static WebApplicationBuilder AddApplicationCoreBuilder(this WebApplicationBuilder builder )
    {
        ArgumentNullException.ThrowIfNull(builder);

        return builder;
    }
}
