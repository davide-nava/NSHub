// <copyright file="ThemeType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

using System.Text.Json.Serialization;

/// <summary>
/// User interface color theme modes.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ThemeType
{
    /// <summary>
    /// Light visual theme.
    /// </summary>
    Light = 0,

    /// <summary>
    /// Dark visual theme.
    /// </summary>
    Dark = 1,
}
