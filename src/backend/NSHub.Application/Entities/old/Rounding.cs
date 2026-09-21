using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class Rounding : BaseEntity
{

    public string Code { get; set; } = null!;

    public int Value { get; set; }

    public int RebateValue { get; set; }

    public int MinimumValue { get; set; }

    public int MaximumValue { get; set; }

    public Guid AccountExcessId { get; set; }

    public Guid AccountDefectId { get; set; }

    public Guid AccountRebateExcessId { get; set; }

    public Guid AccountRoundingDefectId { get; set; }

    // TODO: Check type
    public int NextValue { get; set; }

    // TODO: Check type
    public int RebateNextValue { get; set; }

    public Guid AccountRebateNextExcessId { get; set; }

    public Guid AccountRoundingNextDefectId { get; set; }

    // TODO: Check type
    public int UseWorkingTimeForMaximumValue { get; set; }

    // TODO: Check type
    public int UseWorkingTimeForMinimumValue { get; set; }

    public virtual AccountExcess? AccountExcess { get; set; }
    public virtual AccountDefect? AccountDefect { get; set; }
    public virtual AccountRebateExcess? AccountRebateExcess { get; set; }
    public virtual AccountRoundingDefect? AccountRoundingDefect { get; set; }
    public virtual AccountRoundingNextDefect? AccountRoundingNextDefect { get; set; }


    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
