using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AspNetUserClaims : BaseEntity<int>
{
    public string UserId { get; protected set; } = string.Empty;
    public string? ClaimType { get; protected set; }
    public string? ClaimValue { get; protected set; }
    public virtual AspNetUsers? User { get; protected set; }

    protected AspNetUserClaims() { }

    public static AspNetUserClaims Create()
    {
        return new AspNetUserClaims();
    }
}
