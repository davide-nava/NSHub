using System;

namespace NSHub.ApplicationCore.Entities;

public class SuaRequestDetail : BaseEntity
{
    public Guid SuaRequestHeaderId { get; set; }

    public Guid EntryTypeId { get; set; }

    public virtual EntryType? EntryType { get; set; }

    public DateTime EntryDateTime { get; set; }

    public string ContentData { get; set; } = null!;

    public Guid SuaRequestDetailStatusTypeId { get; set; }

    public virtual SuaRequestDetailStatusType? SuaRequestDetailStatusType { get; set; }

    public virtual SuaRequestHeader? SuaRequestHeader { get; set; }
}
