using System;
using System.Collections.Generic;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class Sending : BaseEntity
{
    public DateTime CreationTime { get; set; }

    public SendingModeType SendingModeType { get; set; }

    public Guid AttachmentId { get; set; }

    public SendingStatusType SendingStatusType { get; set; }

    public DateTime Date { get; set; }

    public DateTime LastModified { get; set; }

    public virtual Attachment? Attachment { get; set; }

}
