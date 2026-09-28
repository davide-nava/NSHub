// <copyright file="ExportSecoReportQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.Repositories;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Repositories;

namespace NSHub.Application.Features.TimeTracking.Queries.ExportSecoReport;

/// <summary>
/// MediatR request handler for generating statutory SECO compliance export reports.
/// </summary>
public class ExportSecoReportQueryHandler(
    IEmployeeRepository employeeRepository,
    ITimeEntryRepository timeEntryRepository,
    ISecoComplianceExportService? exportService = null) : IRequestHandler<ExportSecoReportQuery, Result<SecoExportDto>>
{
    /// <inheritdoc/>
    public async Task<Result<SecoExportDto>> Handle(ExportSecoReportQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

        if (employee == null)
        {
            return Result<SecoExportDto>.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        var startUtc = new DateTime(request.Year, request.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        var endUtc = startUtc.AddMonths(1).AddSeconds(-1);

        var entries = await timeEntryRepository.GetEntriesByDateRangeAsync(request.EmployeeId, startUtc.Date, endUtc.Date, cancellationToken);

        byte[] bytes = [];
        string contentType;
        string fileName;

        if (string.Equals(request.Format, "pdf", StringComparison.OrdinalIgnoreCase))
        {
            contentType = "application/pdf";
            fileName = $"SECO_Report_{employee.LastName}_{request.Year}_{request.Month:D2}.pdf";
            if (exportService != null)
            {
                bytes = await exportService.GenerateInspectionSummaryPdfAsync(employee, entries, startUtc, endUtc, request.Language, cancellationToken);
            }
        }
        else
        {
            contentType = "text/csv";
            fileName = $"SECO_Report_{employee.LastName}_{request.Year}_{request.Month:D2}.csv";
            if (exportService != null)
            {
                bytes = await exportService.GenerateCsvReportAsync(employee, entries, startUtc, endUtc, request.Language, cancellationToken);
            }
        }

        return Result<SecoExportDto>.Success(new SecoExportDto(fileName, contentType, bytes));
    }
}
