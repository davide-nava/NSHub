// <copyright file="DependencyInjectionExtension.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Constants;
using NSHub.Application.Features.TimeAttendance.Repositories;
using NSHub.Application.Interfaces;
using NSHub.Application.Services;
using NSHub.Infrastructure.Common;
using NSHub.Infrastructure.DbContexts;
using NSHub.Infrastructure.Interceptors;
using NSHub.Infrastructure.Repositories;
using NSHub.Infrastructure.Services;
using NSHub.Infrastructure.Services.Notifications;
using Scrutor;

namespace NSHub.Infrastructure.Extensions;

/// <summary>
/// Extension methods for application building and service registration.
/// </summary>
public static class DependencyInjectionExtension
{
    /// <summary>
    /// Applies database migrations and ensures seed data is inserted.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>A task representing the asynchronous operation yielding the application builder.</returns>
    public static async Task<IApplicationBuilder> UseMigrationsAsync(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);
        var provider = app.ApplicationServices.GetRequiredService<IServiceProvider>();

        using var scope = provider.CreateScope();

        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await applicationDbContext.Database.MigrateAsync();

        return app;
    }

    /// <summary>
    /// Registers shared infrastructure services, database contexts, identity, and caching on the web application builder.
    /// </summary>
    /// <param name="builder">The web application builder.</param>
    /// <param name="connectionString">The database connection string.</param>
    /// <returns>The updated web application builder.</returns>
    public static WebApplicationBuilder AddInfrastructureShareBuilder(this WebApplicationBuilder builder, string connectionString)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentException.ThrowIfNullOrEmpty(connectionString);

        _ = builder.Services.AddHttpContextAccessor();
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

        _ = builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>();
        _ = builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
        _ = builder.Services.AddSingleton<IDateTimeService, DateTimeService>();
        _ = builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        _ = builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
        _ = builder.Services.AddScoped<ISecoComplianceExportService, SecoComplianceExportService>();

        _ = builder.Services.AddScoped<NSHub.Application.Interfaces.IRequestContext, RequestContext>();
        _ = builder.Services.AddScoped<NSHub.Application.Common.Interfaces.IRequestContext>(sp => sp.GetRequiredService<NSHub.Application.Interfaces.IRequestContext>());

        _ = builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        _ = builder.Services.Scan(scan => scan.FromAssemblyOf<RequestContext>().AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip).AsMatchingInterface().WithTransientLifetime());

        _ = builder.Services.AddAuthorization();

        _ = builder.Services.AddIdentityApiEndpoints<NSHub.Infrastructure.Identity.ApplicationUser>(options =>
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

    /// <summary>
    /// Registers infrastructure-specific services, repositories, and unit of work on the web application builder.
    /// </summary>
    /// <param name="builder">The web application builder.</param>
    /// <returns>The updated web application builder.</returns>
    public static WebApplicationBuilder AddInfrastructureBuilder(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        // Unit of Work
        _ = builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Generic Repositories
        _ = builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        _ = builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

        // Feature Repositories
        _ = builder.Services.AddScoped<EmployeeRepository>();
        _ = builder.Services.AddScoped<NSHub.Application.Features.Organization.Repositories.IEmployeeRepository>(sp => sp.GetRequiredService<EmployeeRepository>());
        _ = builder.Services.AddScoped<NSHub.Application.Features.Employees.Repositories.IEmployeeRepository>(sp => sp.GetRequiredService<EmployeeRepository>());

        _ = builder.Services.AddScoped<TimeEntryRepository>();
        _ = builder.Services.AddScoped<NSHub.Application.Features.TimeAttendance.Repositories.ITimeEntryRepository>(sp => sp.GetRequiredService<TimeEntryRepository>());
        _ = builder.Services.AddScoped<NSHub.Application.Features.TimeTracking.Repositories.ITimeEntryRepository>(sp => sp.GetRequiredService<TimeEntryRepository>());

        _ = builder.Services.AddScoped<ITimeTrackingAgreementRepository, TimeTrackingAgreementRepository>();

        return builder;
    }
}
