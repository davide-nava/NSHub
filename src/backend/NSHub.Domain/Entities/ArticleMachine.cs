// <copyright file="ArticleMachine.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the association between an article and a machine.
/// </summary>
public class ArticleMachine : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the article identifier.
    /// </summary>
    public Guid ArticleId { get; set; }

    /// <summary>
    /// Gets or sets the article group identifier.
    /// </summary>
    public Guid? ArticleGroupId { get; set; }

    /// <summary>
    /// Gets or sets the machine identifier.
    /// </summary>
    public Guid? MachineId { get; set; }

    /// <summary>
    /// Gets or sets the quantity associated with the machine.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Gets or sets the additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; set; }

    /// <summary>
    /// Gets or sets the associated article group.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleGroup? ArticleGroup { get; set; }

    /// <summary>
    /// Gets or sets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; set; }
}
