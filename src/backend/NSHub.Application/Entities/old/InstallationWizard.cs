using System.Collections.Generic;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class InstallationWizard : BaseEntity
{
    public string InstalledVersion { get; set; } = null!;

    public bool Done { get; set; }

}
