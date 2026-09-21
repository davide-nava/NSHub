// <copyright file="GetEmployeeByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.Employees.Queries.GetEmployeeById;

/// <summary>
/// Query to retrieve a single employee by their unique identifier.
/// </summary>
public record GetEmployeeByIdQuery(Guid Id) : IRequest<Result<EmployeeDto>>;
