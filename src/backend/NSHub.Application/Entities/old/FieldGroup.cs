using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class FieldGroup : BaseEntity
{

    public int Index { get; set; }

    public Guid InputConfigurationId { get; set; }

    public bool IsCustom { get; set; }

    public string RealControlName { get; set; } = null!;

    public bool IsVisible { get; set; }

    public string VisibleCondition { get; set; } = null!;

    public string CustomControlName { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual InputConfiguration? InputConfiguration { get; set; }


}
