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
    /// Gets the purchase invoice identifier.
    /// </summary>
    public Guid PurchaseInvoiceId { get; protected set; }

    /// <summary>
    /// Gets the document identifier.
    /// </summary>
    public Guid DocumentId { get; protected set; }

    /// <summary>
    /// Gets the customer identifier.
    /// </summary>
    public Guid CustomerId { get; protected set; }

    /// <summary>
    /// Gets the document group identifier.
    /// </summary>
    public Guid DocumentGroupId { get; protected set; }

    /// <summary>
    /// Gets the supplier identifier.
    /// </summary>
    public Guid SupplierId { get; protected set; }

    /// <summary>
    /// Gets the machine type identifier.
    /// </summary>
    public Guid? MachineTypeId { get; protected set; }

    /// <summary>
    /// Gets the machine identifier.
    /// </summary>
    public Guid? MachineId { get; protected set; }

    /// <summary>
    /// Gets the document type identifier.
    /// </summary>
    public Guid DocumentTypeId { get; protected set; }

    /// <summary>
    /// Gets the document name.
    /// </summary>
    public string? Name { get; protected set; }

    /// <summary>
    /// Gets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; protected set; }

    /// <summary>
    /// Gets the document description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the document file content.
    /// </summary>
    public byte[]? FileData { get; protected set; }

    /// <summary>
    /// Gets the file extension.
    /// </summary>
    public string? Extension { get; protected set; }

    /// <summary>
    /// Gets the article code.
    /// </summary>
    public string ArticleCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets a value indicating whether the document is enabled.
    /// </summary>
    public bool? IsEnabled { get; protected set; }

    /// <summary>
    /// Gets the document title.
    /// </summary>
    public string Title { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the document URL.
    /// </summary>
    public string Url { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the document date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the source information.
    /// </summary>
    public string Src { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; protected set; }

    /// <summary>
    /// Gets the associated document group.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DocumentGroup? DocumentGroup { get; protected set; }

    /// <summary>
    /// Gets the associated document type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DocumentType? DocumentType { get; protected set; }

    /// <summary>
    /// Gets the associated supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Supplier? Supplier { get; protected set; }

    /// <summary>
    /// Gets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; protected set; }

    /// <summary>
    /// Gets the associated machine type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual MachineType? MachineType { get; protected set; }
}
