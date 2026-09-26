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
    /// Gets the document type identifier.
    /// </summary>
    public Guid DocumentTypeId { get; protected set; }

    /// <summary>
    /// Gets the document group title.
    /// </summary>
    public string Title { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the associated document type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DocumentType? DocumentType { get; protected set; }

    /// <summary>
    /// Gets the documents associated with this group.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Document> Documents { get; protected set; }
        = new List<Document>();
}
