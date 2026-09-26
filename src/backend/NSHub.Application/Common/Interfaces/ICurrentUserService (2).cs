using System;

namespace NSHub.Application.Common.Interfaces;

public interface ICurrentUserService
{
    Guid? UserId { get; }
    Guid? TenantId { get; }
    bool IsAuthenticated { get; }
}
