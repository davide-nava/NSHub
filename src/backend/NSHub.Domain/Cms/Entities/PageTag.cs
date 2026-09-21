// <copyright file="PageTag.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Cms.Entities;

using NSHub.Domain.Cms.ValueObjects;

/// <summary>
/// Domain entity representing a tag associated with a CMS page.
/// </summary>
public class PageTag
{
    /// <summary>
    /// Gets the parent page identifier.
    /// </summary>
    public PageId PageId { get; private set; }

    /// <summary>
    /// Gets the tag identifier.
    /// </summary>
    public TagId TagId { get; private set; }

    /// <summary>
    /// Gets the normalized tag name.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    // Parameterless constructor for EF Core
    private PageTag()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PageTag"/> class.
    /// </summary>
    public PageTag(PageId pageId, TagId tagId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Tag name cannot be empty.", nameof(name));
        }

        PageId = pageId;
        TagId = tagId.Value == Guid.Empty ? TagId.New() : tagId;
        Name = name.Trim().ToLowerInvariant();
    }
}
