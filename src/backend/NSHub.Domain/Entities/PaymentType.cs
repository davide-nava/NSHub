// <copyright file="PaymentType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a payment method lookup entity.
/// </summary>
public class PaymentType : BaseLookup
{
    /// <summary>Gets or sets the days for payment terms.</summary>
    public int? Days { get; set; }
}
