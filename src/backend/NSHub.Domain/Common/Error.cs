// <copyright file="Error.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

public enum ErrorType
{
    FAILURE = 0,
    VALIDATION = 1,
    NOT_FOUND = 2,
    CONFLICT = 3,
    UNAUTHORIZED = 4,
    FORBIDDEN = 5,
    LEGAL_VIOLATION = 6,
}

public record Error(string Code, string Description, ErrorType Type = ErrorType.FAILURE)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.FAILURE);

    public static Error Failure(string code, string description) =>
        new(code, description, ErrorType.FAILURE);

    public static Error Validation(string code, string description) =>
        new(code, description, ErrorType.VALIDATION);

    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NOT_FOUND);

    public static Error Conflict(string code, string description) =>
        new(code, description, ErrorType.CONFLICT);

    public static Error Unauthorized(string code, string description) =>
        new(code, description, ErrorType.UNAUTHORIZED);

    public static Error Forbidden(string code, string description) =>
        new(code, description, ErrorType.FORBIDDEN);

    public static Error LegalViolation(string code, string description) =>
        new(code, description, ErrorType.LEGAL_VIOLATION);
}
