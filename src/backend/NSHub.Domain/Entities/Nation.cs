// <copyright file="Nation.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Aggregate root representing an enterprise user identity, authentication invariants, and roles.
/// </summary>
public class Nation : BaseLookup
{
    /// <summary>
    /// Gets or sets the VAT value.
    /// </summary>
    public decimal Value { get; set; }
}
