// <copyright file="TicketPriority.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing a ticket priority.
/// </summary>
internal class TicketPriority : BaseLookup
{
    /// <summary>
    /// Gets or sets the priority.
    /// </summary>
    public int Priority { get; set; }
}
