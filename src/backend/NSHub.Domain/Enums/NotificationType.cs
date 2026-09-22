// <copyright file="NotificationType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace NSHub.Domain.Enums;

/// <summary>
/// System and user notification severities.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NotificationType
{
    /// <summary>
    /// Error notification.
    /// </summary>
    Error = 0,

    /// <summary>
    /// Success notification.
    /// </summary>
    Success = 1,

    /// <summary>
    /// Warning notification.
    /// </summary>
    Warning = 2,

    /// <summary>
    /// Informational notification.
    /// </summary>
    Info = 3,

    /// <summary>
    /// Neutral notification.
    /// </summary>
    Neutral = 4,
}
