// <copyright file="PaymentSchedule.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a payment schedule installment associated with an invoice.
/// </summary>
public class PaymentSchedule : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the invoice identifier.
    /// </summary>
    public Guid InvoiceId { get; set; }

    /// <summary>
    /// Gets or sets the installment number.
    /// </summary>
    public int InstallmentNumber { get; set; }

    /// <summary>
    /// Gets or sets the payment due date.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Gets or sets the installment amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the amount already paid.
    /// </summary>
    public decimal PaidAmount { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the installment has been paid.
    /// </summary>
    public bool IsPaid { get; set; }

    /// <summary>
    /// Gets or sets the payment date.
    /// </summary>
    public DateTime? PaymentDate { get; set; }

    /// <summary>
    /// Gets or sets the bank account identifier.
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// Gets or sets the bank account associated with the payment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual BankAccount? BankAccount { get; set; }

    /// <summary>
    /// Gets or sets the invoice associated with the payment schedule.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Invoice? Invoice { get; set; }
}
