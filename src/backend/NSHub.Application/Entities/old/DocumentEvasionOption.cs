using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class DocumentEvasionOption : BaseEntity
{
    public Guid DocumentEvasionConfigurationId { get; set; }

    public bool IsUpdateExchangeRate { get; set; }

    public bool IsRecalculatePrices { get; set; }

    public bool IsEvadeWarehouseOnly { get; set; }

    public bool IsEvadeEmptyRows { get; set; }

    public bool IsKeepOriginalBodyFree { get; set; }

    public bool IsKeepOriginalCorrespondentData { get; set; }

    public bool KeepOriginalCompetenceDates { get; set; }

    public bool IsEvadeBillOfMaterial { get; set; }

    public bool DoNotEvadeZeroQuantity { get; set; }

    public bool AlignQuantityProcessedDocument { get; set; }

    public bool ShowGeneratedDocument { get; set; }

    public bool PrintGeneratedDocuments { get; set; }

    public bool IsKeepAttachments { get; set; }

    public bool IsEvadeOnPreviousDate { get; set; }

    public bool IsEvadeWarehouseComplete { get; set; }

    public virtual DocumentEvasionConfiguration? DocumentEvasionConfiguration { get; set; }

}
