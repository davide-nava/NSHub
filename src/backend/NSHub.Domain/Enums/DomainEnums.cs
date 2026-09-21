// <copyright file="DomainEnums.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

public enum TimeEntryStatus
{
    OPEN = 1,
    COMPLETED = 2,
    PENDING_CORRECTION = 3,
    APPROVED = 4,
}

public enum LanguageCode
{
    IT = 1,
    DE = 2,
    FR = 3,
    EN = 4,
}

public static class LanguageCodeExtensions
{
    public static string ToLocaleCode(this LanguageCode lang) => lang switch
    {
        LanguageCode.IT => "it-CH",
        LanguageCode.DE => "de-CH",
        LanguageCode.FR => "fr-CH",
        LanguageCode.EN => "en-US",
        _ => "it-CH",
    };

    public static LanguageCode FromCode(string? code) => (code?.ToLowerInvariant()) switch
    {
        "de" or "de-ch" or "de-de" => LanguageCode.DE,
        "fr" or "fr-ch" or "fr-fr" => LanguageCode.FR,
        "en" or "en-us" or "en-gb" => LanguageCode.EN,
        _ => LanguageCode.IT,
    };
}

[Flags]
public enum ViolationType
{
    NONE = 0,
    DAILY_REST_PERIOD_VIOLATED = 1, // < 11h riposo consecutivo (Art. 15a LL)
    DAILY_AMPLITUDE_EXCEEDED = 2,  // > 14h ampiezza massima (Art. 10 LL)
    INSUFFICIENT_BREAK = 4,       // Pausa obbligatoria non rispettata (Art. 15 LL)
    STATUTORY_OVERTIME = 8,        // Superamento ore massime di legge Überzeit (Art. 12 LL)
}
