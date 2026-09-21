using System;

namespace PlanetHub.ApplicationCore.Entities;

public class RecallCustom : BaseEntity
{

    public Guid RecallGroupId { get; set; }

    public virtual RecallGroup? RecallGroup { get; set; }

    public Guid TitleId { get; set; }

    public virtual TranslationGroup? Title { get; set; }

    public Guid DescriptionHeaderId { get; set; }
    public virtual TranslationGroup? DescriptionHeader { get; set; }
    public Guid DescriptionFooterId { get; set; }

    public virtual TranslationGroup? DescriptionFooter { get; set; }
}
