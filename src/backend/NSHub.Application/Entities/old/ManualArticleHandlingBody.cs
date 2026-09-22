using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class ManualArticleHandlingBody : BaseEntity
{

    public Guid ManualArticleHandlingHeaderId { get; set; }

    public Guid ArticleId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Amount { get; set; }

    public Guid DefaultArticleWarehouseId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Article? Article { get; set; }
    public virtual ManualArticleHandlingHeader? ManualArticleHandlingHeader { get; set; }
    public virtual DefaultArticleWarehouse? DefaultArticleWarehouse { get; set; }
}
