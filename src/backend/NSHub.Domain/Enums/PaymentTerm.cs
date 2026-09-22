// <copyright file="PaymentTerm.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace NSHub.Domain.Enums;

/// <summary>
/// Standard contractual payment terms.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentTerm
{
    /// <summary>
    /// Immediate payment upon receipt.
    /// </summary>
    Immediate = 0,

    /// <summary>
    /// Net payment due within 10 days.
    /// </summary>
    Net10 = 10,

    /// <summary>
    /// Net payment due within 30 days.
    /// </summary>
    Net30 = 30,

    /// <summary>
    /// Net payment due within 60 days.
    /// </summary>
    Net60 = 60,

    /// <summary>
    /// Net payment due within 90 days.
    /// </summary>
    Net90 = 90,
}
