// <copyright file="ApiHostedService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Api.HostedServices;

public class ApiHostedService(ILogger<ApiHostedService> logger, IServiceProvider serviceProvider) : IHostedService
{
    public Task StopAsync(CancellationToken cancellationToken)
    {
        if (logger.IsEnabled(LogLevel.Warning))
        {
            logger.LogWarning("Stop API");
        }
        return Task.CompletedTask;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var scope = serviceProvider.CreateScope();

            if (logger.IsEnabled(LogLevel.Warning))
            {
                logger.LogWarning("Start API");
            }
        }
        catch (Exception ex)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError(ex, "{Message}", ex.Message);
            }
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}
