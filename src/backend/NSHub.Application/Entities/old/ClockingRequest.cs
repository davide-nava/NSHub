using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class ClockingRequest : BaseEntity
{

    public Guid EmployeeId { get; set; }

    public DateTime RequestDate { get; set; }

    public int RequestTime { get; set; }

    public RequestType RequestType { get; set; }

    public int Verso { get; set; }

    public StatusType StatusType { get; set; }

    public Guid AccountId { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public Guid ClockingId { get; set; }

    public string Remarks { get; set; } = null!;

    public string LastUpdateUser { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
    public virtual Account? Account { get; set; }
    public virtual Clocking? Clocking { get; set; }

}
