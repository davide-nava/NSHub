using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class DocumentEvasionBodyGroupType : BaseEntity
{
    public Guid DocumentEvasionConfigurationId { get; set; }


    public GroupingType GroupingType { get; set; }

    public DetailedModeType DetailedModeType { get; set; }

    public bool IsGroupByPrice { get; set; }

    public int SubtotalsSourceDocument { get; set; }

    public int SubtotalsArticle { get; set; }

    public bool IsDetailedSourceOmitHeader { get; set; }

    public Guid DescriptionDetailedSourceHeaderMessageId { get; set; }

    public virtual TranslationGroup? DescriptionDetailedSourceHeaderMessage { get; set; }


    public bool IsDetailedSourceOmitSubtotal { get; set; }



    public Guid DescriptionDetailedSourceSubtotalMessageId { get; set; }

    public virtual TranslationGroup? DescriptionDetailedSourceSubtotalMessage { get; set; }

    public Guid DescriptionSubtotalsSourceDocumentMessageId { get; set; }

    public virtual TranslationGroup? DescriptionSubtotalsSourceDocumentMessage { get; set; }


    public virtual DocumentEvasionConfiguration? DocumentEvasionConfiguration { get; set; }
}
