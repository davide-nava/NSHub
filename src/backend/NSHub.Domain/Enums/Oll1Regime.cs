// <copyright file="Oll1Regime.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Regimi di registrazione della durata del lavoro previsti dall'Ordinanza 1 concernente la legge sul lavoro (OLL 1).
/// </summary>
public enum Oll1Regime
{
    /// <summary>
    /// Registrazione ordinaria completa di inizio, pause e fine del lavoro (Art. 73 OLL 1).
    /// </summary>
    STANDARD_RECORD = 1,

    /// <summary>
    /// Registrazione semplificata della sola durata complessiva del lavoro giornaliero (Art. 73a OLL 1).
    /// Applicabile a collaboratori con autonomia nella fissazione del proprio orario di lavoro.
    /// </summary>
    SIMPLIFIED_RECORD = 2,

    /// <summary>
    /// Rinuncia alla registrazione della durata del lavoro (Art. 73b OLL 1).
    /// Riservata a quadri dirigenti e specialisti con retribuzione annua lorda > CHF 120'000.
    /// </summary>
    OPT_OUT = 3,
}
