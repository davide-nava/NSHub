// <copyright file="Error.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

using System.Text.Json.Serialization;

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

/// <summary>
/// Encapsulates error information for domain and application outcomes.
/// </summary>
/// <param name="Code">Error code.</param>
/// <param name="Description">Error message description.</param>
/// <param name="Type">The categorized error type.</param>
public record Error(string Code, string Description, ErrorType Type = ErrorType.Failure)
{
    /// <summary>
    /// Empty or non-error sentinel.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    /// <summary>
    /// Creates a generic failure error.
    /// </summary>
    public static Error Failure(string code, string description) =>
        new(code, description, ErrorType.Failure);

    /// <summary>
    /// Creates a validation error.
    /// </summary>
    public static Error Validation(string code, string description) =>
        new(code, description, ErrorType.Validation);

    /// <summary>
    /// Creates a not found error.
    /// </summary>
    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);

    /// <summary>
    /// Creates a conflict error.
    /// </summary>
    public static Error Conflict(string code, string description) =>
        new(code, description, ErrorType.Conflict);

    /// <summary>
    /// Creates an unauthorized error.
    /// </summary>
    public static Error Unauthorized(string code, string description) =>
        new(code, description, ErrorType.Unauthorized);

    /// <summary>
    /// Creates a forbidden error.
    /// </summary>
    public static Error Forbidden(string code, string description) =>
        new(code, description, ErrorType.Forbidden);

    /// <summary>
    /// Creates a legal or statutory compliance violation error.
    /// </summary>
    public static Error LegalViolation(string code, string description) =>
        new(code, description, ErrorType.LegalViolation);
}
