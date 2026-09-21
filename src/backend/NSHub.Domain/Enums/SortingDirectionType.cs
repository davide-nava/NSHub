// <copyright file="SortingDirectionType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

using System.Text.Json.Serialization;

/// <summary>
/// Represents the sorting direction type for ordering data.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortingDirectionType
{
    /// <summary>
    /// Represents ascending sorting direction.
    /// </summary>
    Asc = 1,

    /// <summary>
    /// Represents descending sorting direction.
    /// </summary>
    Desc = 2,
}
