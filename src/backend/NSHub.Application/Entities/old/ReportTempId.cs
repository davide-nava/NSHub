using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ReportTempId : BaseEntity
{
    public Guid PrintProcessId { get; set; }

    public Guid RecordId { get; set; }

    public virtual Record? Record { get; set; }
    public virtual PrintProcess? PrintProcess { get; set; }

}
