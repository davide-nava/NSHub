// <copyright file="ItemUomConversion.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class ItemUomConversion : BaseEntity
{
    public Guid ItemId { get; set; }

    public Guid FromUomId { get; set; }

    public Guid ToUomId { get; set; }

    public decimal Factor { get; set; }

    public virtual Item? Item { get; set; }

    public virtual UnitOfMeasure? FromUom { get; set; }

    public virtual UnitOfMeasure? ToUom { get; set; }

}
