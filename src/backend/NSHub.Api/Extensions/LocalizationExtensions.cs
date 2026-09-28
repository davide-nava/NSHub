// <copyright file="LocalizationExtensions.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Collections.ObjectModel;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using NSHub.Application.Localizations;
using NSHub.Application.Localizations.Helpers;

namespace NSHub.Api.Extensions;

/// <summary>
/// Extension methods for configuring ASP.NET Core localization services and middleware.
/// </summary>
public static class LocalizationExtensions
{
    /// <summary>
    /// Gets the list of supported culture codes.
    /// </summary>
    public static ReadOnlyCollection<string> SupportedCultures => ["it-IT", "en-GB", "fr-FR", "de-DE"];

    /// <summary>
    /// Configures localization services and MVC view/data annotations localization.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The configured service collection.</returns>
    public static IServiceCollection AddLocalizationServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        _ = services.AddLocalization(options => options.ResourcesPath = "Localization");

        _ = services.AddMvc(options => options.SuppressAsyncSuffixInActionNames = false)
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (_, factory) =>
            {
                var tmpAssembly = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName!)!;
                return factory.Create("SharedResource", tmpAssembly.Name!);
            });

        return services;
    }

    /// <summary>
    /// Configures request localization middleware for the application.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <returns>The web application instance.</returns>
    public static WebApplication AddLocalizationApp(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

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
