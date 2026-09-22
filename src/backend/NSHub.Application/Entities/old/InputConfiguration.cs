using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class InputConfiguration : BaseEntity
{
    public string FormName { get; set; } = null!;

    public string FormUniqueId { get; set; } = null!;

    public bool IsDefault { get; set; }

    public InputConfigurationType InputConfigurationType { get; set; }

    public bool IsFontBold { get; set; }

    public bool IsFontItalic { get; set; }

    public bool IsFontUnderlined { get; set; }

    public ColorType FontColor { get; set; }

    public WebInputType WebInputType { get; set; }

    public string AssociatedUsers { get; set; } = null!;

    public ColorType BackgroundColor { get; set; }

    public string AssociatedUsersWeb { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
