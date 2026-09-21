using System;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkflowRunningAttachment : BaseEntity
{
    public Guid WorkflowRunningId { get; set; }

    public string BookmarkName { get; set; } = null!;

    public Guid BinaryDataId { get; set; }

    public string AttachmentExtension { get; set; } = null!;

    public Guid EmployeeId { get; set; }

    public virtual WorkflowRunning? WorkflowRunning { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual BinaryData? BinaryData { get; set; }
}
