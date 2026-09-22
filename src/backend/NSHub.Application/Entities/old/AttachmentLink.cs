using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttachmentLink : BaseEntity
{
    public Guid ObjectId { get; set; }

    public Guid AttachmentId { get; set; }

    public LinkType LinkType { get; set; }

    public Guid ReferenceId { get; set; }

    public int LinkTypeReference { get; set; }

    public int LinkParameter { get; set; }

    public LinkTableCodeType LinkTableCodeType { get; set; } = null!;

    public virtual Attachment? Attachment { get; set; }
    public virtual Object? Object { get; set; }
    public virtual Reference? Reference { get; set; }
}
