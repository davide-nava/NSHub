using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Holiday : BaseEntity
{

    public DateTime Date { get; set; }

    public Guid HolidayTypeId { get; set; }


    public string Davers { get; set; } = null!;

    public int Cadence { get; set; }

    public int DaysFromEaster { get; set; }

    public Guid HolidayHeaderId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual HolidayHeader? HolidayHeader { get; set; }
    public virtual HolidayType? HolidayType { get; set; }
}
