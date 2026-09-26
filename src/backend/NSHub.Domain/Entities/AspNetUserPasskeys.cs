using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AspNetUserPasskeys : BaseEntity<byte[]>
{
    public byte[] CredentialId { get; protected set; } = Array.Empty<byte>();
    public string UserId { get; protected set; } = string.Empty;
    public string Data { get; protected set; } = string.Empty;
    public override byte[] Id { get => CredentialId; protected set => CredentialId = value; }
    public virtual AspNetUsers? User { get; protected set; }

    protected AspNetUserPasskeys() { }

    public static AspNetUserPasskeys Create()
    {
        return new AspNetUserPasskeys();
    }
}
