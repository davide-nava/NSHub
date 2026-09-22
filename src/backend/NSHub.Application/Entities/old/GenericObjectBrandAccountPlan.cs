using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class GenericObjectBrandAccountPlan : BaseEntity
{

    public Guid GenericObjectBrandId { get; set; }

    public RecordType RecordType { get; set; }

    public Guid ObjectStatusId { get; set; }

    public Guid AccountPlanId { get; set; }

    public virtual GenericObjectBrand? GenericObjectBrand { get; set; }
    public virtual ObjectStatus? ObjectStatus { get; set; }
    public virtual AccountPlan? AccountPlan { get; set; }

}
