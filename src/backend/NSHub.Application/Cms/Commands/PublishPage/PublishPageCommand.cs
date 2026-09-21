// <copyright file="PublishPageCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Cms.Commands.PublishPage;

using MediatR;
using NSHub.Application.Cms.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Command to publish a CMS page.
/// </summary>
public sealed record PublishPageCommand(Guid PageId) : IRequest<Result<PageDto>>;
