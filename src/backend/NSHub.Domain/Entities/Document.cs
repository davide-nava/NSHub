using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Document : AuditableTenantEntity
{
    public Guid PurchaseInvoiceId { get; protected set; }
    public Guid DocumentId { get; protected set; }
    public Guid CustomerId { get; protected set; }
    public Guid DocumentGroupId { get; protected set; }
    public Guid SupplierId { get; protected set; }
    public Guid? MachineTypeId { get; protected set; }
    public Guid? MachineId { get; protected set; }
    public Guid DocumentTypeId { get; protected set; }
    public string? Name { get; protected set; }
    public DateTime? InsertionDate { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public byte[]? FileData { get; protected set; }
    public string? Extension { get; protected set; }
    public string ArticleCode { get; protected set; } = string.Empty;
    public bool? IsEnabled { get; protected set; }
    public string Title { get; protected set; } = string.Empty;
    public string Url { get; protected set; } = string.Empty;
    public DateTime Date { get; protected set; }
    public string Src { get; protected set; } = string.Empty;
    public virtual Customer? Customer { get; protected set; }
    public virtual DocumentGroup? DocumentGroup { get; protected set; }
    public virtual DocumentType? DocumentType { get; protected set; }

    protected Document() { }

    public static Document Create()
    {
        return new Document();
    }
}
