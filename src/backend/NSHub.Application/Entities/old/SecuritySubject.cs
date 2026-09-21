using System;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SecuritySubject : BaseEntity
{
    public Guid SourceId { get; set; }

    public SourceType SourceType { get; set; }
}
