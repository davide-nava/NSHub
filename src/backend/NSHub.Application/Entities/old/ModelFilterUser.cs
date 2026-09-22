using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ModelFilterUser : BaseEntity
{
    public Guid ModelFilterId { get; set; }
    public Guid UserId { get; set; }

    public string CodeUser { get; set; } = null!;

    public virtual User? User { get; set; }

    public virtual ModelFilter? ModelFilter { get; set; }
}
