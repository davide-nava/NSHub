// <copyright file="SecoComplianceExportService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Globalization;
using System.Text;
using NSHub.Application.Common.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Domain.Enums;
using NSHub.Domain.Services;

namespace NSHub.Infrastructure.Services;

/// <summary>
/// Servizio di esportazione report per gli ispettorati cantonali del lavoro e SECO
/// conforme all'Art. 73 OLL 1 (obbligo di registrazione delle ore di lavoro).
/// </summary>
public class SecoComplianceExportService(IDateTimeProvider dateTimeProvider) : ISecoComplianceExportService
{
    private readonly SwissWorktimePolicy policy = new SwissWorktimePolicy();

    public Task<byte[]> GenerateCsvReportAsync(
        Employee employee,
        List<TimeEntry> entries,
        DateTime startUtc,
        DateTime endUtc,
        string languageCode,
        CancellationToken cancellationToken = default)
    {
        var sb = new StringBuilder();

        // Intestazione report SECO
        var lang = languageCode.ToLowerInvariant();
        var headers = GetHeaders(lang);

        _ = sb.AppendLine($"# SECO / Cantonal Labor Inspectorate Compliance Report - Art. 73 OLL 1");
        _ = sb.AppendLine($"# Employee: {employee.LastName} {employee.FirstName} ({employee.Email})");
        _ = sb.AppendLine($"# Department: {employee.Department}");
        _ = sb.AppendLine($"# Contractual Weekly Hours: {employee.ContractualWeeklyHours}h | Statutory Ceiling: {(int)employee.StatutoryWeeklyLimit}h (Art. 9 LL)");
        _ = sb.AppendLine($"# OLL 1 Regime: {employee.Oll1Regime}");
        _ = sb.AppendLine($"# Period: {startUtc:yyyy-MM-dd} to {endUtc:yyyy-MM-dd}");
        _ = sb.AppendLine();

        _ = sb.AppendLine(string.Join(";", headers));

        double totalNet = 0;
        double totalNight = 0;
        double totalSunday = 0;
        int totalBreaks = 0;

        foreach (var entry in entries.OrderBy(e => e.ClockInUtc))
        {
            var clockInSwiss = dateTimeProvider.ToSwissTime(entry.ClockInUtc);
            var clockOutSwiss = entry.ClockOutUtc.HasValue ? dateTimeProvider.ToSwissTime(entry.ClockOutUtc.Value) : (DateTime?)null;

            var endUtcVal = entry.ClockOutUtc ?? dateTimeProvider.UtcNow;
            var durationMinutes = (endUtcVal - entry.ClockInUtc).TotalMinutes;
            var netMinutes = Math.Max(0, durationMinutes - entry.BreakDurationMinutes);
            var netHours = Math.Round(netMinutes / 60.0, 2);

            var nightHours = policy.CalculateNightHours(entry.ClockInUtc, endUtcVal);
            var sundayHours = policy.CalculateSundayHours(entry.ClockInUtc, endUtcVal);

            totalNet += netHours;
            totalNight += nightHours;
            totalSunday += sundayHours;
            totalBreaks += entry.BreakDurationMinutes;

            var violationsList = new List<string>();
            if (entry.DailyRestPeriodViolated)
            {
                violationsList.Add("Rest <11h (Art. 15a LL)");
            }

            if (entry.DailyAmplitudeExceeded)
            {
                violationsList.Add("Amplitude >14h (Art. 10 LL)");
            }

            if (entry.Violations.HasFlag(ViolationType.INSUFFICIENT_BREAK))
            {
                violationsList.Add("Break insufficient (Art. 15 LL)");
            }

            var violationsStr = violationsList.Count > 0 ? string.Join("|", violationsList) : "OK";

            var line = string.Join(";",
                clockInSwiss.ToString("yyyy-MM-dd"),
                clockInSwiss.ToString("HH:mm:ss"),
                clockOutSwiss?.ToString("HH:mm:ss") ?? "IN PROGRESS",
                entry.BreakDurationMinutes.ToString(),
                netHours.ToString("F2", CultureInfo.InvariantCulture),
                nightHours.ToString("F2", CultureInfo.InvariantCulture),
                sundayHours.ToString("F2", CultureInfo.InvariantCulture),
                violationsStr,
                entry.AuditTrail.Count.ToString(),
                entry.Notes?.Replace(";", " ") ?? string.Empty);

            _ = sb.AppendLine(line);
        }

        _ = sb.AppendLine();
        _ = sb.AppendLine($"# TOTALS;Net Hours: {totalNet:F2};Breaks (min): {totalBreaks};Night Hours: {totalNight:F2};Sunday Hours: {totalSunday:F2}");

        return Task.FromResult(Encoding.UTF8.GetBytes(sb.ToString()));
    }

