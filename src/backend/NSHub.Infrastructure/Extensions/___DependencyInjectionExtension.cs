// <copyright file="___DependencyInjectionExtension.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;

namespace NSHub.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static WebApplicationBuilder AddInfrastructureBuilder(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        return builder;
    }
}
