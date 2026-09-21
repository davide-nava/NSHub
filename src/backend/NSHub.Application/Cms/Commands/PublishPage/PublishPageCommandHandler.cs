// <copyright file="PublishPageCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Cms.Commands.PublishPage;

using MediatR;
using NSHub.Application.Cms.DTOs;
using NSHub.Domain.Cms.Repositories;
using NSHub.Domain.Cms.ValueObjects;
using NSHub.Domain.Common;
using NSHub.Domain.Exceptions;

/// <summary>
/// Handler for <see cref="PublishPageCommand"/>.
/// </summary>
public sealed class PublishPageCommandHandler(
    ICmsRepository cmsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<PublishPageCommand, Result<PageDto>>
{
    public async Task<Result<PageDto>> Handle(PublishPageCommand request, CancellationToken cancellationToken)
    {
        var page = await cmsRepository.GetByIdAsync(new PageId(request.PageId), cancellationToken);
        if (page is null)
        {
            return Result<PageDto>.Failure(Error.NotFound("Page.NotFound", $"Page with ID '{request.PageId}' was not found."));
        }

        try
        {
            page.Publish(DateTime.UtcNow);
            cmsRepository.Update(page);
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
        catch (DomainException ex)
        {
            return Result<PageDto>.Failure(Error.Validation("Page.PublishFailed", ex.Message));
        }
    }
}
