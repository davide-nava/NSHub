using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttachmentWorkflowModel : BaseEntity
{
    public Guid DescriptionId { get; set; }

    public Guid WorkflowModelId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual WorkflowModel? WorkflowModel { get; set; }
}
