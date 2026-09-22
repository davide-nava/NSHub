using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class CheckListItem : BaseEntity
{
    public Guid CheckListHeaderId { get; set; }

    public Guid CheckListItemParentId { get; set; }

    public Guid WorkflowAuthorizationId { get; set; }

    public PriorityType PriorityType { get; set; }

    public bool IsRequired { get; set; }

    public Guid WorkflowModelId { get; set; }

    public Guid TemplateTextId { get; set; }

    public bool IsLeaf { get; set; }

    public bool IsResourceConsoleItself { get; set; }

    public string ReferenceDate { get; set; } = null!;

    public bool IsDocumentMerged { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


    public virtual CheckListHeader? CheckListHeader { get; set; }
    public virtual CheckListItem? CheckListItemParent { get; set; }
    public virtual WorkflowAuthorization? WorkflowAuthorization { get; set; }
    public virtual WorkflowModel? WorkflowModel { get; set; }
    public virtual TemplateText? TemplateText { get; set; }



    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

}
