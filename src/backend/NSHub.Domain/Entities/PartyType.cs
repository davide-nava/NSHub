using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class PartyType : BaseEntity<string>
{
    public string PartyTypeCode { get; protected set; } = string.Empty;
    public string Name { get; protected set; } = string.Empty;
    public string? Description { get; protected set; }
    public override string Id { get => PartyTypeCode; protected set => PartyTypeCode = value; }

    private readonly List<Party> _parties = new();
    public virtual IReadOnlyCollection<Party> Parties => _parties.AsReadOnly();

    protected PartyType() { }

    public static PartyType Create()
    {
        return new PartyType();
    }
}
