using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class DocumentTypeWarehouseAccount : BaseEntity
{
    public Guid DocumentTypeId { get; set; }

    public Guid WarehouseAccountId { get; set; }

    public virtual DocumentType? DocumentType { get; set; }

    public virtual WarehouseAccount? WarehouseAccount { get; set; }

}
