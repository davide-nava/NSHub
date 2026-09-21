using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PaymentOrderSalaryDetail : BaseEntity
{

    public Guid PaymentOrderSalaryRowId { get; set; }

    public Guid SalaryPaymentId { get; set; }

    public decimal AmountDocumentCurrency { get; set; }

    public Guid EmployeeBankAccountId { get; set; }

    public string Currency { get; set; } = null!;


    public virtual EmployeeBankAccount? EmployeeBankAccount { get; set; }
    public virtual SalaryPayment? SalaryPayment { get; set; }
    public virtual PaymentOrderSalaryRow? PaymentOrderSalaryRow { get; set; }

}
