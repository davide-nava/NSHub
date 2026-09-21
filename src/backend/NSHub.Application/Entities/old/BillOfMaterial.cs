using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class BillOfMaterial : BaseEntity
{
    public Guid ArticleId { get; set; }

    public Guid ProcessingPhaseId { get; set; }

    public decimal Quantity { get; set; }

    public Guid ArticleParentId { get; set; }

    public RoundType RoundType { get; set; }

    public decimal RoundStep { get; set; }

    public int Position { get; set; }


    public virtual ArticleParent? ArticleParent { get; set; }
    public virtual ProcessingPhase? ProcessingPhase { get; set; }
    public virtual Article? Article { get; set; }


    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }
}
