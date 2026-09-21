// <copyright file="ITenantProvider.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Providers;

public interface ITenantProvider
{
    Guid GetTenantId();
}
