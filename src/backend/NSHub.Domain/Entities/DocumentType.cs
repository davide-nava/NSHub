// <copyright file="DocumentType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a document type.
/// </summary>
public class DocumentType : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the document type description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the document groups associated with this document type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<DocumentGroup> DocumentGroups { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the documents associated with this document type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Document> Documents { get; set; }
        = [];
}
