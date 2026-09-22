using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class BusinessUnit : BaseEntity
{
    public Guid CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = [];

    public virtual ICollection<GlJournalLine> GlJournalLines { get; set; } = [];

    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = [];

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = [];
    public virtual ICollection<TimesheetLine> TimesheetLines { get; set; } = [];
}
