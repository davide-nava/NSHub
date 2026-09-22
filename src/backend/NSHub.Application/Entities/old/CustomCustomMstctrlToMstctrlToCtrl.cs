using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class CustomCustommstctrltomstctrlToCtrl : BaseEntity
{
    public Guid CustomCustommstctrltomstctrlToCtrlParentId { get; set; }

    public int CustomPunteggio { get; set; }

    public StatusType CustomStatus { get; set; }

    public bool CustomCheck { get; set; }

    public DateTime CustomDataPrevista { get; set; }

    public DateTime CustomDataEsecuzione { get; set; }

    public int CustomEsecutore { get; set; }

}
