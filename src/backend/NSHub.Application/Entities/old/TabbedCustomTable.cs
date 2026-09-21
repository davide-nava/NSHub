using System;

namespace PlanetHub.ApplicationCore.Entities;

public class TabbedCustomTable : BaseEntity
{
    public Guid ParentTableId { get; set; }

    public Guid CustomTableId { get; set; }

    public virtual Table? ParentTable { get; set; }

    public virtual Table? CustomTable { get; set; }

}
