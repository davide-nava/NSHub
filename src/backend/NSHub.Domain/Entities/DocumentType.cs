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
    /// Gets the document type description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the document groups associated with this document type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<DocumentGroup> DocumentGroups { get; protected set; }
        = new List<DocumentGroup>();

    /// <summary>
    /// Gets the documents associated with this document type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Document> Documents { get; protected set; }
        = new List<Document>();
}
