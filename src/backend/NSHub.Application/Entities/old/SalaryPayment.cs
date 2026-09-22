using System;
using System.Collections.Generic;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryPayment : BaseEntity
{
    public Guid PaymentOrderSalaryDetailId { get; set; }

    public Guid EmployeeBankAccountId { get; set; }

    public string Currency { get; set; } = null!;

    public decimal AmountDocumentCurrency { get; set; }

    public bool ProcessPayment { get; set; }

    public DateTime ValueDate { get; set; }

    public Guid SalaryAccountId { get; set; }

    public virtual SalaryAccount? SalaryAccount { get; set; }
    public virtual EmployeeBankAccount? EmployeeBankAccount { get; set; }
    public virtual PaymentOrderSalaryDetailId? PaymentOrderSalaryDetail { get; set; }

}
