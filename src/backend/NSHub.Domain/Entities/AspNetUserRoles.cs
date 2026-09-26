using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AspNetUserRoles
{
    public string UserId { get; protected set; } = string.Empty;
    public string RoleId { get; protected set; } = string.Empty;
    public virtual AspNetRoles? Role { get; protected set; }
    public virtual AspNetUsers? User { get; protected set; }

    protected AspNetUserRoles() { }

    public static AspNetUserRoles Create()
    {
        return new AspNetUserRoles();
    }
}
