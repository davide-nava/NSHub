using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class HolidayTableBody : BaseEntity
{
    public Guid HolidayTableId { get; set; }

    public Guid FormulaId { get; set; }

    public decimal Amount { get; set; }

    public HolidayTableBodyTypologyType HolidayTableBodyTypologyType { get; set; }

    public bool ComputeEmploymentRate { get; set; }

    public bool ComputeContractualAverage { get; set; }

    public virtual TbHolidayTable IdHolidayTableNavigation { get; set; } = null!;


    public virtual HolidayTable? HolidayTable { get; set; }
    public virtual Formula? Formula { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }
}
