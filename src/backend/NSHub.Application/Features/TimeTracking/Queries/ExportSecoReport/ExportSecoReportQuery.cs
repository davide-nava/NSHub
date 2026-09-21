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
public record ExportSecoReportQuery(
    Guid EmployeeId,
    int Year,
    int Month,
    string Format = "csv",
    string Language = "it"
) : IRequest<Result<SecoExportDto>>;
