// <copyright file="Extensions.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

#pragma warning disable IDE0130, CA1724
namespace Microsoft.Extensions.Hosting;

/// <summary>
/// Provides extension methods for configuring common services in an ASP.NET Core application,
/// including service discovery, resilience, health checks, and OpenTelemetry.
/// </summary>
public static class Extensions
{
    private const string HEALTH_ENDPOINT_PATH = "/health";
    private const string ALIVENESS_ENDPOINT_PATH = "/alive";

    /// <summary>
    /// Adds common Aspire services: service discovery, resilience, health checks, and OpenTelemetry.
    /// </summary>
    /// <typeparam name="TBuilder">The type of the host application builder.</typeparam>
    /// <param name="builder">The host application builder.</param>
    /// <returns>The host application builder.</returns>
    public static TBuilder AddServiceDefaults<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        _ = builder.ConfigureOpenTelemetry();

        _ = builder.AddDefaultHealthChecks();

        _ = builder.Services.AddServiceDiscovery();

        _ = builder.Services.ConfigureHttpClientDefaults(http =>
        {
            _ = http.AddStandardResilienceHandler();
            _ = http.AddServiceDiscovery();
        });

        return builder;
    }

    /// <summary>
    /// Configures OpenTelemetry for logging, metrics, and tracing.
    /// </summary>
    /// <typeparam name="TBuilder">The type of the host application builder.</typeparam>
    /// <param name="builder">The host application builder.</param>
    /// <returns>The host application builder.</returns>
    public static TBuilder ConfigureOpenTelemetry<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        _ = builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
        });

        _ = builder.Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
                _ = metrics.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation())
            .WithTracing(tracing =>
                _ = tracing.AddSource(builder.Environment.ApplicationName)
                    .AddAspNetCoreInstrumentation(options =>
                        options.Filter = context =>
                            !context.Request.Path.StartsWithSegments(
                                HEALTH_ENDPOINT_PATH,
                                StringComparison.OrdinalIgnoreCase)
                            && !context.Request.Path.StartsWithSegments(
                                ALIVENESS_ENDPOINT_PATH,
                                StringComparison.OrdinalIgnoreCase))
                    .AddHttpClientInstrumentation());

        _ = builder.AddOpenTelemetryExporters();

        return builder;
    }

    /// <summary>
    /// Adds default health checks to the application, including a liveness check.
    /// </summary>
    /// <typeparam name="TBuilder">The type of the host application builder.</typeparam>
    /// <param name="builder">The host application builder.</param>
    /// <returns>The host application builder.</returns>
    public static TBuilder AddDefaultHealthChecks<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        _ = builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

        return builder;
    }

    /// <summary>
    /// Maps the default health check endpoints for the application.
    /// </summary>
    /// <param name="app">The web application.</param>
    /// <returns>The web application.</returns>
    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        if (!app.Environment.IsDevelopment())
        {
            return app;
        }

        _ = app.MapHealthChecks(HEALTH_ENDPOINT_PATH);

        _ = app.MapHealthChecks(
            ALIVENESS_ENDPOINT_PATH,
            new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("live"),
            });

        return app;
    }

    private static TBuilder AddOpenTelemetryExporters<TBuilder>(this TBuilder builder)
        where TBuilder : IHostApplicationBuilder
    {
        var useOtlpExporter =
            !string.IsNullOrWhiteSpace(
                builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);

        if (useOtlpExporter)
        {
            _ = builder.Services
                .AddOpenTelemetry()
                .UseOtlpExporter();
        }

        // if (!string.IsNullOrEmpty(
        //     builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]))
        // {
        //     builder.Services.AddOpenTelemetry()
        //         .UseAzureMonitor();
        // }

        return builder;
    }
}
