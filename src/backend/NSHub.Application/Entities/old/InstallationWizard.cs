using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class InstallationWizard : BaseEntity
{
    public string InstalledVersion { get; set; } = null!;

    public bool Done { get; set; }

}
