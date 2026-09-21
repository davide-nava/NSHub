// <copyright file="InvalidStateTransitionException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Exceptions;

/// <summary>
/// Exception thrown when an invalid lifecycle or state transition is attempted on an aggregate.
/// </summary>
public class InvalidStateTransitionException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidStateTransitionException"/> class.
    /// </summary>
    /// <param name="aggregateType">The name of the aggregate type.</param>
    /// <param name="currentState">The current state of the entity.</param>
    /// <param name="targetState">The rejected destination state.</param>
    public InvalidStateTransitionException(string aggregateType, string currentState, string targetState)
        : base("InvalidStateTransition", $"Cannot transition {aggregateType} from state '{currentState}' to '{targetState}'.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidStateTransitionException"/> class with a custom message.
    /// </summary>
    /// <param name="message">The custom violation message.</param>
    public InvalidStateTransitionException(string message)
        : base("InvalidStateTransition", message)
    {
    }
}
