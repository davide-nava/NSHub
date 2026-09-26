// <copyright file="ContactChannelType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ContactChannelType : BaseEntity<string>
{
    public string ContactChannelTypeCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public override string Id { get => ContactChannelTypeCode; set => ContactChannelTypeCode = value; }

    private readonly List<ContactMechanism> _contactMechanisms = new();
    public virtual IReadOnlyCollection<ContactMechanism> ContactMechanisms => _contactMechanisms.AsReadOnly();

    protected ContactChannelType() { }

    public static ContactChannelType Create()
    {
        return new ContactChannelType();
    }
}
