using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities;
using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ActivityType : BaseEntity
{
    public Guid DescriptionId { get; set; }

    public ActivityGenderType ActivityGenderType { get; set; }

    public bool DefaultFromActivityManagement { get; set; }

    public Guid RelatedPlanningActivityId { get; set; }

    public string PrimaryResources { get; set; } = null!;

    public string SecondaryResources { get; set; } = null!;

    public int ExpiringOffset { get; set; }

    public Guid TemplateMailId { get; set; }

    public string Report { get; set; } = null!;

    public bool ShowCustomerGenericObjects { get; set; }

    public bool ShowOwnGenericObjects { get; set; }

    public bool ExcludeBlockedCor { get; set; }

    public string SmsPatternText { get; set; } = null!;

    public virtual RelatedPlanningActivity? RelatedPlanningActivity { get; set; }
    public virtual TemplateMail? TemplateMail { get; set; }


    public virtual TranslationGroup? Description { get; set; }
}
