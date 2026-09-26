using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AspNetUsers : BaseEntity<string>
{
    public string? UserName { get; protected set; }
    public string? NormalizedUserName { get; protected set; }
    public string? Email { get; protected set; }
    public string? NormalizedEmail { get; protected set; }
    public bool EmailConfirmed { get; protected set; }
    public string? PasswordHash { get; protected set; }
    public string? SecurityStamp { get; protected set; }
    public string? ConcurrencyStamp { get; protected set; }
    public string? PhoneNumber { get; protected set; }
    public bool PhoneNumberConfirmed { get; protected set; }
    public bool TwoFactorEnabled { get; protected set; }
    public DateTimeOffset? LockoutEnd { get; protected set; }
    public bool LockoutEnabled { get; protected set; }
    public int AccessFailedCount { get; protected set; }

    private readonly List<AspNetUserClaims> _aspNetUserClaimses = new();
    public virtual IReadOnlyCollection<AspNetUserClaims> AspNetUserClaimses => _aspNetUserClaimses.AsReadOnly();
    private readonly List<AspNetUserLogins> _aspNetUserLoginses = new();
    public virtual IReadOnlyCollection<AspNetUserLogins> AspNetUserLoginses => _aspNetUserLoginses.AsReadOnly();
    private readonly List<AspNetUserPasskeys> _aspNetUserPasskeyses = new();
    public virtual IReadOnlyCollection<AspNetUserPasskeys> AspNetUserPasskeyses => _aspNetUserPasskeyses.AsReadOnly();
    private readonly List<AspNetUserRoles> _aspNetUserRoleses = new();
    public virtual IReadOnlyCollection<AspNetUserRoles> AspNetUserRoleses => _aspNetUserRoleses.AsReadOnly();
    private readonly List<AspNetUserTokens> _aspNetUserTokenses = new();
    public virtual IReadOnlyCollection<AspNetUserTokens> AspNetUserTokenses => _aspNetUserTokenses.AsReadOnly();
    private readonly List<User> _users = new();
    public virtual IReadOnlyCollection<User> Users => _users.AsReadOnly();

    protected AspNetUsers() { }

    public static AspNetUsers Create()
    {
        return new AspNetUsers();
    }
}
