// <copyright file="SeoMetadata.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Cms.ValueObjects;

/// <summary>
/// Search Engine Optimization (SEO) metadata for a CMS page.
/// </summary>
/// <param name="MetaTitle">The HTML title tag.</param>
/// <param name="MetaDescription">The meta description for search engines.</param>
/// <param name="MetaKeywords">Comma-separated meta keywords.</param>
/// <param name="CanonicalUrl">The canonical canonical URL if specified.</param>
public sealed record SeoMetadata(
    string MetaTitle,
    string MetaDescription,
    string MetaKeywords,
    string? CanonicalUrl = null)
{
    /// <summary>
    /// Returns default empty SEO metadata.
    /// </summary>
    public static SeoMetadata Empty => new(string.Empty, string.Empty, string.Empty);
}
