// <copyright file="DependencyInjectionExtension.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Constants;
using NSHub.Application.Interfaces;
using NSHub.Application.Models;
using NSHub.Application.NSHub.Models;
using NSHub.Application.Services;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.DbContexts;
using NSHub.Infrastructure.Helpers;
using NSHub.Infrastructure.Interceptors;
using NSHub.Infrastructure.Providers;
using NSHub.Infrastructure.Services;
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

        var nSHubDbContext = scope.ServiceProvider.GetRequiredService<TenantDbContext>();
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await applicationDbContext.Database.MigrateAsync();
        await nSHubDbContext.Database.MigrateAsync();

        _ = await SeedHelper.CheckSeedsAsync(applicationDbContext);
        _ = await SeedHelper.CheckSeedsAsync(nSHubDbContext);
        await SeedHelper.CheckSeedsAsync(applicationDbContext);
        await SeedHelper.CheckSeedsAsync(nSHubDbContext);

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
        {
            _ = optionActions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            _ = optionActions.CommandTimeout(DatabaseConstant.CommandTimeout);
            _ = optionActions.UseCompatibilityLevel(170);
        }).AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>()));

        _ = builder.Services.AddDbContext<TenantDbContext>((sp, options) =>
        options.UseSqlServer(
            connectionString,
            optionActions =>
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
        _ = builder.Services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

        //services.AddSingleton<Ixxxx, xxxx>();

        _ = builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>();
        _ = builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
        _ = builder.Services.AddSingleton<IDateTimeService, DateTimeService>();
        _ = builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
        _ = builder.Services.AddScoped<ISecoComplianceExportService, SecoComplianceExportService>();

        _ = builder.Services.AddScoped<IRequestContext, RequestContext>();
        _ = builder.Services.AddScoped<NSHub.Application.Interfaces.IRequestContext, RequestContext>();

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
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddSignInManager()
        .AddDefaultTokenProviders();

        return builder;
    }



    /// <summary>
    /// Adds infrastructure services, repositories, database contexts, and authentication to the service collection.
    /// Registers infrastructure-specific services on the web application builder.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration instance.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    /// <param name="builder">The web application builder.</param>
    /// <returns>The updated web application builder.</returns>
    public static WebApplicationBuilder AddInfrastructureBuilder(this WebApplicationBuilder builder)
    {
        _ = services.AddHttpContextAccessor();

        // Providers e Servizi
        _ = services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        _ = services.AddScoped<ICurrentUserService, CurrentUserService>();
        _ = services.AddScoped<IJwtTokenService, JwtTokenService>();
        _ = services.AddScoped<ISecoComplianceExportService, SecoComplianceExportService>();

        // Interceptor EF Core
        _ = services.AddScoped<AuditLogInterceptor>();

        // DbContext SQLite
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=openx_gest.db";
        _ = services.AddDbContext<OpenXGestDbContext>((sp, options) =>
        {
            var interceptor = sp.GetRequiredService<AuditLogInterceptor>();
            _ = options.UseSqlite(connectionString)
                   .AddInterceptors(interceptor);
        });

        // Repositories & UnitOfWork
        _ = services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();
        _ = services.AddScoped<Domain.Repositories.ITimeEntryRepository, TimeEntryRepository>();
        _ = services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        _ = services.AddScoped<Domain.Repositories.IEmployeeRepository, EmployeeRepository>();
        _ = services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Phase 1 Bounded Context Services & Repositories
        _ = services.AddSingleton<Domain.Identity.Services.IPasswordHasher, Infrastructure.Identity.Services.PasswordHasher>();
        _ = services.AddScoped<IUserRepository, Infrastructure.Identity.Persistence.Repositories.UserRepository>();
        _ = services.AddScoped<ITicketCommandRepository, Infrastructure.Tickets.Persistence.Repositories.TicketRepository>();
        _ = services.AddScoped<IInventoryRepository, Infrastructure.Warehouse.Persistence.Repositories.InventoryRepository>();
        _ = services.AddScoped<IInvoiceRepository, Infrastructure.Invoicing.Persistence.Repositories.InvoiceRepository>();
        _ = services.AddScoped<Domain.Invoicing.Services.IInvoiceNumberSequenceService, Infrastructure.Invoicing.Services.InvoiceNumberSequenceService>();
        _ = services.AddScoped<ICmsRepository, Infrastructure.Cms.Persistence.Repositories.CmsRepository>();

        // Autenticazione JWT
        var jwtSecret = configuration["Jwt:Secret"] ?? "OpenX_Enterprise_Super_Secret_Key_For_Swiss_TimeTracking_2026_Minimum_32_Bytes!";
        var jwtIssuer = configuration["Jwt:Issuer"] ?? "OpenXGest";
        var jwtAudience = configuration["Jwt:Audience"] ?? "OpenXGestClient";

        _ = services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                ValidateIssuer = true,
                ValidIssuer = jwtIssuer,
                ValidateAudience = true,
                ValidAudience = jwtAudience,
                ClockSkew = TimeSpan.Zero,
            };
        });

        return services;
        ArgumentNullException.ThrowIfNull(builder);
        return builder;
    }
}

