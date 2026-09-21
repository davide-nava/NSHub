using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CustomDispToDisp : BaseEntity
{
    public Guid ParentId { get; set; }

    public Guid CustomDeviceTypeId { get; set; }

    public Guid CustomBrandId { get; set; }

    public string CustomStato { get; set; } = null!;

    public Guid CustomConsegnatoA { get; set; }

    public string CustomNote { get; set; } = null!;

    public DateTime CustomDataDismissione { get; set; }

    public virtual CustomDispToDispParent? CustomDispToDispParent { get; set; }
    public virtual CustomDeviceType? CustomDeviceType { get; set; }
    public virtual CustomBrand? CustomBrand { get; set; }
    public virtual CustomConsegnatoA? CustomConsegnatoA { get; set; }
    public virtual CustomModel? CustomModel { get; set; }

    public Guid CustomModelId { get; set; }

    public DateTime CustomDataAcquisto { get; set; }

    public string CustomNserie { get; set; } = null!;

    public decimal CustomPrezzo { get; set; }

    public int CustomMesi { get; set; }

    public DateTime CustomDecorrenza { get; set; }

    public decimal Custom { get; set; }

    public string CustomTipoAmmortamento { get; set; } = null!;

}
