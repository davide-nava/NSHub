using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ArticleInputBody : BaseEntity
{
    public Guid ArticleInputId { get; set; }

    public Guid ArticleId { get; set; }

    public string LotNumber { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Article? Article { get; set; }

    public virtual Article? ArticleInput { get; set; }
}
