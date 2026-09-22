using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomStatoappToStatoapp : BaseEntityType
{
    public Guid CustomStatoappToStatoappParentId { get; set; }


    public virtual CustomStatoappToStatoapp? CustomStatoappToStatoappParent { get; set; }

}
