using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryAccountingBody : BaseEntity
{

    public Guid SalaryAccountingHeaderId { get; set; }

    public Guid DebitAccountId { get; set; }

    public Guid CreditAccountId { get; set; }

    public Guid SalaryAccountId { get; set; }


    public virtual DebitAccount? DebitAccount { get; set; }
    public virtual CreditAccount? CreditAccount { get; set; }
    public virtual SalaryAccount? SalaryAccount { get; set; }

    public virtual SalaryAccountingHeader? SalaryAccountingHeader { get; set; }
}
