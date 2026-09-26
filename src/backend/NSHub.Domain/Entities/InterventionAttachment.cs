// <copyright file="InterventionAttachment.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an attachment associated with an intervention.
/// </summary>
public class InterventionAttachment : AuditableTenantEntity
{
    /// <summary>
    /// Gets the intervention identifier.
    /// </summary>
    public Guid InterventionId { get; protected set; }

    /// <summary>
    /// Gets the attachment source path or URL.
    /// </summary>
    public string Src { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the attachment title.
    /// </summary>
    public string Title { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the associated intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Intervention? Intervention { get; protected set; }
}
