// <copyright file="InterventionUser.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the association between an intervention and a user.
/// </summary>
public class InterventionUser : AuditableTenantEntity
{
    /// <summary>
    /// Gets the intervention notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    public Guid UserId { get; protected set; }

    /// <summary>
    /// Gets the intervention identifier.
    /// </summary>
    public Guid InterventionId { get; protected set; }

    /// <summary>
    /// Gets the intervention end date.
    /// </summary>
    public DateTime EndDate { get; protected set; }

    /// <summary>
    /// Gets the intervention start date.
    /// </summary>
    public DateTime StartDate { get; protected set; }

    /// <summary>
    /// Gets the associated intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Intervention? Intervention { get; protected set; }

    /// <summary>
    /// Gets the associated user.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; protected set; }
}
