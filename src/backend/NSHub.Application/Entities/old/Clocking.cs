using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class Clocking : BaseEntity
{
    public string BadgeNumber { get; set; } = null!;

    public DateTime DateAndTime { get; set; }

    public Guid EmployeeId { get; set; }

    public ClockingType ClockingType { get; set; }

    public int Verso { get; set; }

    public int Source { get; set; }

    public DateTime? CmpTheDate { get; set; }

    public string SourceDetails { get; set; } = null!;

    public short EquipmentNumber { get; set; }

    public short EquipmentDetailsNumber { get; set; }

    public StatusType State { get; set; }

    public Guid StateDetailId { get; set; }

    public Guid AccountId { get; set; }

    public decimal LocationLatitude { get; set; }

    public decimal LocationLongitude { get; set; }

    public decimal LocationAccuracy { get; set; }

    public bool LocationOutOfRange { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public bool TimeIsNotReliable { get; set; }

    public bool PauseConverted { get; set; }

    public string TransitCode { get; set; } = null!;

    public Guid AuthorizationManagementId { get; set; }

    public DateTime ForCalculation { get; set; }

    public bool TypeModifiedByUser { get; set; }

    public short Technical { get; set; }

    public bool ExcludeFromVirtualPause { get; set; }

    public bool AbsentAndPresentExclusion { get; set; }

}
