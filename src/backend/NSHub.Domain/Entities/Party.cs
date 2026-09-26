using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Party : BaseEntity
{
    public string? InternalCode { get; protected set; }
    public string PartyTypeCode { get; protected set; } = string.Empty;
    public string DisplayName { get; protected set; } = string.Empty;
    public string? TaxIdentificationNumber { get; protected set; }
    public string? VatNumber { get; protected set; }
    public string? Notes { get; protected set; }
    public bool IsActive { get; protected set; }
    public DateTimeOffset CreatedOn { get; protected set; }
    public DateTimeOffset UpdatedOn { get; protected set; }
    public virtual Person? Person { get; protected set; }
    public virtual Organization? Organization { get; protected set; }
    public virtual PartyType? PartyType { get; protected set; }

    private readonly List<Address> _addresses = new();
    public virtual IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
    private readonly List<ContactMechanism> _contactMechanisms = new();
    public virtual IReadOnlyCollection<ContactMechanism> ContactMechanisms => _contactMechanisms.AsReadOnly();
    private readonly List<PartyRelationship> _sourceRelationships = new();
    public virtual IReadOnlyCollection<PartyRelationship> SourceRelationships => _sourceRelationships.AsReadOnly();
    private readonly List<PartyRelationship> _targetRelationships = new();
    public virtual IReadOnlyCollection<PartyRelationship> TargetRelationships => _targetRelationships.AsReadOnly();

    protected Party() { }

    public static Party Create()
    {
        return new Party();
    }
}
