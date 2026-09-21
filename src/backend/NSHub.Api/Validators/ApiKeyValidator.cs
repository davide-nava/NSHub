// <copyright file="ApiKeyValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Options;

namespace NSHub.Api.Validators;

/// <summary>
/// Service validating incoming API keys against configured application security options.
/// </summary>
/// <param name="nSHubOption">The application options containing authorized credentials.</param>
/// <param name="logger">The logger instance.</param>
public class ApiKeyValidator(NSHubOption nSHubOption, ILogger<ApiKeyValidator> logger) : IApiKeyValidator
{
    /// <summary>
    /// Validates whether the supplied API key matches the configured system API key.
    /// </summary>
    /// <param name="apiKey">The API key to evaluate.</param>
    /// <returns><c>true</c> if valid; otherwise <c>false</c>.</returns>
    public bool IsValid(string apiKey)
    {
		ArgumentException.ThrowIfNullOrEmpty(apiKey);

		if (nSHubOption?.ApiKey != apiKey && logger.IsEnabled(LogLevel.Error))
		{
			logger.LogError("Invalid API key {ApiKey}.", apiKey);
		}

		return nSHubOption?.ApiKey == apiKey;
    }
}
