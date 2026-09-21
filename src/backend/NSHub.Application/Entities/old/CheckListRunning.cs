using System;
using System.Collections.Generic;

using MimeKit;

namespace PlanetHub.ApplicationCore.Entities;

public class CheckListRunning : BaseEntity
{

    public Guid HeaderId { get; set; }

    public Guid RecordId { get; set; }

    public DateTime DateStart { get; set; }

    public Guid EmployeeId { get; set; }

    public RunningStatusType RunningStatusType { get; set; }

    public DateTime DateEnd { get; set; }

    public virtual Header? Header { get; set; }
    public virtual Record? Record { get; set; }
    public virtual Employee? Employee { get; set; }


}
