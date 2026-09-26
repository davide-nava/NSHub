using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class DocumentGroup : AuditableTenantEntity
{
    public Guid DocumentTypeId { get; protected set; }
    public string Title { get; protected set; } = string.Empty;
    public virtual DocumentType? DocumentType { get; protected set; }

    private readonly List<Document> _documents = new();
    public virtual IReadOnlyCollection<Document> Documents => _documents.AsReadOnly();

    protected DocumentGroup() { }

    public static DocumentGroup Create()
    {
        return new DocumentGroup();
    }
}
