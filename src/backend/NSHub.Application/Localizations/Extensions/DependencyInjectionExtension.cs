// <copyright file="DependencyInjectionExtension.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using NSHub.Application.Localizations.Helpers;

namespace NSHub.Application.Localizations.Extensions;

public static class DependencyInjectionExtension
{
	public static ReadOnlyCollection<string> SupportedCultures => ["it-IT", "en-GB", "fr-FR", "de-DE"];

	public static IServiceCollection AddLocalizationServices(this IServiceCollection services)
	{
		ArgumentNullException.ThrowIfNull(services);

        _ = services.AddLocalization(options => options.ResourcesPath = "Localization");

        _ = services.AddMvc(options => options.SuppressAsyncSuffixInActionNames = false).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (_, factory) =>
            {
                var tmpAssembly = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName!)!;
                return factory.Create("SharedResource", tmpAssembly.Name!);
            });

		return services;
	}

	public static WebApplicationBuilder AddLocalizationBuilder(this WebApplicationBuilder builder) => builder;

    public static WebApplication AddLocalizationApp(this WebApplication app)
	{
		var localizationOptions = new RequestLocalizationOptions
		{
			ApplyCurrentCultureToResponseHeaders = true,
			RequestCultureProviders =
			[
				new QueryStringRequestCultureProvider(),
				new CookieRequestCultureProvider(),
				new AcceptLanguageHeaderRequestCultureProvider(),
			],
		};

        _ = localizationOptions.AddSupportedCultures([.. SupportedCultures])
.AddSupportedUICultures([.. SupportedCultures])
.SetDefaultCulture(SupportedCultures[0]);

        _ = app.UseRequestLocalization(localizationOptions);

		CultureInfoHelper.SetCultureInfo(SupportedCultures[0]);

		return app;
	}
}
