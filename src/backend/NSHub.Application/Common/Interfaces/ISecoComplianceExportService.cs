// <copyright file="ISecoComplianceExportService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NSHub.Domain.Entities;

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Service for generating statutory SECO compliance export reports.
/// </summary>
public interface ISecoComplianceExportService
{
    /// <summary>
    /// Generates a PDF compliance inspection report.
    /// </summary>
    Task<byte[]> GenerateInspectionSummaryPdfAsync(
        Employee employee,
        IEnumerable<TimeEntry> entries,
        DateTime startUtc,
        DateTime endUtc,
        string language,
        CancellationToken cancellationToken);

    /// <summary>
    /// Generates a CSV compliance report.
    /// </summary>
    Task<byte[]> GenerateCsvReportAsync(
        Employee employee,
        IEnumerable<TimeEntry> entries,
        DateTime startUtc,
        DateTime endUtc,
        string language,
        CancellationToken cancellationToken);
}
