// <copyright file="BusinessRuleValidationException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Exceptions;

/// <summary>
/// Exception thrown when a domain business rule or invariant check is violated.
/// </summary>
public class BusinessRuleValidationException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessRuleValidationException"/> class.
    /// </summary>
    /// <param name="code">The validation error code.</param>
    /// <param name="message">The validation failure message.</param>
    public BusinessRuleValidationException(string code, string message)
        : base(code, message)
    {
    }
}
