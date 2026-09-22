using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class FieldCustomProperty : BaseEntity
{
    public Guid FieldId { get; set; }

    public Guid InputConfigurationId { get; set; }

    public virtual InputConfiguration? InputConfiguration { get; set; }
    public virtual Field? Field { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int LocationX { get; set; }

    public int LocationY { get; set; }

    public bool AlertOnChange { get; set; }

    public bool CanUpdate { get; set; }

    public bool CanWrite { get; set; }

    public bool OnlyFromList { get; set; }

    public bool IsRequired { get; set; }

    public bool IsVisible { get; set; }

    public string AlertOnChangeCondition { get; set; } = null!;

    public string CanUpdateCondition { get; set; } = null!;

    public string CanWriteCondition { get; set; } = null!;

    public string OnlyFromListCondition { get; set; } = null!;

    public string RequiredCondition { get; set; } = null!;

    public string VisibleCondition { get; set; } = null!;

    public Guid FieldGroupId { get; set; }
    public virtual FieldGroup? FieldGroup { get; set; }

    public string ConfigProperties { get; set; } = null!;

    public int TabIndex { get; set; }

    public int LabelWidth { get; set; }

    public bool InsertWithEnter { get; set; }

    public bool Validation { get; set; }

    public string ValidationCondition { get; set; } = null!;

    public Guid DescriptionValidationMessageId { get; set; }

    public virtual TranslationGroup? DescriptionValidationMessage { get; set; }

    public virtual DefaultValueFormula? DefaultValueFormula { get; set; }

    public Guid DefaultValueFormulaId { get; set; }

    public string BaseQuery { get; set; } = null!;

    public bool IsModified { get; set; }

    public int LoadingMode { get; set; }

    public int LoadingThreshold { get; set; }

    public Guid CustomFunctionFormulaId { get; set; }

    public virtual CustomFunctionFormula? CustomFunctionFormula { get; set; }

    public bool EnableQrCodeReader { get; set; }

}
