// <copyright file="ErrorType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace NSHub.Domain.Common;

/// <summary>
/// Categorization of domain and application errors.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ErrorType
{
    /// <summary>
    /// General unhandled failure.
    /// </summary>
    Failure = 0,

    /// <summary>
    /// Input or business validation failure.
    /// </summary>
    Validation = 1,

    /// <summary>
    /// Requested resource was not found.
    /// </summary>
    NotFound = 2,

    /// <summary>
    /// Conflicting state prevents operation execution.
    /// </summary>
    Conflict = 3,

    /// <summary>
    /// Authentication required or invalid credentials.
    /// </summary>
    Unauthorized = 4,

    /// <summary>
    /// Authenticated subject lacks required permissions.
    /// </summary>
    Forbidden = 5,

    /// <summary>
    /// Statutory or legal compliance rule violation.
    /// </summary>
    LegalViolation = 6,
}
