using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ContactChannelType : BaseEntity<string>
{
    public string ContactChannelTypeCode { get; protected set; } = string.Empty;
    public string Name { get; protected set; } = string.Empty;
    public string? Description { get; protected set; }
    public override string Id { get => ContactChannelTypeCode; protected set => ContactChannelTypeCode = value; }

    private readonly List<ContactMechanism> _contactMechanisms = new();
    public virtual IReadOnlyCollection<ContactMechanism> ContactMechanisms => _contactMechanisms.AsReadOnly();

    protected ContactChannelType() { }

    public static ContactChannelType Create()
    {
        return new ContactChannelType();
    }
}
