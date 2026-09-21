// <copyright file="ISecoComplianceExportService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Service abstraction for producing SECO and labor inspection audit reports.
/// </summary>
public interface ISecoComplianceExportService
{
    Task<byte[]> GenerateCsvReportAsync(Employee employee, List<TimeEntry> entries, DateTime startUtc, DateTime endUtc, string languageCode, CancellationToken cancellationToken = default);
    Task<byte[]> GenerateInspectionSummaryPdfAsync(Employee employee, List<TimeEntry> entries, DateTime startUtc, DateTime endUtc, string languageCode, CancellationToken cancellationToken = default);
}
