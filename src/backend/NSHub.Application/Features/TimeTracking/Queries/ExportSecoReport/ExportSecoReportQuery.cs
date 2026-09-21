// <copyright file="ExportSecoReportQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.TimeTracking.Queries.ExportSecoReport;

/// <summary>
/// Query to generate SECO and Cantonal labor inspection compliance export files (CSV/PDF).
/// </summary>
/// <param name="EmployeeId">The unique identifier of the employee.</param>
/// <param name="Year">The calendar year.</param>
/// <param name="Month">The calendar month (1-12).</param>
/// <param name="Format">The export format (e.g., "csv" or "pdf").</param>
/// <param name="Language">The language code for localized report generation.</param>
public record ExportSecoReportQuery(
    Guid EmployeeId,
    int Year,
    int Month,
    string Format = "csv",
    string Language = "it"
) : IRequest<Result<SecoExportDto>>;