    public Task<byte[]> GenerateInspectionSummaryPdfAsync(
        Employee employee,
        List<TimeEntry> entries,
        DateTime startUtc,
        DateTime endUtc,
        string languageCode,
        CancellationToken cancellationToken = default)
    {
        // Genera un documento testuale formattato conforme ai requisiti dell'ispettorato SECO
        var sb = new StringBuilder();
        _ = sb.AppendLine("================================================================================");
        _ = sb.AppendLine("   SCHEDA DI REGISTRAZIONE DELL'ORARIO DI LAVORO (SECO - Art. 73 OLL 1)");
        _ = sb.AppendLine("   RAPPORT DE CONTRÔLE DU TEMPS DE TRAVAIL / ARBEITSZEITERFASSUNG");
        _ = sb.AppendLine("================================================================================");
        _ = sb.AppendLine($"Collaboratore / Employé / Arbeitnehmer : {employee.LastName} {employee.FirstName}");
        _ = sb.AppendLine($"Email: {employee.Email} | Reparto: {employee.Department}");
        _ = sb.AppendLine($"Orario contrattuale: {employee.ContractualWeeklyHours}h | Limite max LL art. 9: {(int)employee.StatutoryWeeklyLimit}h");
        _ = sb.AppendLine($"Regime OLL 1 applicato: {employee.Oll1Regime}");
        _ = sb.AppendLine($"Periodo di rilevamento: {startUtc:dd.MM.yyyy} - {endUtc:dd.MM.yyyy}");
        _ = sb.AppendLine("--------------------------------------------------------------------------------");
        _ = sb.AppendLine(string.Format("{0,-12} | {1,-8} | {2,-8} | {3,-6} | {4,-8} | {5,-10} | {6,-15}",
            "Data", "Inizio", "Fine", "Pausa", "Netto (h)", "Notturno", "Stato Legale"));
        _ = sb.AppendLine("--------------------------------------------------------------------------------");

        double totalNet = 0;
        int violationsCount = 0;

        foreach (var e in entries.OrderBy(x => x.ClockInUtc))
        {
            var inSwiss = dateTimeProvider.ToSwissTime(e.ClockInUtc);
            var outSwiss = e.ClockOutUtc.HasValue ? dateTimeProvider.ToSwissTime(e.ClockOutUtc.Value) : (DateTime?)null;
            var endUtcVal = e.ClockOutUtc ?? dateTimeProvider.UtcNow;
            var netHours = Math.Max(0, (endUtcVal - e.ClockInUtc).TotalHours - (e.BreakDurationMinutes / 60.0));
            var night = policy.CalculateNightHours(e.ClockInUtc, endUtcVal);

            var status = "CONFORME";
            if (e.DailyRestPeriodViolated || e.DailyAmplitudeExceeded)
            {
                status = "NON CONFORME";
                violationsCount++;
            }

            totalNet += netHours;

            _ = sb.AppendLine(string.Format("{0,-12} | {1,-8} | {2,-8} | {3,-6} | {4,-8:F2} | {5,-10:F2} | {6,-15}",
                inSwiss.ToString("dd.MM.yyyy"),
                inSwiss.ToString("HH:mm"),
                outSwiss?.ToString("HH:mm") ?? "--:--",
                $"{e.BreakDurationMinutes}m",
                netHours,
                night,
                status));
        }

        _ = sb.AppendLine("================================================================================");
        _ = sb.AppendLine($"Totale ore lavorate nel periodo: {totalNet:F2} ore");
        _ = sb.AppendLine($"Totale anomalie legali rilevate: {violationsCount}");
        _ = sb.AppendLine("================================================================================");
        _ = sb.AppendLine("Dichiarazione di conformità SECO:");
        _ = sb.AppendLine("Il presente documento attesta la registrazione delle presenze ai sensi degli artt. 46 LL");
        _ = sb.AppendLine("e 73 dell'Ordinanza 1 concernente la legge sul lavoro. I dati sono conservati per 5 anni.");
        _ = sb.AppendLine();
        _ = sb.AppendLine("Firma del Datore di Lavoro: _______________________    Data: _______________");
        _ = sb.AppendLine("Firma del Collaboratore:    _______________________    Data: _______________");

        return Task.FromResult(Encoding.UTF8.GetBytes(sb.ToString()));
    }

    private static string[] GetHeaders(string lang) => lang switch
    {
        "de" => ["Datum", "Beginn", "Ende", "Pause_Min", "Netto_Stunden", "Nachtarbeit_Stunden", "Sonntagsarbeit_Stunden", "Gesetzesverstoss", "Korrekturen", "Notizen"],
        "fr" => ["Date", "Debut", "Fin", "Pause_Min", "Heures_Nettes", "Heures_Nuit", "Heures_Dimanche", "Infractions_Legales", "Corrections", "Notes"],
        "en" => ["Date", "Start_Time", "End_Time", "Break_Min", "Net_Hours", "Night_Hours", "Sunday_Hours", "Violations", "Corrections", "Notes"],
        _ => ["Data", "Ora_Inizio", "Ora_Fine", "Pausa_Min", "Ore_Nette", "Ore_Notturne", "Ore_Domenicali", "Anomalie_Legge", "Rettifiche_Audit", "Note"],
    };
}
