using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomCorrespondentToContattiCom : BaseEntity
{
    public Guid CustomCorrespondentToContattiComParentId { get; set; }

    public DateTime CustomDataUl { get; set; }

    public string CustomTipoCo { get; set; } = null!;

    public DateTime CustomDataPr { get; set; }

    public Guid CustomOperatId { get; set; }

    public Guid CustomSoggetId { get; set; }

    public Guid DescriptionCustomNoteId { get; set; }

    public virtual TranslationGroup? DescriptionCustomNote { get; set; }
    public virtual CustomCorrespondentToContattiCom? CustomCorrespondentToContattiComParent { get; set; }
}
