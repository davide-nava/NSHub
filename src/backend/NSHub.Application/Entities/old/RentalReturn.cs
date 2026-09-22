using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class RentalReturn : BaseEntity
{

    public Guid RentalArticleId { get; set; }

    public DateTime DateTimeReturn { get; set; }

    public decimal Quantity { get; set; }

    public bool IsDamaged { get; set; }

    public string SessionGuid { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual RentalArticle? RentalArticle { get; set; }
}
