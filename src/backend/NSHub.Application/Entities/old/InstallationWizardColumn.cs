using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class InstallationWizardColumn : BaseEntity
{
    public Guid InstallationWizardId { get; set; }

    public Guid GridLayoutColumnId { get; set; }

    public virtual GridLayoutColumn? GridLayoutColumn { get; set; }

    public virtual InstallationWizard? InstallationWizard { get; set; }
}
