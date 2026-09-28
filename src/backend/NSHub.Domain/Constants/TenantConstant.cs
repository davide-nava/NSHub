// <copyright file="TenantConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Models;

namespace NSHub.Domain.Constants;

/// <summary>
/// Provides predefined tenant values and utility methods for tenant validation.
/// </summary>
public static class TenantConstant
{
    /// <summary>
    /// The collection of supported tenants.
    /// </summary>
    private static readonly List<ConstantValue> Tenants =
    [
        Demo,
        Test,
        NSHub,
    ];

    /// <summary>
    /// Gets the Demo tenant definition.
    /// </summary>
    public static ConstantValue Demo => new()
    {
        Id = new Guid(0x39C70B59, 0x72CA, 0x4E63, 0x91, 0xB4, 0x35, 0x48, 0xFE, 0xF2, 0xAE, 0x19) /* 39C70B59-72CA-4E63-91B4-3548FEF2AE19 */,
        Name = "Demo",
    };

    /// <summary>
    /// Gets the Test tenant definition.
    /// </summary>
    public static ConstantValue Test => new()
    {
        Id = new Guid(0xBB45CC04, 0x1C20, 0x4136, 0x81, 0x3, 0xC9, 0x33, 0x4E, 0x1F, 0x42, 0x5F) /* BB45CC04-1C20-4136-8103-C9334E1F425F */,
        Name = "Test",
    };

    /// <summary>
    /// Gets the NSHub tenant definition.
    /// </summary>
    public static ConstantValue NSHub => new()
    {
        Id = new Guid(0x6FF06E5, 0x7C1A, 0x4448, 0xB8, 0x5A, 0xA5, 0x2A, 0xDB, 0xA0, 0x30, 0x83) /* 06FF06E5-7C1A-4448-B85A-A52ADBA03083 */,
        Name = "NSHub",
    };

    /// <summary>
    /// Determines whether the specified tenant identifier exists.
    /// </summary>
    /// <param name="id">The tenant identifier to validate.</param>
    /// <returns>
    /// <see langword="true"/> if the tenant identifier exists; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public static bool CheckId(Guid id) => Tenants.Exists(e => e.Id == id);
}
