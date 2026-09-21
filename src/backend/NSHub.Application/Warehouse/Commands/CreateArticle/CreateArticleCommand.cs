// <copyright file="CreateArticleCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Warehouse.Commands.CreateArticle;

using MediatR;
using NSHub.Application.Warehouse.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Warehouse.Enums;

/// <summary>
/// Command to create a new inventory article.
/// </summary>
public sealed record CreateArticleCommand(
    string Code,
    string Name,
    string Description,
    ArticleUnitOfMeasure UnitOfMeasure) : IRequest<Result<ArticleDto>>;
