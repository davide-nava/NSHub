// <copyright file="AddressType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an address type entity in the domain model.
/// </summary>
public class AddressType : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the code of the address type.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the address type.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;
}
