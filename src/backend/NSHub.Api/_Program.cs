// <copyright file="Program.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using PlanetHub.Api.ExceptionHandling.Extensions;
using PlanetHub.Api.HostedServices;
using PlanetHub.Api.Hubs;
using PlanetHub.Api.Infrastructure.Extensions;
using PlanetHub.Api.Middlewares;
using PlanetHub.ApplicationCore.Extensions;
using PlanetHub.ApplicationCore.Helpers;
using PlanetHub.ApplicationCore.Interfaces;
using PlanetHub.Cryptographies.Services;
using PlanetHub.Endpoints;
using PlanetHub.Endpoints.Api;
using PlanetHub.Infrastructure.Extensions;
using PlanetHub.Infrastructure.Services;
using PlanetHub.Localization.Extensions;
using PlanetHub.Logs.Extensions;
using PlanetHub.Models;
using PlanetHub.Swaggers.Extensions;
using PlanetHub.Web.ApplicationCore.Extensions;

using Scrutor;

using Serilog;

using Web.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddBuildConfig();
builder.AddDefaultOptionsIfPrest();

var connectionString= AesService.Decrypt(builder.Configuration.GetConnectionString("PlanetHub") ?? throw new InvalidOperationException("Connection string PlanetHub not found."));

Serilog.Debugging.SelfLog.Enable(Console.WriteLine);
Log.Logger = builder.AddSerilogBuilder(connectionString);

try
{
    builder.Host.UseSerilog();

    builder.Services.AddExceptionStrategy();
    
    builder.AddApplicationMappers();
    builder.AddApplicationCoreShareBuilder();
    builder.AddApplicationCoreBuilder();
    builder.AddInfrastructureShareBuilder(connectionString);
    builder.AddInfrastructureBuilder();

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddHttpContextAccessor();

    builder.Services.AddScoped<IRequestContext, RequestContext>();
    builder.Services.AddTransient<HeaderMiddleware>();

    builder.Services.AddLogServices();
    builder.Services.AddLocalizationServices();

    builder.Services.AddSwaggerServices("PlanetHub");

    builder.AddDefaultConfigBuilder();

    //builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
    //builder.Services.AddValidatorsFromAssemblyContaining<CreateContrattoRequestValidator>();

    builder.Services.AddSingleton<ApiHostedService>();
    builder.Services.AddHostedService<ApiHostedService>();

    builder.Services.Scan(scan => scan.FromAssemblyOf<Program>().AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip).AsMatchingInterface().WithTransientLifetime());

    var app = builder.Build();

    app.AddDefaultConfigApp();

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseMiddleware<HeaderMiddleware>();

    app.UseAuthentication();
    app.UseAuthorization();

    app.AddSwaggerApp();

    app.MapDefaultEndpoints();
    app.MapHealthChecks(PlanetHubEndpoint.GetHealth);
    app.MapControllers();
    app.MapHub<PlanetHubApiHub>(HubsEndpoint.Api);
    app.MapIdentityApi<ApplicationUser>();

    await app.UseMigrationsAsync();

#pragma warning disable S6966 // Awaitable method should be used
    app.Run();
#pragma warning restore S6966 // Awaitable method should be used

    app.Logger.LogInformation("PlanetHub.API started...");
}
catch (Exception ex)
{
    Log.Fatal(ex, "PlanetHub.API application terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}

namespace PlanetHub.Api
{
#pragma warning disable S2094 // Classes should not be empty
#pragma warning disable RCS1043 // Remove 'partial' modifier from type with a single part
    public partial class Program;
#pragma warning restore RCS1043 // Remove 'partial' modifier from type with a single part
#pragma warning restore S2094 // Classes should not be empty
}
