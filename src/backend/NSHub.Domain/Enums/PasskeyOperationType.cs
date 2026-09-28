// <copyright file="PasskeyOperationType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Represents the type of passkey operation.
/// </summary>
public enum PasskeyOperationType
{
    /// <summary>
    /// Represents the create passkey operation.
    /// </summary>
    Create = 0,

    /// <summary>
    /// Represents the request passkey operation.
    /// </summary>
    Request = 1,
}
