// <copyright file="ApiKeyAttribute.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NSHub.Api.Filters;

namespace NSHub.Api.ServiceFilterAttributes;

[AttributeUsage(AttributeTargets.All)]
public class ApiKeyAttribute : ServiceFilterAttribute
{
    public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthorizationFilter))
    {
    }
}
