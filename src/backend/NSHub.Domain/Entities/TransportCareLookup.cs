// <copyright file="TransportCareLookup.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a transport care lookup entity.
/// </summary>
public class TransportCareLookup : BaseLookup
{
    /// <summary>Gets or sets notes.</summary>
    public string? Notes { get; set; }
}
