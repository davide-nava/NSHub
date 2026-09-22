using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttachmentOcr : BaseEntity
{
    public Guid AttachmentId { get; set; }

    public string OcrText { get; set; } = null!;

    public virtual Attachment? Attachment { get; set; }
}
