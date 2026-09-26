// <copyright file="PaymentSchedule.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class PaymentSchedule : AuditableTenantEntity
{
    public Guid InvoiceId { get; protected set; }
    public int InstallmentNumber { get; protected set; }
    public DateTime DueDate { get; protected set; }
    public decimal Amount { get; protected set; }
    public decimal PaidAmount { get; protected set; }
    public bool IsPaid { get; protected set; }
    public DateTime? PaymentDate { get; protected set; }
    public Guid? BankAccountId { get; protected set; }
    public virtual BankAccount? BankAccount { get; protected set; }
    public virtual Invoice? Invoice { get; protected set; }

    protected PaymentSchedule() { }

    public static PaymentSchedule Create()
    {
        return new PaymentSchedule();
    }
}
