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
    /// Gets or sets the intervention identifier.
    /// </summary>
    public Guid InterventionId { get; set; }

    /// <summary>
    /// Gets or sets the attachment source path or URL.
    /// </summary>
    public string Src { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the attachment title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the associated intervention.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Intervention? Intervention { get; set; }
}
