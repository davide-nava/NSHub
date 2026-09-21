using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class Field : BaseEntity
{

    public string CodeTable { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool IsLocked { get; set; }

    public bool Visgrid { get; set; }


    public string CodeModule { get; set; } = null!;

    public string CodeSection { get; set; } = null!;

    public string CodeOperation { get; set; } = null!;

    public string License { get; set; } = null!;

    public string TranslateFrom { get; set; } = null!;

    // TODO: Check type
    public int ValueEditor { get; set; }

    public string CodeAppModule { get; set; } = null!;

    public string CodeAppOperation { get; set; } = null!;

    public string CodeAppSection { get; set; } = null!;

    public bool IsCustom { get; set; }

    public string AssignedCategory { get; set; } = null!;

    public string Davers { get; set; } = null!;

    public Guid TypeOfCustomControlId { get; set; }

    public Guid SourceLookupTableId { get; set; }

    public string SourceLookupExpression { get; set; } = null!;

    public bool IsSourceLookupExpressionMultiple { get; set; }

    public Guid SourceLookupFilterId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsAssignedCategoryLocked { get; set; }

    public bool IsNonReplaceable { get; set; }

    public string TooltipD { get; set; } = null!;

    public string TooltipE { get; set; } = null!;

    public string TooltipF { get; set; } = null!;

    public string TooltipI { get; set; } = null!;

    public Guid FieldTranscodeId { get; set; }

    public string SourceLookupFieldCondition { get; set; } = null!;

    public string ParentFormSource { get; set; } = null!;

    public bool IsManageBindWithParent { get; set; }

    public int Decimals { get; set; }

    public bool IsUpdateOnFocus { get; set; }

    public string ParentFormSourceQuery { get; set; } = null!;

    public bool IsManageBindWithQuery { get; set; }

    public Guid SensitiveLevelDataId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual Table? Table { get; set; }

}
