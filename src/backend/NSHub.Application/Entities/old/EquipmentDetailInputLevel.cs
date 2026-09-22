using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class EquipmentDetailInputLevel : BaseEntity
{
    public string InputLevel { get; set; } = null!;

    public Guid EquipmentDetailId { get; set; }
    public virtual EquipmentDetail? EquipmentDetail { get; set; }

}
