using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomJobentryToScadWf : BaseEntity
{

    public Guid CustomJobentryToScadWfParentId { get; set; }

    public string CustomNote { get; set; } = null!;

    public int CustomTolleranzaPromem { get; set; }

    public int CustomIntervalloGgComm { get; set; }

    public DateTime CustomProssimaScad { get; set; }

    public string CustomOggetto { get; set; } = null!;

    public int CustomIncaricati { get; set; }

    public int CustomUltEsecutore { get; set; }

    public DateTime CustomDataUltEsec { get; set; }
}
