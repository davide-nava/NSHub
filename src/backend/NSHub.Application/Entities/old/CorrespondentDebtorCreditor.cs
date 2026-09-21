using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class CorrespondentDebtorCreditor : BaseEntity
{

    public Guid CorrespondentId { get; set; }

    public Guid CurrencyId { get; set; }

    public Guid AccountPlanCollectiveId { get; set; }

    public Guid CounterpartDefaultId { get; set; }

    public RecordType RecordType { get; set; }

    public Guid CheckingAccountId { get; set; }

    public CheckingAccountPaymentType CheckingAccountPaymentType { get; set; }

    public Guid CorrespondentBankAccountId { get; set; }

    public CorrespondentBankAccountModeType CorrespondentBankAccountModeType { get; set; }

    public Guid CostCenterId { get; set; }

    public bool IsDefault { get; set; }

    public Guid VatDefaultId { get; set; }

    public VatType VatType { get; set; }

    public virtual Vat? VatDefaul { get; set; }
    public virtual CostCenter? CostCenter { get; set; }
    public virtual CorrespondentBankAccount? CorrespondentBankAccount { get; set; }
    public virtual CheckingAccount? CheckingAccount { get; set; }

    public virtual Counterpart? CounterpartDefault { get; set; }
    public virtual AccountPlan? AccountPlanCollective { get; set; }
    public virtual Currency? Currency { get; set; }
    public virtual Correspondent? Correspondent { get; set; }
}
