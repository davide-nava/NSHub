using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class GenericObjectDetail : BaseEntity
{
    public Guid GenericObjectId { get; set; }

    public StatusType StatusType { get; set; }

    public decimal AmountPurchaseVatExcluded { get; set; }

    public Guid VatId { get; set; }

    public decimal AmountSale { get; set; }

    public Guid IdTableId1 { get; set; }

    public IEnumerable<TranslationGroupList> Texts { get; set; }

    public Guid CurrentCorrespondentId { get; set; }

    public Guid PreviousCorrespondentId { get; set; }

    public decimal Counter { get; set; }

    public string Plate { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public Guid NextRecordId { get; set; }

    public IEnumerable<GuidList> Correspondents { get; set; }


    public Guid SupplierId { get; set; }

    public Guid LocationId { get; set; }

    public bool IsVisibleOnPlanning { get; set; }

}
