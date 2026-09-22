// <copyright file="TicketStateType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing a ticket state type.
/// </summary>
public class TicketStateType : BaseLookup
{
    /// <summary>
    /// Gets or sets a value indicating whether the ticket state is close.
    /// </summary>
    public bool IsClose { get; set; }
}
