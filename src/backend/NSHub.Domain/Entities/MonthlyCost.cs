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
    /// Gets the cost description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the recurring amount.
    /// </summary>
    public decimal? Amount { get; protected set; }

    /// <summary>
    /// Gets the date from which the cost becomes effective.
    /// </summary>
    public DateTime? StartDate { get; protected set; }

    /// <summary>
    /// Gets the date until which the cost remains effective.
    /// </summary>
    public DateTime? EndDate { get; protected set; }
}
