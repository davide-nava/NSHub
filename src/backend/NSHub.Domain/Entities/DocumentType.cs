using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class DocumentType : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;

    private readonly List<Document> _documents = new();
    public virtual IReadOnlyCollection<Document> Documents => _documents.AsReadOnly();
    private readonly List<DocumentGroup> _documentGroups = new();
    public virtual IReadOnlyCollection<DocumentGroup> DocumentGroups => _documentGroups.AsReadOnly();

    protected DocumentType() { }

    public static DocumentType Create()
    {
        return new DocumentType();
    }
}
