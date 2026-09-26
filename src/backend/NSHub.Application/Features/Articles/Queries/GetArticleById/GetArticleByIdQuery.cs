using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;

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

public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Result<ArticleDto>>
{
    private readonly IApplicationDbContext _context;

    public GetArticleByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<ArticleDto>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var article = await _context.Articles
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

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
