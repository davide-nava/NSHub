using System;

namespace NSHub.ApplicationCore.Entities;

public class WorkflowApproveCustomization : BaseEntity
{
    public Guid WorkflowRunningId { get; set; }

    public string BookmarkName { get; set; } = null!;

    public string MarkPattern { get; set; } = null!;

    public decimal MarkFontSize { get; set; }

    public virtual WorkflowRunning? WorkflowRunning { get; set; }
}
