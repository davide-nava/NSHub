// <copyright file="CreateArticleCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Warehouse.Commands.CreateArticle;

using MediatR;
using NSHub.Application.Warehouse.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Warehouse.Entities;
using NSHub.Domain.Warehouse.Repositories;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// Handler for <see cref="CreateArticleCommand"/>.
/// </summary>
public sealed class CreateArticleCommandHandler(
    IInventoryRepository inventoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateArticleCommand, Result<ArticleDto>>
{
    public async Task<Result<ArticleDto>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var existing = await inventoryRepository.GetArticleByCodeAsync(request.Code, cancellationToken);
        if (existing is not null)
        {
            return Result<ArticleDto>.Failure(Error.Conflict("Article.CodeExists", $"Article with code '{request.Code}' already exists."));
        }

        var article = new Article(
            ArticleId.New(),
            request.Code,
            request.Name,
            request.Description,
            request.UnitOfMeasure);

        await inventoryRepository.AddArticleAsync(article, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = new ArticleDto(
            article.Id.Value,
            article.Code,
            article.Name,
            article.Description,
            article.UnitOfMeasure.ToString(),
            article.IsActive);

        return Result<ArticleDto>.Success(dto);
    }
}
