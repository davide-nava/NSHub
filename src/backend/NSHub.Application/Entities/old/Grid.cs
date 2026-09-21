using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Grid : BaseEntity
{
    public string Code { get; set; } = null!;

    public string Davers { get; set; } = null!;

}
