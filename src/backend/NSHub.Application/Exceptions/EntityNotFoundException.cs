// <copyright file="EntityNotFoundException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a requested entity
/// cannot be found.
/// </summary>
public class EntityNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
    /// </summary>
    public EntityNotFoundException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class
    /// for the specified entity type and identifier.
    /// </summary>
    /// <param name="entityName">
    /// The name of the entity that could not be found.
    /// </param>
    /// <param name="key">
    /// The identifier of the entity that was requested.
    /// </param>
    public EntityNotFoundException(string entityName, object key)
        : base($"Entity '{entityName}' ({key}) was not found.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class
    /// with a specified error message.
    /// </summary>
    /// <param name="message">
    /// The message that describes the error.
    /// </param>
    public EntityNotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class
    /// with a specified error message and a reference to the inner exception
    /// that caused the current exception.
    /// </summary>
    /// <param name="message">
    /// The message that describes the error.
    /// </param>
    /// <param name="innerException">
    /// The exception that caused the current exception.
    /// </param>
    public EntityNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
