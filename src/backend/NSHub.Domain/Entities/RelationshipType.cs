using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class RelationshipType : BaseEntity<string>
{
    public string RelationshipTypeCode { get; protected set; } = string.Empty;
    public string Name { get; protected set; } = string.Empty;
    public string SourceRole { get; protected set; } = string.Empty;
    public string TargetRole { get; protected set; } = string.Empty;
    public string? Description { get; protected set; }
    public override string Id { get => RelationshipTypeCode; protected set => RelationshipTypeCode = value; }

    private readonly List<PartyRelationship> _partyRelationships = new();
    public virtual IReadOnlyCollection<PartyRelationship> PartyRelationships => _partyRelationships.AsReadOnly();

    protected RelationshipType() { }

    public static RelationshipType Create()
    {
        return new RelationshipType();
    }
}
