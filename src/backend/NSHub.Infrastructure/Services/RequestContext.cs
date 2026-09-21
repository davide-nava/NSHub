// <copyright file="RequestContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Services;

public class RequestContext  : IRequestContext
{
    public Guid TenantId { get; set; } = Guid.Empty;

    public Guid UserId { get; set; } = Guid.Empty;
}
