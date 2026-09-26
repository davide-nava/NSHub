// <copyright file="CreateArticleCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using NSHub.Application.Common.Interfaces;
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
        RuleFor(v => v.Number)
            .NotEmpty().WithMessage("Article number is required.")
            .MaximumLength(255).WithMessage("Article number must not exceed 255 characters.");

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(512).WithMessage("Description must not exceed 512 characters.");

        RuleFor(v => v.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity must be non-negative.");

        RuleFor(v => v.UnitOfMeasureId)
            .NotEmpty().WithMessage("Unit of measure ID is required.");
    }
}

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;

    public CreateArticleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Guid>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = Article.Create(
            request.Number,
            request.Description,
            request.Quantity,
            request.Image,
            request.UnitOfMeasureId,
            request.PurchasePrice,
            request.SalePrice,
            request.SupplierId,
            request.WarehouseId);

        _context.Articles.Add(article);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(article.Id);
    }
}
