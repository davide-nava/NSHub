// <copyright file="SentResultType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

using System.Text.Json.Serialization;

/// <summary>
/// Represents the result type of a sent operation.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SentResultType
{
    /// <summary>
    /// Represents a successful sent operation.
    /// </summary>
    Success = 1,

    /// <summary>
    /// Represents an error occurred during the sent operation.
    /// </summary>
    Error = 2,
}
