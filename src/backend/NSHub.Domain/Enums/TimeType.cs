// <copyright file="TimeType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

using System.Text.Json.Serialization;

/// <summary>
/// Time measurement units.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TimeType
{
    /// <summary>
    /// Hour-based time representation.
    /// </summary>
    Hour = 1,

    /// <summary>
    /// Day-based time representation.
    /// </summary>
    Day = 2,
}
