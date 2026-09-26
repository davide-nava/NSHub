using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Organization : BaseEntity
{
    public string LegalName { get; protected set; } = string.Empty;
    public string? TradeName { get; protected set; }
    public string? LegalForm { get; protected set; }
    public string? ElectronicInvoicingCode { get; protected set; }
    public string? CommercialRegisterNumber { get; protected set; }
    public decimal? ShareCapital { get; protected set; }
    public string? CurrencyCode { get; protected set; }
    public virtual Party? Party { get; protected set; }

    private readonly List<WarehouseOrganization> _warehouseOrganizations = new();
    public virtual IReadOnlyCollection<WarehouseOrganization> WarehouseOrganizations => _warehouseOrganizations.AsReadOnly();

    protected Organization() { }

    public static Organization Create()
    {
        return new Organization();
    }
}
