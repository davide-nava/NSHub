using System;

namespace NSHub.Domain.Common;

public interface IAuditableEntity
{
    DateTime DateInsert { get; set; }
    DateTime? DateDelete { get; set; }
    DateTime DateUpdate { get; set; }
    Guid? UserInsertId { get; set; }
    Guid? UserDeleteId { get; set; }
    Guid? UserUpdateId { get; set; }
}
