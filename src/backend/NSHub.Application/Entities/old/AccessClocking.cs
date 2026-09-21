using System;

namespace PlanetHub.ApplicationCore.Entities;

public class AccessClocking : BaseEntity
{
    public string BadgeNumber { get; set; } = null!;

    public DateTime DateAndTime { get; set; }

    public Guid EmployeeId { get; set; }

    /// TODO: Rinominare o commentare il campo
    public short EquipmentNumber { get; set; }

    /// TODO: Rinominare o commentare il campo
    public short EquipmentDetailsNumber { get; set; }

    public Guid AccessClockingSourceTypeId { get; set; }

    public string SourceDetails { get; set; } = null!;

    public Guid AccessClockingTypeId { get; set; }

    /// TODO: Rinominare o commentare il campo
    public DateTime? CmpTheDate { get; set; }

    public Guid AccountId { get; set; }

    public string TransitCode { get; set; } = null!;

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public virtual AccessClockingType? AccessClockingType { get; set; }

    public virtual AccessClockingSourceType? AccessClockingSourceType { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Account? Account { get; set; }


}
