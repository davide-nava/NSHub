// <copyright file="ApiKeyAttribute.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NSHub.Api.Filters;

namespace NSHub.Api.ServiceFilterAttributes;

/// <summary>
/// Specifies that the decorated controller or action method requires API key authentication via <see cref="ApiKeyAuthorizationFilter"/>.
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class ApiKeyAttribute : ServiceFilterAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiKeyAttribute"/> class.
    /// </summary>
    public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthorizationFilter))
    {
    }
}
