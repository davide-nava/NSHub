// <copyright file="InvoiceId.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Invoicing.ValueObjects;

/// <summary>
/// Strongly-typed identifier for a sales invoice.
/// </summary>
/// <param name="Value">The underlying Guid value.</param>
public readonly record struct InvoiceId(Guid Value)
{
    /// <summary>
    /// Initializes an empty invoice identifier.
    /// </summary>
    public static InvoiceId Empty => new(Guid.Empty);

    /// <summary>
    /// Generates a new unique invoice identifier.
    /// </summary>
    public static InvoiceId New() => new(Guid.NewGuid());

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <summary>
    /// Implicit conversion to Guid.
    /// </summary>
    public static implicit operator Guid(InvoiceId id) => id.Value;

    /// <summary>
    /// Implicit conversion from Guid.
    /// </summary>
    public static implicit operator InvoiceId(Guid value) => new(value);
}
