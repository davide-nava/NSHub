// <copyright file="DependencyInjectionExtension.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.OpenApi;
using NSHub.Api.OperationFilters;
using Scrutor;

namespace NSHub.Api.Extensions;

/// <summary>
/// Provides extension methods for configuring Swagger/OpenAPI documentation services and middleware.
/// </summary>
public static class DependencyInjectionExtension
{
    /// <summary>
    /// Configures and registers Swagger/OpenAPI documentation services in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="title">API documentation title.</param>
    /// <param name="addTenantId">Whether to include the TenantId header in operations.</param>
    /// <param name="email">Contact support email address.</param>
    /// <param name="includeXmlCommentsFilter">File search pattern for XML documentation files.</param>
    /// <param name="useBearer">Whether to configure Bearer token authentication scheme.</param>
    /// <param name="useApiKey">Whether to configure API key authentication scheme.</param>
    /// <param name="version">API version identifier.</param>
    /// <param name="description">API description summary.</param>
    /// <param name="license">License URL string.</param>
    /// <param name="termsOfService">Terms of service URL string.</param>
    /// <param name="contact">Contact website URL string.</param>
    /// <returns>The updated service collection.</returns>
	public static IServiceCollection AddSwaggerServices(this IServiceCollection services, string title, bool addTenantId = false, string email = "support@nSHub.ch", string includeXmlCommentsFilter = "nSHub.*.xml", bool useBearer = true, bool useApiKey = false, string version = "v1", string description = "NSHub", string license = "https://www.nSHub.ch/license", string termsOfService = "https://www.nSHub.ch/terms", string contact = "https://wwww.nSHub.ch/contatti")
	{
        _ = services.Scan(scan => scan.FromAssemblyOf<CustomHeaderParameter>().AddClasses().UsingRegistrationStrategy(RegistrationStrategy.Skip).AsMatchingInterface().WithTransientLifetime());

		_ = services.AddEndpointsApiExplorer();

		_ = services.AddSwaggerGen(options =>
		{
			options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
			options.IgnoreObsoleteActions();
			options.IgnoreObsoleteProperties();
			options.EnableAnnotations();

			options.MapType<IFormFile>(() => new OpenApiSchema() { Type = JsonSchemaType.Object, Format = "binary" });

			options.SwaggerDoc(version, new OpenApiInfo
			{
				Version = version,
				Title = title,
				Description = description,
				TermsOfService = new Uri(termsOfService),
				Contact = new OpenApiContact
				{
					Name = "Davide NAVA",
					Email = email,
					Url = new Uri(contact),
				},
				License = new OpenApiLicense
				{
					Name = "Davide NAVA",
					Url = new Uri(license),
				},
			});

			options.OperationFilter<CustomHeaderParameter>(addTenantId);

			if (useBearer)
			{
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "Identity.External",
					Scheme = "Bearer",
				});

				//	options.AddSecurityRequirement(new OpenApiSecurityRequirement
				//{
				//	{
				//		new OpenApiSecurityScheme
				//		{
				//			Reference = new OpenApiReference
				//			{
				//				Type = ReferenceType.SecurityScheme,
				//				Id = "Bearer",
				//			},
				//		},
				//		Array.Empty<string>()
				//	},
				//});
			}

			//if (useApiKey)
			//{
			//	//options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
			//	//{
			//	//	In = ParameterLocation.Header,
			//	//	Description = "Please enter a valid API Key",
			//	//	Name = HeaderConstant.ApiKey,
			//	//	Type = SecuritySchemeType.ApiKey,
			//	//	Scheme = "ApiKeyScheme",
			//	//});

			//	//	options.AddSecurityRequirement(new OpenApiSecurityRequirement
			//	//{
			//	//	{
			//	//		new OpenApiSecurityScheme
			//	//		{
			//	//			Reference = new OpenApiReference
			//	//			{
			//	//				Type = ReferenceType.Schema,
			//	//				Id = "ApiKey",
			//	//			},
			//	//		},
			//	//		Array.Empty<string>()
			//	//	},
			//	//});
			//}

			options.CustomSchemaIds(type => type.ToString());

			var xmls = Directory.GetFiles(AppContext.BaseDirectory, "PlaneHub.*.xml");

			if (xmls?.Length > 0)
			{
				foreach (var xml in xmls)
				{
					options.IncludeXmlComments(xml, true);
				}
			}

			var xmlsAssembly = Directory.GetFiles(AppContext.BaseDirectory, includeXmlCommentsFilter);

			if (xmlsAssembly?.Length > 0)
			{
				foreach (var xml in xmlsAssembly)
				{
					options.IncludeXmlComments(xml, true);
				}
			}
		});

		return services;
	}

    /// <summary>
    /// Configures the Swagger UI, static files, and OpenAPI endpoints for the application pipeline.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <returns>The updated web application instance.</returns>
	public static WebApplication AddSwaggerApp(this WebApplication app)
	{
		_ = app.UseSwagger();
		_ = app.UseSwaggerUI(options =>
		{
			options.SwaggerEndpoint("/openapi/v1.json", app.Environment.ApplicationName);
			options.EnableDeepLinking();
			options.InjectStylesheet("/css/Swagger.css");
		});

		_ = app.MapSwagger().RequireAuthorization().RequireAuthorization("Administrator");

        _ = app.UseStaticFiles();

		return app;
	}
}
