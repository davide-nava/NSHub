// <copyright file="CreatePageCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Cms.Commands.CreatePage;

using MediatR;
using NSHub.Application.Cms.DTOs;
using NSHub.Domain.Cms.Entities;
using NSHub.Domain.Cms.Repositories;
using NSHub.Domain.Cms.ValueObjects;
using NSHub.Domain.Common;

/// <summary>
/// Handler for <see cref="CreatePageCommand"/>.
/// </summary>
public sealed class CreatePageCommandHandler(
    ICmsRepository cmsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePageCommand, Result<PageDto>>
{
    public async Task<Result<PageDto>> Handle(CreatePageCommand request, CancellationToken cancellationToken)
    {
        var targetSlug = Page.NormalizeSlug(string.IsNullOrWhiteSpace(request.CustomSlug) ? request.Title : request.CustomSlug);
        if (await cmsRepository.ExistsBySlugAsync(targetSlug, cancellationToken))
        {
            return Result<PageDto>.Failure(Error.Conflict("Page.SlugExists", $"A page with slug '{targetSlug}' already exists."));
        }

        var seo = new SeoMetadata(
            string.IsNullOrWhiteSpace(request.MetaTitle) ? request.Title : request.MetaTitle,
            request.MetaDescription ?? request.Summary,
            request.MetaKeywords ?? string.Empty);

        var page = new Page(
            PageId.New(),
            request.Title,
            request.CustomSlug,
            request.Content,
            request.Summary,
            request.AuthorId,
            seo);

        if (request.Tags != null)
        {
            foreach (var tag in request.Tags)
            {
                page.AddTag(tag);
            }
        }

        await cmsRepository.AddAsync(page, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

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
