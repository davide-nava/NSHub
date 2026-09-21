// <copyright file="DomainEnums.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

using System.Text.Json.Serialization;

/// <summary>
/// Lifecycle status of an employee time tracking punch / record.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TimeEntryStatus
{
    /// <summary>
    /// Open active shift currently in progress.
    /// </summary>
    Open = 1,

    /// <summary>
    /// Completed shift with valid clock in and clock out timestamps.
    /// </summary>
    Completed = 2,

    /// <summary>
    /// Shift requiring manual correction or managerial review.
    /// </summary>
    PendingCorrection = 3,

    /// <summary>
    /// Approved shift with audit trail compliance.
    /// </summary>
    Approved = 4,
}

/// <summary>
/// Supported national official languages.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LanguageCode
{
    /// <summary>
    /// Italian (Switzerland).
    /// </summary>
    It = 1,

    /// <summary>
    /// German (Switzerland).
    /// </summary>
    De = 2,

    /// <summary>
    /// French (Switzerland).
    /// </summary>
    Fr = 3,

    /// <summary>
    /// English.
    /// </summary>
    En = 4,
}

/// <summary>
/// Extension methods for <see cref="LanguageCode"/>.
/// </summary>
public static class LanguageCodeExtensions
{
    /// <summary>
    /// Converts a <see cref="LanguageCode"/> to a standard locale code.
    /// </summary>
    /// <param name="lang">The language code enum value.</param>
    /// <returns>The ISO locale string.</returns>
    public static string ToLocaleCode(this LanguageCode lang) => lang switch
    {
        LanguageCode.It => "it-CH",
        LanguageCode.De => "de-CH",
        LanguageCode.Fr => "fr-CH",
        LanguageCode.En => "en-US",
        _ => "it-CH",
    };

    /// <summary>
    /// Parses a language string into a <see cref="LanguageCode"/>.
    /// </summary>
    /// <param name="code">The language code string.</param>
    /// <returns>The resolved <see cref="LanguageCode"/>.</returns>
    public static LanguageCode FromCode(string? code) => (code?.ToLowerInvariant()) switch
    {
        "de" or "de-ch" or "de-de" => LanguageCode.De,
        "fr" or "fr-ch" or "fr-fr" => LanguageCode.Fr,
        "en" or "en-us" or "en-gb" => LanguageCode.En,
        _ => LanguageCode.It,
    };
}

/// <summary>
/// Labor law statutory violation flags according to Swiss Labor Law (LL/OLL).
/// </summary>
[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ViolationType
{
    /// <summary>
    /// No violations detected.
    /// </summary>
    None = 0,

    /// <summary>
    /// Less than 11 hours consecutive rest period violated (Art. 15a LL).
    /// </summary>
    DailyRestPeriodViolated = 1,

    /// <summary>
    /// Daily amplitude exceeded maximum 14 hours (Art. 10 LL).
    /// </summary>
    DailyAmplitudeExceeded = 2,

    /// <summary>
    /// Mandatory rest break not observed (Art. 15 LL).
    /// </summary>
    InsufficientBreak = 4,

    /// <summary>
    /// Statutory maximum weekly working hours exceeded (Art. 12 LL).
    /// </summary>
    StatutoryOvertime = 8,
}
