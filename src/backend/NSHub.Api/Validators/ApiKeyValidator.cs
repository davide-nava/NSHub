// <copyright file="ApiKeyValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Options;

namespace NSHub.Api.Validators;

public class ApiKeyValidator(NSHubOption nSHubOption, ILogger<ApiKeyValidator> logger) : IApiKeyValidator
{
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
