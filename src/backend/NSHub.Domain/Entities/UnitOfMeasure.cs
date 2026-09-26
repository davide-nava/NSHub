// <copyright file="UnitOfMeasure.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a unit of measure entity in the domain model.
/// </summary>
public class UnitOfMeasure : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the description of the unit of measure.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code of the unit of measure.
    /// </summary>
    public string Code { get; set; } = string.Empty;
}
