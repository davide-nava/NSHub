// <copyright file="Oll1Regime.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Enums;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the OLL 1 / ArGV 1 recording regime applicable to an employee under Swiss labor law.
/// </summary>
public class Oll1Regime : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the identifier of the employee to whom this OLL 1 / ArGV 1 recording regime applies.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the type of OLL 1 / ArGV 1 recording regime applicable to the employee.
    /// </summary>
    public Oll1RegimeType RegimeType { get; set; }

    /// <summary>
    /// Gets or sets the start date of the OLL 1 / ArGV 1 recording regime in UTC.
    /// </summary>
    public DateTime ValidFromUtc { get; set; }

    /// <summary>
    /// Gets or sets the end date of the OLL 1 / ArGV 1 recording regime in UTC.
    /// </summary>
    public DateTime? ValidToUtc { get; set; }

    /// <summary>
    /// Gets or sets the reference to the collective agreement.
    /// </summary>
    public string? CollectiveAgreementRef { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the individual agreement has been signed by the employee.
    /// </summary>
    public bool IndividualAgreementSigned { get; set; }

    // public override string ToString() => RegimeType switch
    // {
    //     Oll1RegimeType.StandardArt73 => "Standard (Art. 73 OLL 1 / ArGV 1)",
    //     Oll1RegimeType.SimplifiedArt73a => "Semplificata (Art. 73a OLL 1 / ArGV 1)",
    //     Oll1RegimeType.OptOutArt73b => "Rinuncia (Art. 73b OLL 1 / ArGV 1)",
    //     _ => "Non specificato"
    // };
}
