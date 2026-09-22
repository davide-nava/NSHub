using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ArticlesSupplier : BaseEntity
{
    public Guid ArticleId { get; set; }

    public Guid CorrespondentId { get; set; }

    public decimal MinimumOrder { get; set; }

    public decimal MinimumLot { get; set; }

    public string SupplierArticleCode { get; set; } = null!;

    public string Note { get; set; } = null!;

    public bool IsDefault { get; set; }

    public virtual Article? Article { get; set; }

    public virtual Correspondent? Correspondent { get; set; }
}
