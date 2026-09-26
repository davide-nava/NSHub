using System;

namespace NSHub.Domain.Common;

public interface ITenantEntity
{
    Guid? TenantId { get; set; }
}
