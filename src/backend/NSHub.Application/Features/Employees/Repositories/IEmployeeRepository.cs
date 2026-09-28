// <copyright file="IEmployeeRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Features.Employees.Repositories;

/// <summary>
/// Employee repository contract alias for the Employees feature slice.
/// </summary>
public interface IEmployeeRepository : NSHub.Application.Features.Organization.Repositories.IEmployeeRepository
{
}
