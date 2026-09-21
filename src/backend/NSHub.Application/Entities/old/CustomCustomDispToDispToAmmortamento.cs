using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CustomCustomdisptodispToAmmortamento : BaseEntity
{
    public Guid CustomCustomdisptodispToAmmortamentoParentId { get; set; }

    public decimal CustomImporto { get; set; }

    public int CustomAnno { get; set; }

    public virtual CustomCustomdisptodispToAmmortamento? CustomCustomdisptodispToAmmortamentoParent { get; set; }
}
