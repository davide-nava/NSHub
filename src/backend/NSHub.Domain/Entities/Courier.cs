// <copyright file="Courier.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Courier : AuditableTenantEntity
{
    public Guid? AddressId { get; protected set; }
    public Guid? ContactId { get; protected set; }
    public string? Name { get; protected set; }
    public string? Notes { get; protected set; }

    private readonly List<Shipment> _shipments = new();
    public virtual IReadOnlyCollection<Shipment> Shipments => _shipments.AsReadOnly();

    protected Courier() { }

    public static Courier Create()
    {
        return new Courier();
    }
}
