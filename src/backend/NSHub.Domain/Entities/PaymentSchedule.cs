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
    /// Gets the invoice identifier.
    /// </summary>
    public Guid InvoiceId { get; protected set; }

    /// <summary>
    /// Gets the installment number.
    /// </summary>
    public int InstallmentNumber { get; protected set; }

    /// <summary>
    /// Gets the payment due date.
    /// </summary>
    public DateTime DueDate { get; protected set; }

    /// <summary>
    /// Gets the installment amount.
    /// </summary>
    public decimal Amount { get; protected set; }

    /// <summary>
    /// Gets the amount already paid.
    /// </summary>
    public decimal PaidAmount { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the installment has been paid.
    /// </summary>
    public bool IsPaid { get; protected set; }

    /// <summary>
    /// Gets the payment date.
    /// </summary>
    public DateTime? PaymentDate { get; protected set; }

    /// <summary>
    /// Gets the bank account identifier.
    /// </summary>
    public Guid? BankAccountId { get; protected set; }

    /// <summary>
    /// Gets the bank account associated with the payment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual BankAccount? BankAccount { get; protected set; }

    /// <summary>
    /// Gets the invoice associated with the payment schedule.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Invoice? Invoice { get; protected set; }
}
