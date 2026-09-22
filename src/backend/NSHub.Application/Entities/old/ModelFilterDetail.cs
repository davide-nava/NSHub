using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ModelFilterDetail : BaseEntity
{
    public Guid ModelFilterId { get; set; }

    public Guid ObjectId { get; set; }

    public virtual ModelFilter? ModelFilter { get; set; }
    public virtual Object? Object { get; set; }
}
