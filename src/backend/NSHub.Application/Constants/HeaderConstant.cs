// <copyright file="HeaderConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Constants;

/// <summary>
/// Defines custom HTTP header names used throughout the application.
/// </summary>
public static class HeaderConstant
{
    /// <summary>
    /// Represents the header containing the tenant identifier.
    /// </summary>
    public const string TENANTID = "X-TenantId";

    /// <summary>
    /// Represents the header containing the user identifier.
    /// </summary>
    public const string USERID = "X-UserId";

    /// <summary>
    /// Represents the header containing the language identifier.
    /// </summary>
    public const string LANGUAGEID = "X-LanguageId";

    /// <summary>
    /// Represents the header containing the application identifier.
    /// </summary>
    public const string APPLICATIONID = "X-ApplicationId";

    /// <summary>
    /// Represents the header containing the API key.
    /// </summary>
    public const string APIKEY = "X-Api-Key";
}
