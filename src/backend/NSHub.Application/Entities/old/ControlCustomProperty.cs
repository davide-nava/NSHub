using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class ControlCustomProperty : BaseEntity
{
    public Guid InputConfigurationId { get; set; }

    public string FormName { get; set; } = null!;

    public Guid FieldGroupId { get; set; }

    public int LocationX { get; set; }

    public int LocationY { get; set; }

    public string ControlName { get; set; } = null!;

    public int TabIndex { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public bool IsModified { get; set; }

    public bool IsDocked { get; set; }

    public bool IsVisible { get; set; }

    public string VisibleCondition { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual FieldGroup? FieldGroup { get; set; }
    public virtual InputConfigurationId? InputConfiguration { get; set; }

}
