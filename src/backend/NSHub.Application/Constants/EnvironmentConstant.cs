// <copyright file="EnvironmentConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Constants;

/// <summary>
/// Defines environment variable names used by the application.
/// </summary>
public static class EnvironmentConstant
{
    /// <summary>
    /// Gets the environment variable name that stores the AES encryption key.
    /// </summary>
    public static string AesKey => "NSHUB_CRY_1";

    /// <summary>
    /// Gets the environment variable name that stores the AES initialization vector (IV).
    /// </summary>
    public static string AesIv => "NSHUB_CRY_2";
}
