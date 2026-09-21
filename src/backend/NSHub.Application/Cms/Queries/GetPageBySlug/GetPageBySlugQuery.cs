// <copyright file="GetPageBySlugQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Cms.Queries.GetPageBySlug;

using MediatR;
using NSHub.Application.Cms.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Query to retrieve a CMS page by its URL slug.
/// </summary>
public sealed record GetPageBySlugQuery(string Slug) : IRequest<Result<PageDto>>;
