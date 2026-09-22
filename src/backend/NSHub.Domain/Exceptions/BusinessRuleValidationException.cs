// <copyright file="BusinessRuleValidationException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Exceptions;

/// <summary>
/// Exception thrown when a domain business rule or invariant check is violated.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BusinessRuleValidationException"/> class.
/// </remarks>
/// <param name="code">The validation error code.</param>
/// <param name="message">The validation failure message.</param>
public class BusinessRuleValidationException(string code, string message) : DomainException(code, message);
