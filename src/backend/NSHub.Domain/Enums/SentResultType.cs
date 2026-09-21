// <copyright file="SentResultType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Represents the result type of a sent operation.
/// </summary>
public enum SentResultType
{
    /// <summary>
    /// Represents a successful sent operation.
    /// </summary>
    SUCCESS = 1,

    /// <summary>
    /// Represents an error occurred during the sent operation.
    /// </summary>
    ERROR = 2,
}
