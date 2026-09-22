using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class GlJournalHeader : BaseEntity
{
    public int GlJournalId { get; set; }

    public int CompanyId { get; set; }

    public string JournalNumber { get; set; } = null!;

    public DateOnly JournalDate { get; set; }

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int CreatedByUserId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual ICollection<GlJournalLine> GlJournalLines { get; set; } = [];
}
