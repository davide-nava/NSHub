// <copyright file="PublishingStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace NSHub.Domain.Enums;

/// <summary>
/// Lifecycle statuses for CMS content publishing workflows.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PublishingStatus
{
    /// <summary>
    /// Content in draft stage, unpublished.
    /// </summary>
    Draft = 1,

    /// <summary>
    /// Under editorial review.
    /// </summary>
    Review = 2,

    /// <summary>
    /// Published and publicly visible.
    /// </summary>
    Published = 3,

    /// <summary>
    /// Deprecated or archived, no longer publicly active.
    /// </summary>
    Archived = 4,
}
