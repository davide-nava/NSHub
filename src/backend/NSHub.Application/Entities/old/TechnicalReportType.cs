using System;

using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class TechnicalReportType : BaseEntity
{
    public Guid DescriptionId { get; set; }

    public bool ExcludeBlockedCor { get; set; }

    public Guid DocumentTypeTemplateId { get; set; }

    public bool KeepTemplatePricesOnEdit { get; set; }

    public Guid FilterSubscriptionId { get; set; }

    public string SubscriptionStoreProcedure { get; set; } = null!;

    public bool DoNotProposeEmail { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual DocumentType? DocumentTypeTemplate { get; set; }
}
