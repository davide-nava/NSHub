// <copyright file="ConfigureExternalAuthenticationPropertiesRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace NSHub.Application.Models.Requests;

public class ConfigureExternalAuthenticationPropertiesRequest
{
    public string? Provider
    {
        get; set;
    }

    [StringSyntax(StringSyntaxAttribute.Uri)]
    public string? RedirectUrl
    {
        get; set;
    }

    public Guid UserId
    {
        get; set;
    }
}

