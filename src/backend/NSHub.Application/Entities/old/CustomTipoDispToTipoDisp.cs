using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomTipodispToTipodisp : BaseEntity
{
    public Guid CustomTipodispToTipodispParentId { get; set; }

    public string Code { get; set; } = null!;

    public int Months { get; set; }

    public decimal Custom { get; set; }

    public virtual CustomTipodispToTipodisp? CustomTipodispToTipodispParent { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


}
