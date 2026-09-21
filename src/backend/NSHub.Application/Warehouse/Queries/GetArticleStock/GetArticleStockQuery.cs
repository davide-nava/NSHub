// <copyright file="GetArticleStockQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Warehouse.Queries.GetArticleStock;

using MediatR;
using NSHub.Application.Warehouse.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Query to retrieve stock balances for a given article across all warehouse locations.
/// </summary>
public sealed record GetArticleStockQuery(Guid ArticleId) : IRequest<Result<List<ArticleStockDto>>>;
