// <copyright file="BadRequestException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a request is invalid
/// or cannot be processed due to client-side errors.
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class.
    /// </summary>
    public BadRequestException()
        : this([])
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class
    /// with a collection of error messages.
    /// </summary>
    /// <param name="errorModel">
    /// The collection of validation or business error messages.
    /// </param>
    public BadRequestException(IEnumerable<string?> errorModel)
        : base("One or more request validation errors occurred.")
    {
        ErrorModel = errorModel;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class
    /// with a reference to the inner exception that caused the current exception.
    /// </summary>
    /// <param name="innerException">
    /// The exception that caused the current exception.
    /// </param>
    public BadRequestException(Exception innerException)
        : base(string.Empty, innerException)
    {
        ErrorModel = [];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class
    /// with a specified error message.
    /// </summary>
    /// <param name="message">
    /// The message that describes the error.
    /// </param>
    public BadRequestException(string? message)
        : base(message)
    {
        ErrorModel = [];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class
    /// with a specified error message and a reference to the inner exception
    /// that caused the current exception.
    /// </summary>
    /// <param name="message">
    /// The message that describes the error.
    /// </param>
    /// <param name="innerException">
    /// The exception that caused the current exception.
    /// </param>
    public BadRequestException(string? message, Exception? innerException)
        : base(message, innerException)
    {
        ErrorModel = [];
    }

    /// <summary>
    /// Gets the collection of validation or business error messages
    /// associated with the request.
    /// </summary>
    public IEnumerable<string?> ErrorModel { get; }
}
