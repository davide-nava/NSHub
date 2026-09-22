// <copyright file="PageTag.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing a tag associated with a CMS page.
/// </summary>
public class PageTag
{
    /// <summary>
    /// Gets or sets the parent page identifier.
    /// </summary>
    public Guid PageId { get; set; }

    /// <summary>
    /// Gets or sets the tag identifier.
    /// </summary>
    public Guid TagTypeId { get; set; }
}
