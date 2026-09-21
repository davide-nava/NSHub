using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendanceStatistic : BaseEntity
{
    public Guid FormulaId { get; set; }

    public ResultType ResultType { get; set; }

    public PlanetHub.Enums.ValueType ValueType { get; set; }

    public string FixedColumn { get; set; } = null!;

    public bool IsVisibleOnAnnualFolder { get; set; }

    public Guid DescriptionId { get; set; }

    public Guid DescriptionShortId { get; set; }


    public virtual Formula? Formula { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual TranslationGroup? DescriptionShort { get; set; }
}
