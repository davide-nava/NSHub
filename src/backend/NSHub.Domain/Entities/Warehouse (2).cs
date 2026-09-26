using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Warehouse : AuditableTenantEntity
{
    public Guid PersonId { get; protected set; }
    public Guid AddressId { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public bool? IsExternal { get; protected set; }
    public string? OpeningTime { get; protected set; }
    public string? ClosingTime { get; protected set; }
    public string? Name { get; protected set; }
    public string? Notes { get; protected set; }
    public virtual Address? Address { get; protected set; }
    public virtual Person? Person { get; protected set; }

    private readonly List<Article> _articles = new();
    public virtual IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();
    private readonly List<OrderRow> _orderRows = new();
    public virtual IReadOnlyCollection<OrderRow> OrderRows => _orderRows.AsReadOnly();
    private readonly List<StockMovement> _targetStockMovements = new();
    public virtual IReadOnlyCollection<StockMovement> TargetStockMovements => _targetStockMovements.AsReadOnly();
    private readonly List<StockMovement> _stockMovements = new();
    public virtual IReadOnlyCollection<StockMovement> StockMovements => _stockMovements.AsReadOnly();
    private readonly List<WarehouseOrganization> _warehouseOrganizations = new();
    public virtual IReadOnlyCollection<WarehouseOrganization> WarehouseOrganizations => _warehouseOrganizations.AsReadOnly();

    protected Warehouse() { }

    public static Warehouse Create()
    {
        return new Warehouse();
    }
}
