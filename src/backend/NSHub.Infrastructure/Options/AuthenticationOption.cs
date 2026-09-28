// <copyright file="AuthenticationOption.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Options;

/// <summary>
/// Represents the authentication configuration settings used by the application.
/// </summary>
public class AuthenticationOption
{
    /// <summary>
    /// Gets or sets the Microsoft OAuth client identifier.
    /// </summary>
    public string MicrosoftClientId { get; set; } = "xxxx";

    /// <summary>
    /// Gets or sets the Microsoft OAuth client secret.
    /// </summary>
    public string MicrosoftClientSecret { get; set; } = "xxxx";

    /// <summary>
    /// Gets or sets the Google OAuth client identifier.
    /// </summary>
    public string GoogleClientId { get; set; } = "xxxx";

    /// <summary>
    /// Gets or sets the Google OAuth client secret.
    /// </summary>
    public string GoogleClientSecret { get; set; } = "xxxx";

    /// <summary>
    /// Gets or sets the file system path used to persist data protection keys.
    /// </summary>
    public string PersistKeysToFileSystem { get; set; } = "xxxx";

    /// <summary>
    /// Gets or sets the cookie domain used by the application.
    /// </summary>
    public string CookieDomain { get; set; } = "xxxx";

    /// <summary>
    /// Gets or sets a value indicating whether Google authentication is enabled.
    /// </summary>
    public bool IsGoogle { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether Microsoft authentication is enabled.
    /// </summary>
    public bool IsMicrosoft { get; set; }
}
