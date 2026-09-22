using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Provision : BaseEntity
{
    public Guid DossierRowId { get; set; }

    public Guid RegCategoryId { get; set; }

    // TODO: Check type
    public int Billing { get; set; }

    public decimal Amount { get; set; }

    public Guid DocumentTypeProcessingId { get; set; }

    public Guid ProcessedId { get; set; }

    public virtual Processed? Processed { get; set; }
    public virtual DocumentTypeProcessing? DocumentTypeProcessing { get; set; }
    public virtual RegCategory? RegCategory { get; set; }

    public virtual DossierRow? DossierRow { get; set; }
}
