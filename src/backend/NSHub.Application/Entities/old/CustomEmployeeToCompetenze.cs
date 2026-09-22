using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomEmployeeToCompetenze : BaseEntity
{
    public Guid CustomEmployeeToCompetenzeParentId { get; set; }

    public DateTime CustomDataImmissio { get; set; }

    public int CustomImmessoDa { get; set; }

    public int CustomGruppoApprov { get; set; }

    public string CustomLivello { get; set; } = null!;

    public DateTime CustomEsitoPositiv { get; set; }

    public DateTime CustomEsitoNegativ { get; set; }

    public string CustomCompetenzePl { get; set; } = null!;

    public string CustomCompetenzeWo { get; set; } = null!;

    public string CustomNote { get; set; } = null!;

    public string CustomTipoCompeten { get; set; } = null!;

    public string CustomFresatura { get; set; } = null!;

    public string CustomVerniciatura { get; set; } = null!;

    public string CustomUsoMuletto { get; set; } = null!;

}
