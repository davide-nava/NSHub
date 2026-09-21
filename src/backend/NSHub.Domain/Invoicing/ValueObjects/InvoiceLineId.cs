// <copyright file="InvoiceLineId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Invoicing.ValueObjects;

/// <summary>
/// Strongly-typed identifier for an invoice line.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct InvoiceLineId(Guid Value)
{
    /// <summary>
    /// Initializes an empty invoice line identifier.
    /// </summary>
    public static InvoiceLineId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique invoice line identifier.
    /// </summary>
    public static InvoiceLineId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(InvoiceLineId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator InvoiceLineId(Guid value) => new(value);
}
