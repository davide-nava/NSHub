// <copyright file="DependencyInjectionExtension.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using System.Data;
using System.Net;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using NSHub.Cryptographies.Services;
using NSHub.Logs.Enums;
using NSHub.Logs.Handlers;
using NSHub.Logs.Middlewares;

using Scrutor;

using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Sinks.Email;
using Serilog.Sinks.MSSqlServer;

namespace NSHub.Logs.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddLogServices(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddExceptionHandler<DefaultExceptionHandler>();

        _ = services.AddProblemDetails(options =>
 options.CustomizeProblemDetails = ctx =>
 {
     ctx.ProblemDetails.Extensions.Add(nameof(SerilogType.Date), DateTime.Now);
     ctx.ProblemDetails.Extensions.Add(nameof(SerilogType.Host), ctx.HttpContext?.Request.Host.Value ?? string.Empty);
     ctx.ProblemDetails.Extensions.Add(nameof(SerilogType.Email), ctx.HttpContext?.User?.Identity?.Name ?? string.Empty);
     ctx.ProblemDetails.Extensions.Add(nameof(SerilogType.Path), ctx.HttpContext?.Request?.Path.Value);
     ctx.ProblemDetails.Extensions.Add(nameof(SerilogType.Method), ctx.HttpContext?.Request?.Method);
     ctx.ProblemDetails.Extensions.Add(nameof(SerilogType.MachineName), Environment.MachineName);
     ctx.ProblemDetails.Extensions.Add(nameof(SerilogType.Application), Assembly.GetCallingAssembly().FullName);
     ctx.ProblemDetails.Extensions.Add(nameof(SerilogType.TenantId), ctx.HttpContext?.User?.Claims?.FirstOrDefault(e => e.Type == nameof(SerilogType.TenantId))?.Value ?? "");
     ctx.ProblemDetails.Extensions.Add(nameof(SerilogType.UserId), ctx.HttpContext?.User?.Claims?.FirstOrDefault(e => e.Type == nameof(SerilogType.UserId))?.Value ?? "");
 });
        return services;
    }

    public static ILogger AddSerilogBuilder(this WebApplicationBuilder builder, string? connectionStringMSSqlServerName = null)
    {
        ArgumentNullException.ThrowIfNull(builder);
        var tmpLogger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
              .Enrich.FromLogContext()
              .Enrich.WithClientIp()
    .Enrich.WithCorrelationId()

              //.Enrich.WithRequestHeader("User-Agent", "ClientAgent")
              ;

        if (Convert.ToBoolean(builder.Configuration.GetSection("NSHub:SerilogEmail").Value))
        {
            tmpLogger = tmpLogger.WriteTo.Email(
                options: new EmailSinkOptions()
                {
                    Subject = new MessageTemplateTextFormatter("NSHub - {Level}"),
                    Body = new MessageTemplateTextFormatter("{Host} {Timestamp:HH:mm:ss} {Level:u3} <br/>TenantId:{TenantId} <br/>Email:{Email} <br/>Endpoint:{EndpointDisplayName} <br/>CorrelationId:{CorrelationId} <br/>RequestIp:{RequestIp} <br/>Host:{Host} <br/>MachineName:{MachineName}<br/><br/>{Message}<br/><br/>{Exception}"),
                    IsBodyHtml = true,
                    From = AesService.Decrypt(Convert.ToString(builder.Configuration.GetSection("Smtp:Sender").Value)!),
                    Host = AesService.Decrypt(Convert.ToString(value: builder.Configuration.GetSection("Smtp:Host").Value)!),
                    Port = Convert.ToInt32(builder.Configuration.GetSection("Smtp:Port").Value)!,
                    ConnectionSecurity = MailKit.Security.SecureSocketOptions.Auto,
                    Credentials = new NetworkCredential(AesService.Decrypt(Convert.ToString(builder.Configuration.GetSection("Smtp:Username").Value)!), AesService.Decrypt(Convert.ToString(builder.Configuration.GetSection("Smtp:Password").Value)!)),
                    To = [AesService.Decrypt(Convert.ToString(builder.Configuration.GetSection("Smtp:Ticket").Value)!),],
                },
                batchingOptions: new BatchingOptions()
                {
                    BatchSizeLimit = 100,
                    BufferingTimeLimit = TimeSpan.FromSeconds(30),
                });
        }

        if (Convert.ToBoolean(builder.Configuration.GetSection("NSHub:SerilogSQLite").Value))
        {
            tmpLogger = tmpLogger.WriteTo.SQLite(@"Logs\log.db", "SerilogSQLite", LogEventLevel.Verbose, maxDatabaseSize: 10000);
        }

        if (Convert.ToBoolean(builder.Configuration.GetSection("NSHub:SerilogMSSqlServer").Value) && !string.IsNullOrWhiteSpace(connectionStringMSSqlServerName))
        {
            var columnOptions = new ColumnOptions();
            columnOptions.Store.Remove(StandardColumn.Id);
            columnOptions.Store.Remove(StandardColumn.TimeStamp);
            columnOptions.Store.Add(StandardColumn.LogEvent);
            columnOptions.Store.Add(StandardColumn.TraceId);

            columnOptions.AdditionalColumns = new List<SqlColumn>
{
    new SqlColumn("Id", SqlDbType.UniqueIdentifier),
    new SqlColumn(nameof(SerilogType.MachineName), SqlDbType.NVarChar),
    new SqlColumn(nameof(SerilogType.Host), SqlDbType.NVarChar),
    new SqlColumn(nameof(SerilogType.RequestIp), dataType: SqlDbType.NVarChar),
    new SqlColumn(nameof(SerilogType.EndpointDisplayName), SqlDbType.NVarChar),
    new SqlColumn(nameof(SerilogType.CorrelationId), SqlDbType.NVarChar),
    new SqlColumn(nameof(SerilogType.Email), SqlDbType.NVarChar),
    new SqlColumn(nameof(SerilogType.Path), SqlDbType.NVarChar),
    new SqlColumn(nameof(SerilogType.Method), SqlDbType.NVarChar),
    new SqlColumn(nameof(SerilogType.Application), SqlDbType.NVarChar),
    new SqlColumn(nameof(SerilogType.TenantId), SqlDbType.UniqueIdentifier,true),
    new SqlColumn(nameof(SerilogType.LogTypeId), SqlDbType.UniqueIdentifier, true),
    new SqlColumn(nameof(SerilogType.UserId), SqlDbType.UniqueIdentifier, true),
    new SqlColumn(nameof(SerilogType.RecordId), SqlDbType.UniqueIdentifier, true),
    new SqlColumn(nameof(SerilogType.Date), SqlDbType.DateTime, true),
    new SqlColumn(nameof(SerilogType.LogActionTypeId), SqlDbType.UniqueIdentifier, true),
    new SqlColumn(nameof(SerilogType.OldValue), SqlDbType.NVarChar, true),
    new SqlColumn(nameof(SerilogType.NewValue), SqlDbType.NVarChar, true),
};

            tmpLogger = tmpLogger.WriteTo.MSSqlServer(
        connectionStringMSSqlServerName,
        sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true, AutoCreateSqlDatabase = true, BatchPeriod = TimeSpan.FromSeconds(10), BatchPostingLimit = 100, }, columnOptions: columnOptions);
        }

        builder.Services.Scan(scan => scan.FromAssemblyOf<SerilogMiddleware>().AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip).AsMatchingInterface().WithTransientLifetime());

        return tmpLogger.CreateLogger();
    }
}
