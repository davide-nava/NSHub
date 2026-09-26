// <copyright file="AgreementType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an agreement type entity in the domain model.
/// </summary>
public class AgreementType : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the description of the agreement type.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code of the agreement type.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;
}
