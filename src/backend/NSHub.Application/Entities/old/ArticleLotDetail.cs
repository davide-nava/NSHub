using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ArticleLotDetail : BaseEntity
{
    public Guid ArticleLotId { get; set; }

    public decimal Quantity { get; set; }

    public IEnumerable<DecimalList> Amounts { get; set; }

    public string SessionGuid { get; set; } = null!;

    public virtual ArticleLot? ArticleLot { get; set; }


    public IEnumerable<TranslationGroupList> Texts { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

}
