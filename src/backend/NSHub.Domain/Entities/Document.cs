// <copyright file="Document.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a document.
/// </summary>
public class Document : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the purchase invoice identifier.
    /// </summary>
    public Guid PurchaseInvoiceId { get; set; }

    /// <summary>
    /// Gets or sets the document identifier.
    /// </summary>
    public Guid DocumentId { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the document group identifier.
    /// </summary>
    public Guid DocumentGroupId { get; set; }

    /// <summary>
    /// Gets or sets the supplier identifier.
    /// </summary>
    public Guid SupplierId { get; set; }

    /// <summary>
    /// Gets or sets the machine type identifier.
    /// </summary>
    public Guid? MachineTypeId { get; set; }

    /// <summary>
    /// Gets or sets the machine identifier.
    /// </summary>
    public Guid? MachineId { get; set; }

    /// <summary>
    /// Gets or sets the document type identifier.
    /// </summary>
    public Guid DocumentTypeId { get; set; }

    /// <summary>
    /// Gets or sets the document name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>
    /// Gets or sets the document description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the document file content.
    /// </summary>
    public IEnumerable<byte>? FileData { get; set; }

    /// <summary>
    /// Gets or sets the file extension.
    /// </summary>
    public string? Extension { get; set; }

    /// <summary>
    /// Gets or sets the article code.
    /// </summary>
    public string ArticleCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the document is enabled.
    /// </summary>
    public bool? IsEnabled { get; set; }

    /// <summary>
    /// Gets or sets the document title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the document URL.
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the document date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the source information.
    /// </summary>
    public string Src { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; set; }

    /// <summary>
    /// Gets or sets the associated document group.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DocumentGroup? DocumentGroup { get; set; }

    /// <summary>
    /// Gets or sets the associated document type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DocumentType? DocumentType { get; set; }

    /// <summary>
    /// Gets or sets the associated supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Supplier? Supplier { get; set; }

    /// <summary>
    /// Gets or sets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; set; }

    /// <summary>
    /// Gets or sets the associated machine type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual MachineType? MachineType { get; set; }
}
