// <copyright file="GetTicketByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Tickets.Queries.GetTicketById;

using MediatR;
using NSHub.Application.Tickets.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Query to retrieve a support ticket and its comments by identifier.
/// </summary>
/// <param name="Id">The unique identifier of the ticket.</param>
public sealed record GetTicketByIdQuery(Guid Id) : IRequest<Result<TicketDto>>;
