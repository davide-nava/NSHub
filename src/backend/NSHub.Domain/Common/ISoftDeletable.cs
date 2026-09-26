using System;

namespace NSHub.Domain.Common;

public interface ISoftDeletable
{
    DateTime? DateDelete { get; set; }
    Guid? UserDeleteId { get; set; }
}
