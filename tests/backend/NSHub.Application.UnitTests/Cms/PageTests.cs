// <copyright file="PageTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Cms;

using NSHub.Domain.Cms.Entities;
using NSHub.Domain.Cms.Enums;
using NSHub.Domain.Cms.ValueObjects;
using NSHub.Domain.Exceptions;

public class PageTests
{
    [Theory]
    [InlineData("Hello World!", "hello-world")]
    [InlineData("Swiss Enterprise ERP 2026", "swiss-enterprise-erp-2026")]
    [InlineData("Special & Characters * Here", "special-characters-here")]
    [InlineData("---Multiple---Dashes---", "multiple-dashes")]
    public void NormalizeSlug_ShouldGenerateUrlSafeHyphenatedSlug(string input, string expected)
    {
        // Act
        var result = Page.NormalizeSlug(input);

        // Assert
        _ = result.Should().Be(expected);
    }

    [Fact]
    public void Publish_WithoutContent_ShouldThrowBusinessRuleValidationException()
    {
        // Arrange
        var page = new Page(PageId.New(), "About Us", null, content: "", summary: "About page", Guid.NewGuid());

        // Act
        var act = () => page.Publish(DateTime.UtcNow);

        // Assert
        _ = act.Should().Throw<BusinessRuleValidationException>()
            .WithMessage("*without content*");
    }

    [Fact]
    public void Publish_WithContent_ShouldSetPublishedStatusAndTimestamp()
    {
        // Arrange
        var page = new Page(PageId.New(), "About Us", null, content: "# Welcome to NSHub", summary: "About page", Guid.NewGuid());
        var now = DateTime.UtcNow;

        // Act
        page.Publish(now);

        // Assert
        _ = page.Status.Should().Be(PublishingStatus.Published);
        _ = page.PublishedAtUtc.Should().Be(now);
    }

    [Fact]
    public void SubmitForReview_FromDraft_ShouldTransitionToReview()
    {
        // Arrange
        var page = new Page(PageId.New(), "Terms of Service", null, content: "Terms here", summary: "Legal terms", Guid.NewGuid());

        // Act
        page.SubmitForReview();

        // Assert
        _ = page.Status.Should().Be(PublishingStatus.Review);
    }

    [Fact]
    public void AddTag_ShouldAddUniqueNormalizedTag()
    {
        // Arrange
        var page = new Page(PageId.New(), "Blog Post", null, content: "Post body", summary: "Summary", Guid.NewGuid());

        // Act
        page.AddTag("Technology");
        page.AddTag("technology"); // Duplicate, case-insensitive
        page.AddTag("Cloud");

        // Assert
        _ = page.Tags.Should().HaveCount(2);
        _ = page.Tags.Select(t => t.Name).Should().Contain("technology").And.Contain("cloud");
    }
}
