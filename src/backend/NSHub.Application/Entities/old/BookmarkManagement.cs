using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class BookmarkManagement : BaseEntity
{
    public Guid BookmarkId { get; set; }

    public Guid TableId { get; set; }

    public Guid EntityId { get; set; }

    public UnlockType UnlockType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual Bookmark? Bookmark { get; set; }
    public virtual Table? Table { get; set; }
    public virtual Entity? Entity { get; set; }

}
