// <copyright file="DomainException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Exceptions;

/// <summary>
/// Base class for all domain-specific invariant and business rule exceptions.
/// </summary>
public abstract class DomainException : Exception
{
    /// <summary>
    /// Gets the unique error code associated with the domain violation.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class.
    /// </summary>
    /// <param name="code">The unique machine-readable error code.</param>
    /// <param name="message">The human-readable description of the violation.</param>
    protected DomainException(string code, string message) : base(message)
    {
        Code = code;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with an inner exception.
    /// </summary>
    /// <param name="code">The unique machine-readable error code.</param>
    /// <param name="message">The human-readable description of the violation.</param>
    /// <param name="innerException">The causing exception.</param>
    protected DomainException(string code, string message, Exception innerException) : base(message, innerException)
    {
        Code = code;
    }
}
