// <copyright file="ExportSecoReportQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.TimeTracking.DTOs;

namespace NSHub.Application.Features.TimeTracking.Queries.ExportSecoReport;

/// <summary>
/// MediatR request handler for generating statutory SECO compliance export reports.
/// </summary>
public class ExportSecoReportQueryHandler : IRequestHandler<ExportSecoReportQuery, Result<SecoExportDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly ISecoComplianceExportService? _exportService;

    public ExportSecoReportQueryHandler(IApplicationDbContext context, ISecoComplianceExportService? exportService = null)
    {
        _context = context;
        _exportService = exportService;
    }

    /// <inheritdoc/>
    public async Task<Result<SecoExportDto>> Handle(ExportSecoReportQuery request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);

        if (employee == null)
        {
            return Result<SecoExportDto>.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        var startUtc = new DateTime(request.Year, request.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        var endUtc = startUtc.AddMonths(1).AddSeconds(-1);

        var entries = await _context.TimeEntries
            .AsNoTracking()
            .Where(e => e.EmployeeId == request.EmployeeId && e.WorkDate >= startUtc.Date && e.WorkDate <= endUtc.Date)
            .ToListAsync(cancellationToken);

        byte[] bytes = [];
        string contentType;
        string fileName;

        if (string.Equals(request.Format, "pdf", StringComparison.OrdinalIgnoreCase))
        {
            contentType = "application/pdf";
            fileName = $"SECO_Report_{employee.LastName}_{request.Year}_{request.Month:D2}.pdf";
            if (_exportService != null)
            {
                bytes = await _exportService.GenerateInspectionSummaryPdfAsync(employee, entries, startUtc, endUtc, request.Language, cancellationToken);
            }
        }
        else
        {
            contentType = "text/csv";
            fileName = $"SECO_Report_{employee.LastName}_{request.Year}_{request.Month:D2}.csv";
            if (_exportService != null)
            {
                bytes = await _exportService.GenerateCsvReportAsync(employee, entries, startUtc, endUtc, request.Language, cancellationToken);
            }
        }

        return Result<SecoExportDto>.Success(new SecoExportDto(fileName, contentType, bytes));
    }
}
