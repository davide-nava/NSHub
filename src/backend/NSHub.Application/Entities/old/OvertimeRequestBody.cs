using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class OvertimeRequestBody : BaseEntity
{
    public Guid HeaderId { get; set; }

    public Guid AccountId { get; set; }

    // TODO: Check type
    public int TimeRequest { get; set; }

    // TODO: Check type
    public int TimeAuthorized { get; set; }

    public virtual Header? Header { get; set; }
    public virtual Account? Account { get; set; }
}
