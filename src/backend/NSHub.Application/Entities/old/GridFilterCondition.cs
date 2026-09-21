using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class GridFilterCondition : BaseEntity
{
    public Guid GridFilterId { get; set; }

    public int Position { get; set; }


    public IEnumerable<StringGroupList> Operands { get; set; }


    public string OperatorExpression { get; set; } = null!;

    public string Condition { get; set; } = null!;

    public virtual GridFilter? GridFilter { get; set; }
}
