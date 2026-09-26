// <copyright file="Error.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Encapsulates error information for domain and application outcomes.
/// </summary>
/// <param name="Code">A unique machine-readable error code identifying the error condition.</param>
/// <param name="Description">A human-readable description providing details about the error.</param>
/// <param name="Type">The categorized error type determining HTTP/transport mapping.</param>
public record Error(string Code, string Description, ErrorType Type = ErrorType.Failure)
{
    /// <summary>
    /// Gets the empty or non-error sentinel instance.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    /// <summary>
    /// Creates a generic failure error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new <see cref="Error"/> of type <see cref="ErrorType.Failure"/>.</returns>
    public static Error Failure(string code, string description) =>
        new(code, description, ErrorType.Failure);

    /// <summary>
    /// Creates an input or business validation error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new <see cref="Error"/> of type <see cref="ErrorType.Validation"/>.</returns>
    public static Error Validation(string code, string description) =>
        new(code, description, ErrorType.Validation);

    /// <summary>
    /// Creates a resource-not-found error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new <see cref="Error"/> of type <see cref="ErrorType.NotFound"/>.</returns>
    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);

    /// <summary>
    /// Creates a conflict error indicating a state transition or uniqueness clash.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new <see cref="Error"/> of type <see cref="ErrorType.Conflict"/>.</returns>
    public static Error Conflict(string code, string description) =>
        new(code, description, ErrorType.Conflict);

    /// <summary>
    /// Creates an unauthorized error for authentication failures.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new <see cref="Error"/> of type <see cref="ErrorType.Unauthorized"/>.</returns>
    public static Error Unauthorized(string code, string description) =>
        new(code, description, ErrorType.Unauthorized);

    /// <summary>
    /// Creates a forbidden error for permission/authorization failures.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new <see cref="Error"/> of type <see cref="ErrorType.Forbidden"/>.</returns>
    public static Error Forbidden(string code, string description) =>
        new(code, description, ErrorType.Forbidden);

    /// <summary>
    /// Creates a statutory or legal compliance violation error (e.g. Swiss labor law OLL 1).
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    /// <returns>A new <see cref="Error"/> of type <see cref="ErrorType.LegalViolation"/>.</returns>
    public static Error LegalViolation(string code, string description) =>
        new(code, description, ErrorType.LegalViolation);

    /// <summary>
    /// Implicitly converts a string error message into an <see cref="Error"/> with a generic failure code.
    /// </summary>
    /// <param name="message">The error message.</param>
    public static implicit operator Error(string message) =>
        Failure("General.Failure", message);
}
