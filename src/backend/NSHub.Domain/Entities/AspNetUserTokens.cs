using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AspNetUserTokens
{
    public string UserId { get; protected set; } = string.Empty;
    public string LoginProvider { get; protected set; } = string.Empty;
    public string Name { get; protected set; } = string.Empty;
    public string? Value { get; protected set; }
    public virtual AspNetUsers? User { get; protected set; }

    protected AspNetUserTokens() { }

    public static AspNetUserTokens Create()
    {
        return new AspNetUserTokens();
    }
}
