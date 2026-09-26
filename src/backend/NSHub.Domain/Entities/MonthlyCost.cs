// <copyright file="MonthlyCost.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a recurring monthly cost.
/// </summary>
public class MonthlyCost : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the cost description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the recurring amount.
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Gets or sets the date from which the cost becomes effective.
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the date until which the cost remains effective.
    /// </summary>
    public DateTime? EndDate { get; set; }
}
