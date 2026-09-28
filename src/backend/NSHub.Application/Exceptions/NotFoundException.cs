// <copyright file="NotFoundException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a requested resource
/// cannot be found.
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    public NotFoundException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class
    /// with a reference to the inner exception that caused the current exception.
    /// </summary>
    /// <param name="innerException">
    /// The exception that caused the current exception.
    /// </param>
    public NotFoundException(Exception innerException)
        : base(string.Empty, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class
    /// with a specified error message.
    /// </summary>
    /// <param name="message">
    /// The message that describes the error.
    /// </param>
    public NotFoundException(string? message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class
    /// with a specified error message and a reference to the inner exception
    /// that caused the current exception.
    /// </summary>
    /// <param name="message">
    /// The message that describes the error.
    /// </param>
    /// <param name="innerException">
    /// The exception that caused the current exception.
    /// </param>
    public NotFoundException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class
    /// for the specified resource type and identifier.
    /// </summary>
    /// <param name="resourceName">
    /// The name of the resource that could not be found.
    /// </param>
    /// <param name="key">
    /// The identifier of the requested resource.
    /// </param>
    public NotFoundException(string resourceName, object key)
        : base($"Resource '{resourceName}' ({key}) was not found.")
    {
    }
}