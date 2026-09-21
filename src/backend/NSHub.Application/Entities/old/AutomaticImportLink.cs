using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AutomaticImportLink : BaseEntity
{
    public Guid TableId { get; set; }

    public AcceptModeType AcceptModeType { get; set; }

    public string Emails { get; set; } = null!;

    public Guid AutomaticImportHeaderId { get; set; }

    public virtual AutomaticImportHeader? AutomaticImportHeader { get; set; }
    public virtual Table? Table { get; set; }
}
