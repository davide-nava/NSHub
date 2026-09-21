using System;

namespace PlanetHub.ApplicationCore.Entities;

public class TechnicalReportTime : BaseEntity
{
    public Guid ArticleId { get; set; }

    public Guid TechnicalReportId { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public bool PriceVatIncluded { get; set; }

    public bool KeepPriceOnEdit { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Article? Article { get; set; }

    public virtual TechnicalReport? TechnicalReport { get; set; }
}
