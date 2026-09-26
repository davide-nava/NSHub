// <copyright file="TimeTrackingAgreement.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an employee agreement used for time tracking purposes.
/// </summary>
public class TimeTrackingAgreement : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the employee identifier.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the agreement type identifier.
    /// </summary>
    public Guid AgreementTypeId { get; set; }

    /// <summary>
    /// Gets or sets the date from which the agreement is valid.
    /// </summary>
    public DateTime ValidFrom { get; set; }

    /// <summary>
    /// Gets or sets the date until which the agreement is valid.
    /// </summary>
    public DateTime? ValidTo { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the agreement has been revoked.
    /// </summary>
    public bool IsRevoked { get; set; }

    /// <summary>
    /// Gets or sets the reference to the associated document.
    /// </summary>
    public string? DocumentReference { get; set; }

    /// <summary>
    /// Gets or sets the agreement type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual AgreementType? AgreementType { get; set; }

    /// <summary>
    /// Gets or sets the employee associated with the agreement.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Employee? Employee { get; set; }
}
