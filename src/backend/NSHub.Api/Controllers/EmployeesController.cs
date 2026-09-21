// <copyright file="EmployeesController.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NSHub.Application.Features.Employees.Commands.UpdateEmployeeLanguage;
using NSHub.Application.Features.Employees.Commands.UpdateEmployeeRegime;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Application.Features.Employees.Queries.GetEmployeeById;
using NSHub.Application.Features.Employees.Queries.GetEmployees;
using NSHub.Domain.Enums;

namespace NSHub.Api.Controllers;

/// <summary>
/// Controller handling employee management endpoints, including profile retrieval, OLL 1 working regime, and language preferences.
/// </summary>
[Route("api/v1/employees")]
public class EmployeesController : ApiControllerBase
{
    /// <summary>
    /// Retrieves all active employees registered in the system.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of employee data transfer objects.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<EmployeeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEmployees(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetEmployeesQuery(), cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// Retrieves a single employee by their unique identifier.
    /// </summary>
    /// <param name="id">The employee identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The employee data transfer object if found; otherwise 404 NotFound.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEmployeeById(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetEmployeeByIdQuery(id), cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// Updates the applicable OLL 1 working time regulation regime for an employee.
    /// </summary>
    /// <param name="id">The employee identifier.</param>
    /// <param name="regime">The new OLL 1 regime to assign.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Ok if update succeeded; otherwise an error problem details.</returns>
    [HttpPut("{id:guid}/regime")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateRegime(Guid id, [FromBody] Oll1Regime regime, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new UpdateEmployeeRegimeCommand(id, regime), cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// Updates the preferred UI and communication language for an employee.
    /// </summary>
    /// <param name="id">The employee identifier.</param>
    /// <param name="language">The new preferred language code.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Ok if update succeeded; otherwise an error problem details.</returns>
    [HttpPut("{id:guid}/language")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateLanguage(Guid id, [FromBody] LanguageCode language, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new UpdateEmployeeLanguageCommand(id, language), cancellationToken);
        return HandleResult(result);
    }
}
