// <copyright file="AspNetUserLogins.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Entities;

public class AspNetUserLogins
{
    public string LoginProvider { get; protected set; } = string.Empty;
    public string ProviderKey { get; protected set; } = string.Empty;
    public string? ProviderDisplayName { get; protected set; }
    public string UserId { get; protected set; } = string.Empty;
    public virtual AspNetUsers? User { get; protected set; }

    protected AspNetUserLogins() { }

    public static AspNetUserLogins Create()
    {
        return new AspNetUserLogins();
    }
}
