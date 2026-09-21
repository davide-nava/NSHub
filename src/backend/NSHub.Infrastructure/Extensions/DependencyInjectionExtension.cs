// <copyright file="DependencyInjectionExtension.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSHub.Application.Constants;
using NSHub.Application.Interfaces;
using NSHub.Application.NSHub.Models;
using NSHub.Application.Services;
using NSHub.Infrastructure.DbContexts;
using NSHub.Infrastructure.Helpers;
using NSHub.Infrastructure.Interceptors;
using NSHub.Infrastructure.Providers;
using NSHub.Infrastructure.Services;
using Scrutor;

namespace NSHub.Infrastructure.Extensions;

public static class DependencyInjectionExtension
{
    public static async Task<IApplicationBuilder> UseMigrationsAsync(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);
        var provider = app.ApplicationServices.GetRequiredService<IServiceProvider>();

        using var scope = provider.CreateScope();

        var nSHubDbContext = scope.ServiceProvider.GetRequiredService<TenantDbContext>();
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await applicationDbContext.Database.MigrateAsync();
        await nSHubDbContext.Database.MigrateAsync();

        _ = await SeedHelper.CheckSeedsAsync(applicationDbContext);
        _ = await SeedHelper.CheckSeedsAsync(nSHubDbContext);

        return app;
    }

    public static WebApplicationBuilder AddInfrastructureShareBuilder(this WebApplicationBuilder builder, string connectionString)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentException.ThrowIfNullOrEmpty(connectionString);

        _ = builder.Services.AddHttpContextAccessor();
        _ = builder.Services.AddScoped<ITenantProvider, HttpTenantProvider>();
        //builder.Services.AddScoped<IDbContextFactory<TenantDbContext>, TenantDbContextFactory>();
        _ = builder.Services.AddScoped<SoftDeleteInterceptor>();

        _ = builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
            options.UseSqlServer(
                connectionString,
                optionActions =>
                    {
                        _ = optionActions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                        _ = optionActions.CommandTimeout(DatabaseConstant.CommandTimeout);
                        _ = optionActions.UseCompatibilityLevel(170);
                    }).AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>()));

        _ = builder.Services.AddDbContext<TenantDbContext>((sp, options) =>
        options.UseSqlServer(
            connectionString,
            optionActions =>
                {
                    _ = optionActions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    _ = optionActions.CommandTimeout(DatabaseConstant.CommandTimeout);
                    _ = optionActions.UseCompatibilityLevel(170);
                }).AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>()));

        //{
        //	"Name": "ApplicationInsights",
        //	"Args": {
        //		"instrumentationKey": "YOUR_AI_KEY",
        //		"telemetryConverter": "Serilog.Sinks.ApplicationInsights.Sinks.ApplicationInsights.TelemetryConverters.TraceTelemetryConverter, Serilog.Sinks.ApplicationInsights"
        //	}
        //},

        //services.AddSingleton<Ixxxx, xxxx>();

        _ = builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>();

        _ = builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        _ = builder.Services.AddSingleton<INSHubMemoryCacheService, NSHubMemoryCacheService>();

        _ = builder.Services.Scan(scan => scan.FromAssemblyOf<IRequestContext>().AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip).AsMatchingInterface().WithTransientLifetime());
        _ = builder.Services.Scan(scan => scan.FromAssemblyOf<RequestContext>().AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip).AsMatchingInterface().WithTransientLifetime());

        _ = builder.Services.AddAuthorization();

        _ = builder.Services.AddIdentityApiEndpoints<ApplicationUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.SignIn.RequireConfirmedEmail = true;
            options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
        })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

        return builder;
    }
}
