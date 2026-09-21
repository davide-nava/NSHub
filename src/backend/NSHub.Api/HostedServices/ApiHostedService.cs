// <copyright file="ApiHostedService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Api.HostedServices;

/// <summary>
/// Background hosted service executing lifecycle operations during API host startup and shutdown.
/// </summary>
/// <param name="logger">The logger instance.</param>
/// <param name="serviceProvider">The root service provider.</param>
public class ApiHostedService(ILogger<ApiHostedService> logger, IServiceProvider serviceProvider) : IHostedService
{
    /// <summary>
    /// Triggered when the application host is performing a graceful shutdown.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A completed task.</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        if (logger.IsEnabled(LogLevel.Warning))
        {
            logger.LogWarning("Stop API");
        }
        return Task.CompletedTask;
    }

    /// <summary>
    /// Triggered when the application host is ready to start the service.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>An asynchronous task.</returns>
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
