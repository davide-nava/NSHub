using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CustomResodispToResodisp : BaseEntity
{
    public Guid CustomResodispToResodispParentId { get; set; }

    public int CustomDispositivoDaR { get; set; }

    public DateTime CustomDataConfermaRe { get; set; }

    public int CustomStatoReso { get; set; }

    public DateTime CustomDataReso { get; set; }

    public int CustomRisorsa { get; set; }

    public int CustomRedattore { get; set; }

    public string CustomNoteAppr { get; set; } = null!;

    public string CustomNote { get; set; } = null!;

}
