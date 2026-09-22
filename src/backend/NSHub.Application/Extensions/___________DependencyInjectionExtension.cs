// <copyright file="DependencyInjectionExtension.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;

namespace NSHub.Api.ApplicationCore.Extensions;

public static class DependencyInjectionExtension
{
    public static WebApplicationBuilder AddApplicationCoreBuilder(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        return builder;
    }
}
