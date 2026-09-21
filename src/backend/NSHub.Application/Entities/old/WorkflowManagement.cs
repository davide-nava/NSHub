using System;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkflowManagement : BaseEntity
{
    public Guid LastWorkflowStatusTypeId { get; set; }

    public virtual WorkflowStatusType? LastWorkflowStatusType { get; set; }

    public Guid TableId { get; set; }

    public bool IsInsert { get; set; }

    public bool IsEdit { get; set; }

    public bool IsDelete { get; set; }

    public bool IsManual { get; set; }

    public Guid WorkflowModelId { get; set; }

    public bool IsConfirmManual { get; set; }

    public virtual WorkflowModel? WorkflowModel { get; set; }

    public virtual Table? Table { get; set; }
}
