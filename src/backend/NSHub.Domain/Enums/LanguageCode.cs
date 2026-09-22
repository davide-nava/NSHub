// <copyright file="LanguageCode.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace NSHub.Domain.Enums;

/// <summary>
/// Supported national official languages.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LanguageCode
{
    /// <summary>
    /// Italian (Switzerland).
    /// </summary>
    It = 1,

    /// <summary>
    /// German (Switzerland).
    /// </summary>
    De = 2,

    /// <summary>
    /// French (Switzerland).
    /// </summary>
    Fr = 3,

    /// <summary>
    /// English.
    /// </summary>
    En = 4,
}
