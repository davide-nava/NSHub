// <copyright file="GetPageBySlugQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Cms.Queries.GetPageBySlug;

using MediatR;
using NSHub.Application.Cms.DTOs;
using NSHub.Domain.Cms.Entities;
using NSHub.Domain.Cms.Repositories;
using NSHub.Domain.Common;

/// <summary>
/// Handler for <see cref="GetPageBySlugQuery"/>.
/// </summary>
public sealed class GetPageBySlugQueryHandler(ICmsRepository cmsRepository) : IRequestHandler<GetPageBySlugQuery, Result<PageDto>>
{
    public async Task<Result<PageDto>> Handle(GetPageBySlugQuery request, CancellationToken cancellationToken)
    {
        var normalizedSlug = Page.NormalizeSlug(request.Slug);
        var page = await cmsRepository.GetBySlugAsync(normalizedSlug, cancellationToken);
        if (page is null)
        {
            return Result<PageDto>.Failure(Error.NotFound("Page.NotFound", $"Page with slug '{request.Slug}' was not found."));
        }

        var dto = new PageDto(
            page.Id.Value,
            page.Title,
            page.Slug,
            page.Content,
            page.Summary,
            page.AuthorId,
            page.Status.ToString(),
            page.Seo.MetaTitle,
            page.Seo.MetaDescription,
            page.Seo.MetaKeywords,
            page.Seo.CanonicalUrl,
            page.PublishedAtUtc,
            page.CreatedAtUtc,
            page.Tags.Select(t => t.Name).ToList());

        return Result<PageDto>.Success(dto);
    }
}
