using System;

namespace NSHub.ApplicationCore.Entities;

public class ShiftToCover : BaseEntity
{
    public int Quantity { get; set; }

    public Guid ShiftNeedId { get; set; }

    public string ShiftCoverages { get; set; } = null!;

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public bool IsManual { get; set; }

    public virtual ShiftNeed? ShiftNeed { get; set; }

}
