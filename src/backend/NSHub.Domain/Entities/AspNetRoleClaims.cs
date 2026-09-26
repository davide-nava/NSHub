using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AspNetRoleClaims : BaseEntity<int>
{
    public string RoleId { get; protected set; } = string.Empty;
    public string? ClaimType { get; protected set; }
    public string? ClaimValue { get; protected set; }
    public virtual AspNetRoles? Role { get; protected set; }

    protected AspNetRoleClaims() { }

    public static AspNetRoleClaims Create()
    {
        return new AspNetRoleClaims();
    }
}
