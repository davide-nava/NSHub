// <copyright file="TimeTrackingController.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NSHub.Application.Features.TimeTracking.Commands.ClockIn;
using NSHub.Application.Features.TimeTracking.Commands.ClockOut;
using NSHub.Application.Features.TimeTracking.Commands.CorrectTimeEntry;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Queries.ExportSecoReport;
using NSHub.Application.Features.TimeTracking.Queries.GetCurrentStatus;
using NSHub.Application.Features.TimeTracking.Queries.GetTimesheet;

namespace NSHub.Api.Controllers;

/// <summary>
/// Controller handling employee time tracking operations compliant with Swiss Labor Law (LL / OLL 1 / OLL 3).
/// </summary>
[Route("api/v1/timetracking")]
public class TimeTrackingController : ApiControllerBase
{
    /// <summary>
    /// Records a clock-in event with optional punctual GPS coordinate capture (Art. 26 OLL 3).
    /// </summary>
    /// <param name="command">The clock-in command details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created time entry record.</returns>
    [HttpPost("clock-in")]
    [ProducesResponseType(typeof(TimeEntryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> ClockIn([FromBody] ClockInCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// Records a clock-out event, breaks taken, and evaluates statutory compliance violations (Art. 10, 15, 15a LL).
    /// </summary>
    /// <param name="command">The clock-out command details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The completed time entry record.</returns>
    [HttpPost("clock-out")]
    [ProducesResponseType(typeof(TimeEntryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ClockOut([FromBody] ClockOutCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// Retroactively corrects a time entry record with a mandatory statutory reason (Art. 73 OLL 1).
    /// </summary>
    /// <param name="command">The correction command details.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The corrected time entry record.</returns>
    [HttpPost("correct")]
    [ProducesResponseType(typeof(TimeEntryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Correct([FromBody] CorrectTimeEntryCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// Retrieves the current attendance status of an employee in real time.
    /// </summary>
    /// <param name="employeeId">The employee identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The current attendance status.</returns>
    [HttpGet("status/{employeeId:guid}")]
    [ProducesResponseType(typeof(CurrentTimeStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetStatus(Guid employeeId, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCurrentStatusQuery(employeeId), cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// Retrieves the attendance timesheet for a date range, with statutory worktime breakdown and detected anomalies.
    /// </summary>
    /// <param name="employeeId">The employee identifier.</param>
    /// <param name="startDateUtc">Start of date range in UTC.</param>
    /// <param name="endDateUtc">End of date range in UTC.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The detailed timesheet for the requested period.</returns>
    [HttpGet("timesheet")]
    [ProducesResponseType(typeof(TimesheetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTimesheet(
        [FromQuery] Guid employeeId,
        [FromQuery] DateTime startDateUtc,
        [FromQuery] DateTime endDateUtc,
        CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetTimesheetQuery(employeeId, startDateUtc, endDateUtc), cancellationToken);
        return HandleResult(result);
    }

    /// <summary>
    /// Exports statutory SECO labor compliance audit report in CSV or PDF format (Art. 73 OLL 1).
    /// </summary>
    /// <param name="employeeId">The employee identifier.</param>
    /// <param name="year">Calendar year of the inspection period.</param>
    /// <param name="month">Calendar month of the inspection period.</param>
    /// <param name="format">Export format ("csv" or "pdf").</param>
    /// <param name="language">Report language ("it", "de", "fr", "en").</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The binary export file download.</returns>
    [HttpGet("export/seco")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ExportSeco(
        [FromQuery] Guid employeeId,
        [FromQuery] int year,
        [FromQuery] int month,
        [FromQuery] string format = "csv",
        [FromQuery] string language = "it",
        CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new ExportSecoReportQuery(employeeId, year, month, format, language), cancellationToken);
        if (result.IsFailure)
        {
            return HandleResult(result);
        }

        return File(result.Value.FileBytes, result.Value.ContentType, result.Value.FileName);
    }
}
