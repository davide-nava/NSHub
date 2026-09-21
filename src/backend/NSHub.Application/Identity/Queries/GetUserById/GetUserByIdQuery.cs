// <copyright file="GetUserByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Identity.Queries.GetUserById;

using MediatR;
using NSHub.Application.Identity.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Query to retrieve a user by their unique identifier.
/// </summary>
public sealed record GetUserByIdQuery(Guid Id) : IRequest<Result<UserDto>>;
