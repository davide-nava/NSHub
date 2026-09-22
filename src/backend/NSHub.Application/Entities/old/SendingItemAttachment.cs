using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SendingItemAttachment : BaseEntity
{
    public Guid SendingItemId { get; set; }

    public Guid DocumentId { get; set; }

    public virtual SendingItem? SendingItem { get; set; }

    public virtual Document? Document { get; set; }
}
