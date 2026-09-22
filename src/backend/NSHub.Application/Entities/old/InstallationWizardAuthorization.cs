using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class InstallationWizardAuthorization : BaseEntity
{
    public Guid InstallationWizardId { get; set; }

    public Guid AuthorizationId { get; set; }

    public virtual Authorization? Authorization { get; set; }

    public virtual InstallationWizard? InstallationWizard { get; set; }
}
