// <copyright file="PaymentTerm.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Invoicing.Enums;

/// <summary>
/// Standard contractual payment terms.
/// </summary>
public enum PaymentTerm
{
    /// <summary>
    /// Immediate payment upon receipt.
    /// </summary>
    IMMEDIATE = 0,

    /// <summary>
    /// Net payment due within 10 days.
    /// </summary>
    NET10 = 10,

    /// <summary>
    /// Net payment due within 30 days.
    /// </summary>
    NET30 = 30,

    /// <summary>
    /// Net payment due within 60 days.
    /// </summary>
    NET60 = 60,

    /// <summary>
    /// Net payment due within 90 days.
    /// </summary>
    NET90 = 90
}
