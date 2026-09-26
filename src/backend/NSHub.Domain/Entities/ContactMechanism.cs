// <copyright file="ContactMechanism.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ContactMechanism : BaseEntity
{
    public Guid PartyId { get; protected set; }
    public string ContactChannelTypeCode { get; protected set; } = string.Empty;
    public string ContactValue { get; protected set; } = string.Empty;
    public string? UsageDescription { get; protected set; }
    public bool IsDefault { get; protected set; }
    public bool IsVerified { get; protected set; }
    public string? Notes { get; protected set; }
    public DateTimeOffset CreatedOn { get; protected set; }
    public virtual ContactChannelType? ContactChannelType { get; protected set; }
    public virtual Party? Party { get; protected set; }

    protected ContactMechanism() { }

    public static ContactMechanism Create()
    {
        return new ContactMechanism();
    }
}
