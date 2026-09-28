// <copyright file="Program.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;
using Microsoft.OpenApi;
using NSHub.Application.Extensions;
using NSHub.Infrastructure.Extensions;
using NSHub.Infrastructure.Identity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults (Aspire, OpenTelemetry, health checks)
builder.AddServiceDefaults();

// Configure Serilog
builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

// Configure Database Connection String
var connectionString = builder.Configuration.GetConnectionString("NSHub")
    ?? "Server=localhost;Database=NSHub;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;Connect Timeout=360;";

// Application & Infrastructure Services
_ = builder.Services.AddApplicationServices();
_ = builder.AddInfrastructureShareBuilder(connectionString);
_ = builder.AddInfrastructureBuilder();

// Controllers and JSON Serialization
_ = builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Swagger / OpenAPI documentation
_ = builder.Services.AddEndpointsApiExplorer();
_ = builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NSHub API",
        Version = "v1",
        Description = "NSHub Core Web API",
    }));

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NSHub API v1"));
}

_ = app.UseHttpsRedirection();

_ = app.UseRouting();

_ = app.UseAuthentication();
_ = app.UseAuthorization();

_ = app.MapControllers();
_ = app.MapIdentityApi<ApplicationUser>();

try
{
    _ = await app.UseMigrationsAsync();
}
catch (Exception ex)
{
    app.Logger.LogWarning(ex, "An error occurred while applying database migrations.");
}

await app.RunAsync();
