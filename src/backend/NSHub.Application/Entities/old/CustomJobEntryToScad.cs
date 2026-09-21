using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CustomJobentryToScad : BaseEntity
{
    public Guid CustomJobentryToScadParentId { get; set; }

    public string CustomNote { get; set; } = null!;

    public int CustomRisorsaUltimaEsecu { get; set; }

    public string CustomOggetto { get; set; } = null!;

    public DateTime CustomDataProssimaEsecuz { get; set; }

    public DateTime CustomDataUltimaEsecuzio { get; set; }

    public int CustomRisorsaProssimaEse { get; set; }

    public virtual CustomJobentryToScad? CustomJobentryToScadParent { get; set; }

}
