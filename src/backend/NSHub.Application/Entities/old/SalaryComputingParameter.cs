using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryComputingParameter : BaseEntity
{
    public string IfCondition { get; set; } = null!;

    public string Condition { get; set; } = null!;

    public string WithCondition { get; set; } = null!;

    public IEnumerable<StringGroupList> IfOperators { get; set; }
    public IEnumerable<StringGroupList> ElseOperator { get; set; }

    public SumType SumType { get; set; }

    public string SubjectToBases { get; set; } = null!;

    public string PrintCode { get; set; }

    public string Base { get; set; } = null!;

    public string TaxRate { get; set; } = null!;

    public RoundingType RoundingType { get; set; }

    public decimal RoundingValue { get; set; }

    public bool BaseSelected { get; set; }

    public bool TaxRateSelected { get; set; }

    public Guid SalaryComputingValidityId { get; set; }

    // TODO: Check type
    public int Sign { get; set; }

    public string SwissdecTaxSalaryCode { get; set; }

    public string SwissdecStatisticCode { get; set; }

    public bool PrintOnSalaryReport { get; set; }

    public bool ShowOnDirectoryParameter { get; set; }

    public bool EnableNetGrossCompensation { get; set; }

    public bool EnableNetSalaryCompensation { get; set; }

    public DateTime EditDate { get; set; }

    public bool DoNotSumIfNegative { get; set; }

    public bool UseForAccountPlan { get; set; }

    public LppComputingType LppComputingType { get; set; }

    // TODO: Check type
    public int LppPeriod { get; set; }

    public bool FontBold { get; set; }

    public bool FontItalic { get; set; }

    public bool FontOpaque { get; set; }

    public bool FontUnderline { get; set; }

    public ComputationType ComputationType { get; set; }

    public string ExternalCode { get; set; } = null!;

    public bool IterationEnable { get; set; }


    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    // TODO: Check type
    public int WorkDaysChCompetence { get; set; }

    public WorkDaysChModeType WorkDaysChModeType { get; set; }

    public KlecomputingType KlecomputingType { get; set; }

    public Guid KlestatisticGroupId { get; set; }

    public Guid KlefactorId { get; set; }

    public Guid ComputingCategoryId { get; set; }

    public bool IsDisabled { get; set; }

    public Guid FormulaId { get; set; }

    public string GroupSalary { get; set; } = null!;

    public IEnumerable<IntList> SalaryMicrosoftBis { get; set; }

    public Guid SalaryAccountId { get; set; }

    public Guid JsformulaBaseId { get; set; }

    public Guid JsformulaTaxRate { get; set; }

    public string StandardComputingCode { get; set; } = null!;


    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public Guid DescriptionAdditionalId { get; set; }

    public virtual TranslationGroup? DescriptionAdditional { get; set; }

}
