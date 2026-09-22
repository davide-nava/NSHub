using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomMstctrlToMstctrl : BaseEntity
{
    public Guid CustomMstctrlToMstctrlParentId { get; set; }

    public DateTime CustomUltimaEsecuzione { get; set; }

    public DateTime CustomDataProssima { get; set; }

    public int CustomFrequenzaGiorni { get; set; }

    public int CustomApprovatore { get; set; }

    public int CustomIncaricato { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }


    public virtual CustomMstctrlToMstctrl? CustomMstctrlToMstctrlParent { get; set; }

}
