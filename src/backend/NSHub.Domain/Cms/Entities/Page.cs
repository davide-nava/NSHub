// <copyright file="Page.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Cms.Entities;

using System.Text.RegularExpressions;
using NSHub.Domain.Cms.Enums;
using NSHub.Domain.Cms.ValueObjects;
using NSHub.Domain.Common;
using NSHub.Domain.Exceptions;

/// <summary>
/// Aggregate root representing a content management page with publishing workflow and SEO metadata.
/// </summary>
public partial class Page : AggregateRoot<PageId>
{
    private readonly List<PageTag> _tags = [];

    /// <summary>
    /// Gets the display title of the page.
    /// </summary>
    public string Title { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the URL-safe slug.
    /// </summary>
    public string Slug { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the primary content body (HTML or Markdown).
    /// </summary>
    public string Content { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the brief excerpt or summary.
    /// </summary>
    public string Summary { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the author user identifier.
    /// </summary>
    public Guid AuthorId { get; private set; }

    /// <summary>
    /// Gets the current publishing workflow status.
    /// </summary>
    public PublishingStatus Status { get; private set; }

    /// <summary>
    /// Gets the SEO metadata configuration.
    /// </summary>
    public SeoMetadata Seo { get; private set; } = SeoMetadata.Empty;

    /// <summary>
    /// Gets the UTC publication timestamp, if published.
    /// </summary>
    public DateTime? PublishedAtUtc { get; private set; }

    /// <summary>
    /// Gets the UTC creation timestamp.
    /// </summary>
    public DateTime CreatedAtUtc { get; private set; }

    /// <summary>
    /// Gets the associated content categorization tags.
    /// </summary>
    public IReadOnlyCollection<PageTag> Tags => _tags.AsReadOnly();

    // Parameterless constructor for EF Core
    private Page()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Page"/> aggregate root in Draft status.
    /// </summary>
    public Page(
        PageId id,
        string title,
        string? customSlug,
        string content,
        string summary,
        Guid authorId,
        SeoMetadata? seo = null)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new BusinessRuleValidationException("Page.TitleRequired", "Page title is mandatory.");
        }

        if (authorId == Guid.Empty)
        {
            throw new BusinessRuleValidationException("Page.AuthorRequired", "Author identifier is mandatory.");
        }

        Id = id.Value == Guid.Empty ? PageId.New() : id;
        Title = title.Trim();
        Slug = NormalizeSlug(string.IsNullOrWhiteSpace(customSlug) ? title : customSlug);
        Content = content?.Trim() ?? string.Empty;
        Summary = summary?.Trim() ?? string.Empty;
        AuthorId = authorId;
        Status = PublishingStatus.Draft;
        Seo = seo ?? new SeoMetadata(Title, Summary, string.Empty);
        CreatedAtUtc = DateTime.UtcNow;
    }

    /// <summary>
    /// Submits the draft page for editorial review.
    /// </summary>
    public void SubmitForReview()
    {
        if (Status != PublishingStatus.Draft)
        {
            throw new InvalidStateTransitionException(
                Status.ToString(),
                nameof(PublishingStatus.Review),
                "Only draft pages can be submitted for review.");
        }

        Status = PublishingStatus.Review;
    }

    /// <summary>
    /// Publishes the page, making it publicly available.
    /// </summary>
    /// <param name="publishedAtUtc">The publication timestamp.</param>
    public void Publish(DateTime publishedAtUtc)
    {
        if (string.IsNullOrWhiteSpace(Content))
        {
            throw new BusinessRuleValidationException("Page.ContentRequired", "Cannot publish a page without content.");
        }

        Status = PublishingStatus.Published;
        PublishedAtUtc = publishedAtUtc;
    }

    /// <summary>
    /// Archives the page, removing it from active public display.
    /// </summary>
    public void Archive()
    {
        Status = PublishingStatus.Archived;
    }

    /// <summary>
    /// Updates page content and metadata.
    /// </summary>
    public void UpdateContent(string title, string content, string summary, SeoMetadata seo)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new BusinessRuleValidationException("Page.TitleRequired", "Page title is mandatory.");
        }

        Title = title.Trim();
        Content = content?.Trim() ?? string.Empty;
        Summary = summary?.Trim() ?? string.Empty;
        Seo = seo;
    }

    /// <summary>
    /// Adds a tag to the page.
    /// </summary>
    public void AddTag(string tagName)
    {
        if (string.IsNullOrWhiteSpace(tagName))
        {
            return;
        }

        var normalized = tagName.Trim().ToLowerInvariant();
        if (_tags.TrueForAll(t => t.Name != normalized))
        {
            _tags.Add(new PageTag(Id, TagId.New(), normalized));
        }
    }

    /// <summary>
    /// Removes a tag from the page.
    /// </summary>
    public void RemoveTag(string tagName)
    {
        var normalized = tagName.Trim().ToLowerInvariant();
        _ = _tags.RemoveAll(t => t.Name == normalized);
    }

    /// <summary>
    /// Converts a title or text into a URL-friendly slug.
    /// </summary>
    public static string NormalizeSlug(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var slug = input.Trim().ToLowerInvariant();
        slug = SlugRegex().Replace(slug, "-");
        slug = HyphenRegex().Replace(slug, "-");
        return slug.Trim('-');
    }

    [GeneratedRegex(@"[^a-z0-9\-_]", RegexOptions.Compiled, matchTimeoutMilliseconds: 1000)]
    private static partial Regex SlugRegex();

    [GeneratedRegex(@"-{2,}", RegexOptions.Compiled, matchTimeoutMilliseconds: 1000)]
    private static partial Regex HyphenRegex();
}
