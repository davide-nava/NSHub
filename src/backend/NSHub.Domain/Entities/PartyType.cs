// <copyright file="PartyType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class PartyType : BaseEntity<string>
{
    public string PartyTypeCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public override string Id { get => PartyTypeCode; set => PartyTypeCode = value; }

    private readonly List<Party> _parties = new();
    public virtual IReadOnlyCollection<Party> Parties => _parties.AsReadOnly();

    protected PartyType() { }

    public static PartyType Create()
    {
        return new PartyType();
    }
}
