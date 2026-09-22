using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities.Json;

namespace NSHub.ApplicationCore.Entities;

public class WorkflowRunning : BaseEntity
{
    public Guid WorkflowId { get; set; }

    // TODO : commentare
    // TODO : check type
    public Guid ObjectId { get; set; }

    public Guid WorkflowModelId { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public Guid WorkflowRunningStatusTypeId { get; set; }

    public virtual WorkflowRunningStatusType? WorkflowRunningStatusType { get; set; }

    public Guid BinaryDataId { get; set; }

    public string AttachmentExtension { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public IEnumerable<GuidListJson> Links { get; set; }

    public virtual BinaryData? BinaryData { get; set; }

    public virtual WorkflowModel? WorkflowModel { get; set; }
}
