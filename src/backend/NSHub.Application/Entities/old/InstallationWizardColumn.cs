using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class InstallationWizardColumn : BaseEntity
{
    public Guid InstallationWizardId { get; set; }

    public Guid GridLayoutColumnId { get; set; }

    public virtual GridLayoutColumn? GridLayoutColumn { get; set; }

    public virtual InstallationWizard? InstallationWizard { get; set; }
}
