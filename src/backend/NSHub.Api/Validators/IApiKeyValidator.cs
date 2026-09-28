// <copyright file="IApiKeyValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Api.Validators;

/// <summary>
/// Defines the contract for validating API keys provided in HTTP requests.
/// </summary>
public interface IApiKeyValidator
{
    /// <summary>
    /// Validates whether the supplied API key matches authorized credentials.
    /// </summary>
    /// <param name="apiKey">The API key string to validate.</param>
    /// <returns><c>true</c> if valid; otherwise <c>false</c>.</returns>
    bool IsValid(string apiKey);
}
