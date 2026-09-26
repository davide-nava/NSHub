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
    /// Gets the employee identifier.
    /// </summary>
    public Guid EmployeeId { get; protected set; }

    /// <summary>
    /// Gets the agreement type identifier.
    /// </summary>
    public Guid AgreementTypeId { get; protected set; }

    /// <summary>
    /// Gets the date from which the agreement is valid.
    /// </summary>
    public DateTime ValidFrom { get; protected set; }

    /// <summary>
    /// Gets the date until which the agreement is valid.
    /// </summary>
    public DateTime? ValidTo { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the agreement has been revoked.
    /// </summary>
    public bool IsRevoked { get; protected set; }

    /// <summary>
    /// Gets the reference to the associated document.
    /// </summary>
    public string? DocumentReference { get; protected set; }

    /// <summary>
    /// Gets the agreement type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual AgreementType? AgreementType { get; protected set; }

    /// <summary>
    /// Gets the employee associated with the agreement.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Employee? Employee { get; protected set; }
}
