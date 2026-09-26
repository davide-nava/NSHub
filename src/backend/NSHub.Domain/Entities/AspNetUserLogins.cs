using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

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
