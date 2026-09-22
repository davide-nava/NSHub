// <copyright file="InvoiceAlreadyIssuedException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Exceptions;

/// <summary>
/// Exception thrown when attempting to modify lines or properties of an invoice that has already been issued.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="InvoiceAlreadyIssuedException"/> class.
/// </remarks>
/// <param name="invoiceNumber">The issued invoice document number.</param>
public class InvoiceAlreadyIssuedException(string invoiceNumber) : DomainException("Invoice.AlreadyIssued", $"Invoice '{invoiceNumber}' has already been issued and cannot be modified.")
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceAlreadyIssuedException"/> class.
    /// </summary>
    /// <param name="invoiceId">The invoice unique identifier.</param>
    public InvoiceAlreadyIssuedException(Guid invoiceId)
        : this(invoiceId.ToString())
    {
    }
}
