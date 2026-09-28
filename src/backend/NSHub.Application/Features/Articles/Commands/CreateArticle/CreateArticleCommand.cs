// <copyright file="CreateArticleCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.Articles.Commands.CreateArticle;

public record CreateArticleCommand(
    string Number,
    string Description,
    decimal Quantity,
    string Image,
    Guid UnitOfMeasureId,
    decimal? PurchasePrice = null,
    decimal? SalePrice = null,
    Guid? SupplierId = null,
    Guid? WarehouseId = null) : IRequest<Result<Guid>>;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        _ = RuleFor(v => v.Number)
            .NotEmpty().WithMessage("Article number is required.")
            .MaximumLength(255).WithMessage("Article number must not exceed 255 characters.");

        _ = RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(512).WithMessage("Description must not exceed 512 characters.");

        _ = RuleFor(v => v.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity must be non-negative.");

        _ = RuleFor(v => v.UnitOfMeasureId)
            .NotEmpty().WithMessage("Unit of measure ID is required.");
    }
}

public class CreateArticleCommandHandler(IRepository<Article> articleRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateArticleCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = new Article
        {
            Number = request.Number,
            Description = request.Description,
            Quantity = request.Quantity,
            Image = request.Image,
            UnitOfMeasureId = request.UnitOfMeasureId,
            PurchasePrice = request.PurchasePrice,
            SalePrice = request.SalePrice,
            SupplierId = request.SupplierId,
            WarehouseId = request.WarehouseId,
            IsActive = true,
        };

        _ = await articleRepository.AddAsync(article, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(article.Id);
    }
}
