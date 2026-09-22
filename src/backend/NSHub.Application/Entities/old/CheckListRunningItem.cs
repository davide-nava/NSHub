using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class CheckListRunningItem : BaseEntity
{
    public Guid RunningId { get; set; }

    public Guid CheckListRunningItemParentId { get; set; }

    public Guid WorkflowAuthorizationId { get; set; }

    public PriorityType PriorityType { get; set; }

    public bool IsRequired { get; set; }

    public string Note { get; set; } = null!;

    public virtual Running? Running { get; set; }
    public virtual CheckListRunningItem? CheckListRunningItemParent { get; set; }
    public virtual WorkflowAuthorization? WorkflowAuthorization { get; set; }
    public virtual WorkflowModel? WorkflowModel { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual TemplateText? TemplateText { get; set; }

    public Guid WorkflowModelId { get; set; }

    public DateTime DateStart { get; set; }

    public Guid EmployeeId { get; set; }

    public StatusType RunningStatusType { get; set; }

    public DateTime DateEnd { get; set; }

    public Guid TemplateTextId { get; set; }

    public StatusType ApprovationStatus { get; set; }

    public bool IsLeaf { get; set; }

    public bool IsResourceConsoleItself { get; set; }

    public string ReferenceDate { get; set; } = null!;

    public bool IsDocumentMerged { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
