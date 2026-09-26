// <copyright file="GetEmployeesQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Collections.Generic;
using MediatR;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.DTOs;

namespace NSHub.Application.Features.Employees.Queries.GetEmployees;

/// <summary>
/// Query to retrieve all registered employees and their contractual profiles.
/// </summary>
public record GetEmployeesQuery() : IRequest<Result<List<EmployeeDto>>>;
