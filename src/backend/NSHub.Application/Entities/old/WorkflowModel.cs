namespace PlanetHub.ApplicationCore.Entities;

public class WorkflowModel : BaseEntity
{
    public string CodeCategory { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public Guid WorkflowModelTypeId { get; set; }

    public virtual WorkflowModelType? WorkflowModelType { get; set; }

    public bool IsSynchronousExecution { get; set; }
}
