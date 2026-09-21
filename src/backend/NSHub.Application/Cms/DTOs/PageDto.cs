// <copyright file="PageDto.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Cms.DTOs;

/// <summary>
/// Data transfer object representing a CMS page.
/// </summary>
public sealed record PageDto(
    Guid Id,
    string Title,
    string Slug,
    string Content,
    string Summary,
    Guid AuthorId,
    string Status,
    string MetaTitle,
    string MetaDescription,
    string MetaKeywords,
    string? CanonicalUrl,
    DateTime? PublishedAtUtc,
    DateTime CreatedAtUtc,
    IReadOnlyList<string> Tags);
