using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class DocumentRow : BaseEntity
{

    public Guid DocumentId { get; set; }

    public string ArticleCode { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public LendingType LendingType { get; set; }

    public decimal PurchasePrice { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual Document? Document { get; set; }

}
