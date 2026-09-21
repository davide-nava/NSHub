// <copyright file="ProgelHealthCheck.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace NSHub.Application.HealthChecks;

public class ProgelHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (true)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("A healthy result."));
        }

        //return Task.FromResult(
        //    new HealthCheckResult(
        //        context.Registration.FailureStatus, "An unhealthy result."));
    }
}
