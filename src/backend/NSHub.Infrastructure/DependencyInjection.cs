// <copyright file="DependencyInjection.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Common;
using NSHub.Domain.Repositories;
using NSHub.Infrastructure.Persistence;
using NSHub.Infrastructure.Persistence.Interceptors;
using NSHub.Infrastructure.Persistence.Repositories;
using NSHub.Infrastructure.Services;
using IEmployeeRepository = NSHub.Application.Common.Interfaces.IEmployeeRepository;
using ITimeEntryRepository = NSHub.Application.Common.Interfaces.ITimeEntryRepository;

namespace NSHub.Infrastructure;

/// <summary>
/// Extension methods for setting up infrastructure services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds infrastructure services, repositories, database contexts, and authentication to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration instance.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
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
        _ = services.AddSingleton<NSHub.Domain.Identity.Services.IPasswordHasher, NSHub.Infrastructure.Identity.Services.PasswordHasher>();
        _ = services.AddScoped<IUserRepository, NSHub.Infrastructure.Identity.Persistence.Repositories.UserRepository>();
        _ = services.AddScoped<ITicketRepository, NSHub.Infrastructure.Tickets.Persistence.Repositories.TicketRepository>();
        _ = services.AddScoped<IInventoryRepository, NSHub.Infrastructure.Warehouse.Persistence.Repositories.InventoryRepository>();
        _ = services.AddScoped<IInvoiceRepository, NSHub.Infrastructure.Invoicing.Persistence.Repositories.InvoiceRepository>();
        _ = services.AddScoped<NSHub.Domain.Invoicing.Services.IInvoiceNumberSequenceService, NSHub.Infrastructure.Invoicing.Services.InvoiceNumberSequenceService>();
        _ = services.AddScoped<ICmsRepository, NSHub.Infrastructure.Cms.Persistence.Repositories.CmsRepository>();

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
    }
}
