// <copyright file="DocumentRecord.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a document attachment entity.
/// </summary>
public class DocumentRecord : BaseEntity
{
    /// <summary>Gets or sets the file name.</summary>
    public string? Name { get; set; }

    /// <summary>Gets or sets the description.</summary>
    public string? Description { get; set; }

    /// <summary>Gets or sets the binary file data.</summary>
    public IEnumerable<byte>? FileData { get; set; }

    /// <summary>Gets or sets the file extension.</summary>
    public string? Extension { get; set; }

    /// <summary>Gets or sets the customer code.</summary>
    public Guid CustomerId { get; set; }

    /// <summary>Gets or sets the supplier code.</summary>
    public Guid SupplierId { get; set; }

    /// <summary>
    /// Gets or sets the document code.
    /// </summary>
    public Guid DocumentId { get; set; }

    /// <summary>Gets or sets the article code.</summary>
    public Guid ArticleId { get; set; }

    /// <summary>Gets or sets the purchase invoice code.</summary>
    public int CodPurchaseInvoice { get; set; }

    /// <summary>Gets or sets a value indicating whether the document is enabled.</summary>
    public bool? IsEnabled { get; set; }
}
