using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Bibliography;

using NSHub.ApplicationCore.Entities;

namespace NSHub.ApplicationCore.Entities;

public class HistoricalRequestChange : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public Guid HistoricalRequestChangeParentId { get; set; }

    public Guid SourceId { get; set; }

    public Guid UserId { get; set; }

    public SubStateType SubStateType { get; set; }

    public SourceType SourceType { get; set; }

    public DateTime DateAndTime { get; set; }

    public bool IsActive { get; set; }

    public bool IsLast { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual HistoricalRequestChangeParent? HistoricalRequestChangeParent { get; set; }
    public virtual Source? Source { get; set; }
    public virtual User? User { get; set; }


}
