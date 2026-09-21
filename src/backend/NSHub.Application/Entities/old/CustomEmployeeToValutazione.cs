using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CustomEmployeeToValutazione : BaseEntity
{
    public Guid CustomEmployeeToValutazioneParentId { get; set; }

    public string CustomTipoScadenz { get; set; } = null!;

    public int CustomGiorni { get; set; }

    public DateTime CustomUltimaEsecu { get; set; }

    public int CustomIncaricato { get; set; }

    public int CustomUltEsecutor { get; set; }

    public string CustomNote { get; set; } = null!;

    public int CustomGgalert { get; set; }

    public DateTime CustomProssimaSca { get; set; }

    public DateTime CustomUltimaAppro { get; set; }

    public int CustomApprovatore { get; set; }

    public int CustomUltimoAppro { get; set; }

}
