// <copyright file="ExportSecoReportQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Localization;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Resources;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.TimeTracking.Queries.ExportSecoReport;

/// <summary>
/// MediatR request handler for generating statutory SECO compliance export reports.
/// </summary>
public class ExportSecoReportQueryHandler(
    IEmployeeRepository employeeRepository,
    ITimeEntryRepository timeEntryRepository,
    ISecoComplianceExportService exportService,
    IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<ExportSecoReportQuery, Result<SecoExportDto>>
{
    public async Task<Result<SecoExportDto>> Handle(ExportSecoReportQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
        if (employee == null)
        {
            return Result<SecoExportDto>.Failure(Error.NotFound("Employee.NotFound", localizer["EmployeeNotFound"]));
        }

        var startUtc = new DateTime(request.Year, request.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        var endUtc = startUtc.AddMonths(1).AddSeconds(-1);

        var entries = await timeEntryRepository.GetEntriesForEmployeeRangeAsync(
            request.EmployeeId,
            startUtc,
            endUtc,
            cancellationToken);

        byte[] bytes;
        string contentType;
        string fileName;

        if (string.Equals(request.Format, "pdf", StringComparison.OrdinalIgnoreCase))
        {
            bytes = await exportService.GenerateInspectionSummaryPdfAsync(employee, entries, startUtc, endUtc, request.Language, cancellationToken);
            contentType = "application/pdf";
            fileName = $"SECO_Report_{employee.LastName}_{request.Year}_{request.Month:D2}.pdf";
        }
        else
        {
            bytes = await exportService.GenerateCsvReportAsync(employee, entries, startUtc, endUtc, request.Language, cancellationToken);
            contentType = "text/csv";
            fileName = $"SECO_Report_{employee.LastName}_{request.Year}_{request.Month:D2}.csv";
        }

        return Result<SecoExportDto>.Success(new SecoExportDto(fileName, contentType, bytes));
    }
}
