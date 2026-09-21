using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class ItemUomConversion : BaseEntity
{
    public int ItemUomConversionId { get; set; }

    public int ItemId { get; set; }

    public int FromUomId { get; set; }

    public int ToUomId { get; set; }

    public decimal Factor { get; set; }

    public virtual UnitOfMeasure FromUom { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;

    public virtual UnitOfMeasure ToUom { get; set; } = null!;
}
