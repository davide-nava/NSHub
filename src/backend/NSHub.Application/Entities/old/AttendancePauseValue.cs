using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendancePauseValue : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid AccountShortPauseId { get; set; }

    public Guid AccountOfficePauseId { get; set; }

    public string WorkedValueCategoryId { get; set; } = null!;

    public string PauseValueCategoryId { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual AccountShortPause? AccountShortPause { get; set; }

    public virtual AccountOfficePause? AccountOfficePause { get; set; }


}
