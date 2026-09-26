using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class PartyRelationship : BaseEntity
{
    public Guid SourcePartyId { get; protected set; }
    public Guid TargetPartyId { get; protected set; }
    public string RelationshipTypeCode { get; protected set; } = string.Empty;
    public DateTime ValidFrom { get; protected set; }
    public DateTime? ValidTo { get; protected set; }
    public string? Notes { get; protected set; }
    public DateTimeOffset CreatedOn { get; protected set; }
    public virtual Party? SourceParty { get; protected set; }
    public virtual Party? TargetParty { get; protected set; }
    public virtual RelationshipType? RelationshipType { get; protected set; }

    protected PartyRelationship() { }

    public static PartyRelationship Create()
    {
        return new PartyRelationship();
    }
}
