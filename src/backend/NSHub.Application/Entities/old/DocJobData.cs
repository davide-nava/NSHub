using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class DocJobData : BaseEntity
{

    public Guid JobEntryId { get; set; }

    public Guid DocumentId { get; set; }

    public virtual JobEntry? JobEntry { get; set; }
    public virtual Document? Document { get; set; }

}
