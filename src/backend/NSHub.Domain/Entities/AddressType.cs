using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class AddressType : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    private readonly List<Address> _addresses = new();
    public virtual IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    protected AddressType() { }

    public static AddressType Create()
    {
        return new AddressType();
    }
}
