using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EquipmentDetailsPointer : BaseEntity
{
    // TODO: Check type
    public int EquipmentDetails { get; set; }

    public DateTime PointerDate { get; set; }

    public PointerType PointerType { get; set; }

    public string Pointer { get; set; } = null!;

}
