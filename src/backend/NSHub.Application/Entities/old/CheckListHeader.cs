using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CheckListHeader : BaseEntity
{
    public string FormHashCode { get; set; }

    public string BaseQuery { get; set; } = null!;

    public bool CleanAttachments { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
