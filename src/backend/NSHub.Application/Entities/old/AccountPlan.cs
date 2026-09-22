using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AccountPlan : BaseEntity
{
    public string Code { get; set; } = null!;

    public GenderType GenderTypeAccount { get; set; }

    public bool Hidden { get; set; }

    public int AccountNature { get; set; }

    public int BalanceNature { get; set; }

    public decimal VatRatio { get; set; }

    public Guid VatId { get; set; }

    public Guid CostCenterId { get; set; }

    public decimal ReferenceFigureBc { get; set; }

    public string Currency { get; set; } = null!;

    public decimal ReferenceFigureFc { get; set; }

    public IEnumerable<GuidList> HierarchyLeves { get; set; }

    public Guid AccountLevelEntryId { get; set; }

    public bool UseOnBill { get; set; }

    public bool UseOnAdvance { get; set; }

    public string VatAvailable { get; set; } = null!;

    public string CounterpartTypes { get; set; } = null!;

    public CashingType CashingType { get; set; }

    public bool IsDivideMandatory { get; set; }

    public bool SkipForTransitoryAccounting { get; set; }

    public Guid ReclassifiedId { get; set; }

    public bool InternalJob { get; set; }

    public Guid ExchangeProfitDiffAccountId { get; set; }

    public Guid ExchangeLossDiffAccountId { get; set; }

    public Guid ExchangeProfitDiffOpenEntryId { get; set; }

    public Guid ExchangeLossDiffOpenEntryId { get; set; }

    public bool IsDefaultAdvance { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
