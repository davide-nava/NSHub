using System;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Rental : BaseEntity
{
    public Guid JobEntryId { get; set; }

    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public StatusType StatusType { get; set; }

    public virtual JobEntry? JobEntry { get; set; } = null!;

}
