// <copyright file="DependencyInjectionExtension.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NSHub.Caches.Interfaces;
using NSHub.Caches.Services;
using NSHub.Localization.Extensions;
using NSHub.Logs.Middlewares;
using NSHub.Options;

using Scrutor;

using Serilog;

namespace NSHub.ApplicationCore.Helpers;

public static class DependencyInjectionHelper
{
	//public static WebApplicationBuilder AddNSHubApiKeyFilter(this WebApplicationBuilder builder)
	//{
	//	builder.Services.AddSingleton<ApiKeyAuthorizationFilter>();

	//	builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();

	//	return builder;
	//}

	public static WebApplicationBuilder AddBuildConfig(this WebApplicationBuilder builder)
	{
		ArgumentNullException.ThrowIfNull(builder);
		var basePath = Assembly.GetExecutingAssembly().Location;
		var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "PRODUCTION";

		builder.Configuration.SetBasePath(Path.GetDirectoryName(basePath) ?? Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.json", false, true)
			   .AddJsonFile($"appsettings.{environmentName}.json", true, true)
			   .AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true)
			.AddEnvironmentVariables()
			.AddKeyPerFile("/run/secrets", optional: true);

		return builder;
	}

	public static WebApplicationBuilder AddDefaultOptionsIfPrest(this WebApplicationBuilder builder)
	{
		ArgumentNullException.ThrowIfNull(builder);
		if (builder.Configuration.GetSection("NSHub") != null)
		{
			builder.Services.AddOptionsWithValidateOnStart<NSHubOption>().Bind(builder.Configuration.GetSection("NSHub"));
		}

		if (builder.Configuration.GetSection("Smtp") != null)
		{
			builder.Services.AddOptionsWithValidateOnStart<SmtpOption>().Bind(builder.Configuration.GetSection("Smtp"));
		}

		if (builder.Configuration.GetSection("Authentication") != null)
		{
			builder.Services.AddOptionsWithValidateOnStart<AuthenticationOption>().Bind(builder.Configuration.GetSection("Authentication"));
		}

		return builder;
	}

	private static WebApplicationBuilder AddNSHubCors(this WebApplicationBuilder builder)
	{
		var tmpCors = Convert.ToString(value: builder.Configuration.GetSection("NSHub:Cors").Value ?? string.Empty, CultureInfo.InvariantCulture);

		tmpCors = tmpCors.Replace(" ", string.Empty, StringComparison.InvariantCulture);

		builder.Services.AddCors(options => options.AddPolicy(
				name: "NSHub",
				corsPolicyBuilder =>
				{
					if (tmpCors.Equals("<any>", StringComparison.OrdinalIgnoreCase))
					{
						corsPolicyBuilder.AllowAnyOrigin();
					}
					else
					{
						corsPolicyBuilder.WithOrigins(tmpCors.Split(','));
					}

					corsPolicyBuilder.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials();
				}));

		return builder;
	}

	public static WebApplicationBuilder AddDefaultConfigBuilder(this WebApplicationBuilder builder)
	{
		ArgumentNullException.ThrowIfNull(builder);
		_ = builder.Services.AddSingleton<INSHubMemoryCacheService, NSHubMemoryCacheService>();

		builder.AddNSHubCors();

		_ = builder.Services.AddMemoryCache();
		_ = builder.Services.AddOpenApi();

		_ = builder.Services.Configure<FormOptions>(x =>
		{
			x.ValueLengthLimit = int.MaxValue;
			x.MultipartBodyLengthLimit = int.MaxValue;
			x.MultipartBoundaryLengthLimit = int.MaxValue;
			x.MultipartHeadersCountLimit = int.MaxValue;
			x.MultipartHeadersLengthLimit = int.MaxValue;
		});

		builder.Services.AddResponseCompression(opts =>
		{
			opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(["application/octet-stream"]);
			opts.EnableForHttps = true;
		});

		builder.Services.AddSignalR(options =>
		{
			options.EnableDetailedErrors = true;
			options.ClientTimeoutInterval = TimeSpan.MaxValue;
			options.KeepAliveInterval = TimeSpan.FromSeconds(15);
		}).AddJsonProtocol(options =>
		{
			options.PayloadSerializerOptions.IgnoreReadOnlyFields = true;
			options.PayloadSerializerOptions.WriteIndented = true;
			options.PayloadSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
			options.PayloadSerializerOptions.MaxDepth = 64;
			options.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
			options.PayloadSerializerOptions.AllowTrailingCommas = true;
		});

		builder.Services.AddControllers().AddJsonOptions(options =>
		{
			options.JsonSerializerOptions.WriteIndented = true;
			options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
			options.JsonSerializerOptions.MaxDepth = 64;
			options.JsonSerializerOptions.IgnoreReadOnlyProperties = false;
			options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
			options.JsonSerializerOptions.AllowTrailingCommas = true;
			options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
			options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;

			//options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
		});

		_ = builder.Services.AddResponseCaching();

		builder.Services.Scan(scan => scan.FromAssemblyOf<ClaimHelper>().AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip).AsMatchingInterface().WithTransientLifetime());

		builder.Services.AddLocalizationServices();
		builder.Services.AddHealthChecks();
		builder.Services.AddValidation();

		return builder;
	}

	public static WebApplication AddDefaultConfigApp(this WebApplication app)
	{
		ArgumentNullException.ThrowIfNull(app);
		app.UseMiddleware<SerilogMiddleware>();

		app.UseSerilogRequestLogging();

		// app.UseMiddleware<NSHubHeaderMiddleware>( );

		if (app.Environment.IsDevelopment())
		{
			_ = app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler();
			app.UseStatusCodePages();
		}

		_ = app.AddLocalizationApp();

		_ = app.UseResponseCompression();

		app.UseCors("NSHub");
		_ = app.MapStaticAssets();

		//app.MapHealthChecks(NSHubEndpoint.GetHealth);
		_ = app.MapOpenApi();

		app.UseResponseCaching();

		return app;
	}
}
