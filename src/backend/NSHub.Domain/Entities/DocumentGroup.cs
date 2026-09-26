// <copyright file="DocumentGroup.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a document group.
/// </summary>
public class DocumentGroup : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the document type identifier.
    /// </summary>
    public Guid DocumentTypeId { get; set; }

    /// <summary>
    /// Gets or sets the document group title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the associated document type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DocumentType? DocumentType { get; set; }

    /// <summary>
    /// Gets or sets the documents associated with this group.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Document> Documents { get; set; }
        = [];
}
