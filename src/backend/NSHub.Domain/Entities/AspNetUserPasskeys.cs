// <copyright file="AspNetUserPasskeys.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AspNetUserPasskeys : BaseEntity<byte[]>
{
    public byte[] CredentialId { get; set; } = Array.Empty<byte>();
    public string UserId { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public override byte[] Id { get => CredentialId; set => CredentialId = value; }
    public virtual AspNetUsers? User { get; protected set; }

    protected AspNetUserPasskeys() { }

    public static AspNetUserPasskeys Create()
    {
        return new AspNetUserPasskeys();
    }
}
