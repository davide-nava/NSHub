// <copyright file="GetArticleByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.Articles.Queries.GetArticleById;

public record ArticleDto(
    Guid Id,
    string Number,
    string Description,
    decimal Quantity,
    decimal? PurchasePrice,
    decimal? SalePrice,
    bool IsActive);

public record GetArticleByIdQuery(Guid Id) : IRequest<Result<ArticleDto>>;

public class GetArticleByIdQueryHandler(IRepository<Article> articleRepository) : IRequestHandler<GetArticleByIdQuery, Result<ArticleDto>>
{
    public async Task<Result<ArticleDto>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var article = await articleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (article == null)
        {
            return Result.Failure<ArticleDto>($"Article with Id {request.Id} was not found.");
        }

        var dto = new ArticleDto(
            article.Id,
            article.Number,
            article.Description,
            article.Quantity,
            article.PurchasePrice,
            article.SalePrice,
            article.IsActive);

        return Result.Success(dto);
    }
}
