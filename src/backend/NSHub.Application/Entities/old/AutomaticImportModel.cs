using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class AutomaticImportModel : BaseEntity
{
    public PriorityType PriorityType { get; set; }

    public ModelType ModelType { get; set; }

    public Guid AutomaticImportModelParentId { get; set; }

    public decimal PositionX { get; set; }

    public decimal PositionY { get; set; }

    public decimal AreaWidth { get; set; }

    public decimal AreaHeight { get; set; }

    public MatchModeType MatchModeType { get; set; }

    public string Prefix { get; set; } = null!;

    public string Suffix { get; set; } = null!;

    public bool IsActive { get; set; }

    public int NumPage { get; set; }

    public bool IsLastPage { get; set; }

    public FormatModeType FormatModeType { get; set; }

    public Guid LayoutId { get; set; }

    public string DecimalsSeparator { get; set; } = null!;

    public string ThousandsSeparator { get; set; } = null!;

    public virtual AutomaticImportModel? AutomaticImportModelParentId { get; set; }
    public virtual AutomaticImportLayout? AutomaticImportLayout { get; set; }


    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


}
