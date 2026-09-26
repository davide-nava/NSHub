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
    /// Gets or sets the intervention notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the intervention identifier.
    /// </summary>
    public Guid InterventionId { get; set; }

    /// <summary>
    /// Gets or sets the intervention end date.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the intervention start date.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the associated intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Intervention? Intervention { get; set; }

    /// <summary>
    /// Gets or sets the associated user.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; set; }
}
