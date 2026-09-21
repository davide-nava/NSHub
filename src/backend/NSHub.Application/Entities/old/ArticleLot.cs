using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ArticleLot : BaseEntity
{
    public Guid ArticleId { get; set; }

    public string Number { get; set; } = null!;

    public DateTime DateProduction { get; set; }

    public DateTime DateEnd { get; set; }

    public DateTime DateRetest { get; set; }

    public IEnumerable<DecimalList> Amounts { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public IEnumerable<TranslationGroup> Texts { get; set; }


    public DateTime DateEnter { get; set; }

    public virtual Article? Article { get; set; }

}
