// <copyright file="CreatePageCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Cms.Commands.CreatePage;

using MediatR;
using NSHub.Application.Cms.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Command to create a new draft CMS page.
/// </summary>
public sealed record CreatePageCommand(
    string Title,
    string? CustomSlug,
    string Content,
    string Summary,
    Guid AuthorId,
    string? MetaTitle = null,
    string? MetaDescription = null,
    string? MetaKeywords = null,
    List<string>? Tags = null) : IRequest<Result<PageDto>>;
