using System;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkflowInstance : BaseEntity
{
    public Guid WorkflowRunningId { get; set; }

    public string BookmarkName { get; set; } = null!;

    public Guid  ApprovationModeTypeId { get; set; }

    public virtual ApprovationModeType? ApprovationModeType { get; set; }

    public Guid ApprovationStatusTypeId { get; set; }

    public virtual ApprovationStatusType? ApprovationStatusType { get; set; }

    public DateTime Start { get; set; }

    public Guid WorkflowAuthorizationId { get; set; }

    public Guid TableId { get; set; }

    public Guid InputConfigurationId { get; set; }

    public Guid TableModeTypeId { get; set; }

    public virtual TableModeType? TableModeType { get; set; }

    public Guid  MarkTypeId { get; set; }

    public virtual MarkType? MarkType { get; set; }

    public virtual WorkflowRunning? WorkflowRunning { get; set; }

    public virtual WorkflowAuthorization? WorkflowAuthorization { get; set; }

    public virtual Table? Table { get; set; }

    public virtual InputConfiguration? InputConfiguration { get; set; }
}
