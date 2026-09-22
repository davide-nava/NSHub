// <copyright file="Invoice.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Enums;
using NSHub.Domain.Exceptions;

namespace NSHub.Domain.Entities;

/// <summary>
/// Aggregate root representing a sales invoice, itemized lines, and tax calculations.
/// Enforces line immutability upon transition to the Issued status.
/// </summary>
public class Invoice : AggregateRoot<InvoiceId>
{
    private readonly List<InvoiceLine> _lines = [];

    /// <summary>
    /// Gets the customer identifier.
    /// </summary>
    public CustomerId CustomerId { get; set; }

    /// <summary>
    /// Gets the formal invoice number assigned upon issuance (e.g., "INV-2026-00042").
    /// </summary>
    public string InvoiceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets the current invoice lifecycle status.
    /// </summary>
    public InvoiceStatus Status { get; set; }

    /// <summary>
    /// Gets the agreed payment terms.
    /// </summary>
    public PaymentTerm PaymentTerm { get; set; }

    /// <summary>
    /// Gets the UTC issuance date.
    /// </summary>
    public DateTime? IssueDateUtc { get; set; }

    /// <summary>
    /// Gets the payment due date based on issuance date and payment terms.
    /// </summary>
    public DateTime? DueDateUtc { get; set; }

    /// <summary>
    /// Gets the UTC creation timestamp.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Gets the itemized lines collection.
    /// </summary>
    public IReadOnlyCollection<InvoiceLine> Lines => _lines.AsReadOnly();

    /// <summary>
    /// Gets the aggregated net total amount before taxes.
    /// </summary>
    public decimal TotalNet => _lines.Sum(l => l.LineTotalNet);

    /// <summary>
    /// Gets the aggregated VAT amount.
    /// </summary>
    public decimal TotalVat => _lines.Sum(l => l.LineTotalVat);

    /// <summary>
    /// Gets the aggregated gross total amount (Net + VAT).
    /// </summary>
    public decimal TotalGross => _lines.Sum(l => l.LineTotalGross);

    // Parameterless constructor for EF Core
    private Invoice()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Invoice"/> aggregate root in Draft status.
    /// </summary>
    public Invoice(
        InvoiceId id,
        CustomerId customerId,
        PaymentTerm paymentTerm)
    {
        if (customerId.Value == Guid.Empty)
        {
            throw new BusinessRuleValidationException("Invoice.CustomerRequired", "Customer identifier is mandatory.");
        }

        Id = id.Value == Guid.Empty ? InvoiceId.New() : id;
        CustomerId = customerId;
        InvoiceNumber = string.Empty;
        Status = InvoiceStatus.Draft;
        PaymentTerm = paymentTerm;
        CreatedAtUtc = DateTime.UtcNow;
    }

    /// <summary>
    /// Adds a line item to the draft invoice.
    /// </summary>
    public InvoiceLine AddLine(
        string description,
        decimal quantity,
        decimal unitPrice,
        decimal discountPercentage,
        decimal vatRate)
    {
        EnsureDraft();

        var line = new InvoiceLine(
            InvoiceLineId.New(),
            Id,
            description,
            quantity,
            unitPrice,
            discountPercentage,
            vatRate);

        _lines.Add(line);
        return line;
    }

    /// <summary>
    /// Removes an itemized line from the draft invoice.
    /// </summary>
    public void RemoveLine(InvoiceLineId lineId)
    {
        EnsureDraft();

        _ = _lines.RemoveAll(l => l.Id == lineId);
    }

    /// <summary>
    /// Formally issues the invoice, locking all line items and assigning the sequential invoice number.
    /// </summary>
    /// <param name="invoiceNumber">The sequential invoice number.</param>
    /// <param name="issueDateUtc">The official issue timestamp.</param>
    public void Issue(string invoiceNumber, DateTime issueDateUtc)
    {
        if (Status != InvoiceStatus.Draft)
        {
            throw new InvalidStateTransitionException(
                Status.ToString(),
                nameof(InvoiceStatus.Issued),
                "Only draft invoices can be issued.");
        }

        if (_lines.Count == 0)
        {
            throw new BusinessRuleValidationException("Invoice.NoLines", "Cannot issue an invoice without lines.");
        }

        if (string.IsNullOrWhiteSpace(invoiceNumber))
        {
            throw new BusinessRuleValidationException("Invoice.NumberRequired", "Sequential invoice number is mandatory upon issue.");
        }

        InvoiceNumber = invoiceNumber.Trim();
        Status = InvoiceStatus.Issued;
        IssueDateUtc = issueDateUtc;
        DueDateUtc = issueDateUtc.AddDays((int)PaymentTerm);
    }

    /// <summary>
    /// Marks the issued invoice as settled upon payment confirmation.
    /// </summary>
    public void MarkPaid()
    {
        if (Status != InvoiceStatus.Issued)
        {
            throw new InvalidStateTransitionException(
                Status.ToString(),
                nameof(InvoiceStatus.Paid),
                "Only issued invoices can be marked as paid.");
        }

        Status = InvoiceStatus.Paid;
    }

    /// <summary>
    /// Cancels the invoice.
    /// </summary>
    public void Cancel()
    {
        if (Status == InvoiceStatus.Paid)
        {
            throw new InvalidStateTransitionException(
                Status.ToString(),
                nameof(InvoiceStatus.Cancelled),
                "Paid invoices cannot be cancelled directly; issue a credit note instead.");
        }

        Status = InvoiceStatus.Cancelled;
    }

    private void EnsureDraft()
    {
        if (Status != InvoiceStatus.Draft)
        {
            throw new InvoiceAlreadyIssuedException(Id.Value);
        }
    }
}
