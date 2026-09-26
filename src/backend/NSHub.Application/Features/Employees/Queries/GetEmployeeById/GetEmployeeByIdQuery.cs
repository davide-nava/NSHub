// <copyright file="GetEmployeeByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using MediatR;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.DTOs;

namespace NSHub.Application.Features.Employees.Queries.GetEmployeeById;

/// <summary>
/// Query to retrieve a single employee by their unique identifier.
/// </summary>
/// <param name="Id">The unique identifier of the employee.</param>
public record GetEmployeeByIdQuery(Guid Id) : IRequest<Result<EmployeeDto>>;
