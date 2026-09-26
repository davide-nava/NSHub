// <copyright file="RelationshipType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class RelationshipType : BaseEntity<string>
{
    public string RelationshipTypeCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string SourceRole { get; set; } = string.Empty;
    public string TargetRole { get; set; } = string.Empty;
    public string? Description { get; set; }
    public override string Id { get => RelationshipTypeCode; set => RelationshipTypeCode = value; }

    private readonly List<PartyRelationship> _partyRelationships = new();
    public virtual IReadOnlyCollection<PartyRelationship> PartyRelationships => _partyRelationships.AsReadOnly();

    protected RelationshipType() { }

    public static RelationshipType Create()
    {
        return new RelationshipType();
    }
}
