// <copyright file="Result.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Models;

/// <summary>
/// Represents the outcome of an operation without a return value.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="isSuccess">Indicates whether the operation succeeded.</param>
    /// <param name="errors">The collection of error messages, if any.</param>
    protected Result(bool isSuccess, IEnumerable<string>? errors)
    {
        IsSuccess = isSuccess;
        Errors = errors?.ToList().AsReadOnly() ?? (IReadOnlyList<string>)[];
    }

    /// <summary>
    /// Gets a value indicating whether the operation succeeded.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the operation failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the collection of error messages.
    /// </summary>
    public IReadOnlyList<string> Errors { get; }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <returns>A successful <see cref="Result"/> instance.</returns>
    public static Result Success() => new(true, null);

    /// <summary>
    /// Creates a failed result with a single error message.
    /// </summary>
    /// <param name="error">The error message.</param>
    /// <returns>A failed <see cref="Result"/> instance.</returns>
    public static Result Failure(string error) => new(false, [error]);

    /// <summary>
    /// Creates a failed result with multiple error messages.
    /// </summary>
    /// <param name="errors">The collection of error messages.</param>
    /// <returns>A failed <see cref="Result"/> instance.</returns>
    public static Result Failure(IEnumerable<string> errors) => new(false, errors);

    /// <summary>
    /// Creates a successful result encapsulating the provided value.
    /// </summary>
    /// <typeparam name="T">The type of the encapsulated value.</typeparam>
    /// <param name="value">The value to encapsulate.</param>
    /// <returns>A successful <see cref="Result{T}"/> instance.</returns>
    public static Result<T> Success<T>(T value) => Result<T>.Success(value);

    /// <summary>
    /// Creates a failed result with a single error message for type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the encapsulated value.</typeparam>
    /// <param name="error">The error message.</param>
    /// <returns>A failed <see cref="Result{T}"/> instance.</returns>
    public static Result<T> Failure<T>(string error) => Result<T>.Failure(error);

    /// <summary>
    /// Creates a failed result with multiple error messages for type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the encapsulated value.</typeparam>
    /// <param name="errors">The collection of error messages.</param>
    /// <returns>A failed <see cref="Result{T}"/> instance.</returns>
    public static Result<T> Failure<T>(IEnumerable<string> errors) => Result<T>.Failure(errors);
}

/// <summary>
/// Represents the outcome of an operation with a return value of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the encapsulated value.</typeparam>
public class Result<T> : Result
{
    private readonly T? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class representing success.
    /// </summary>
    /// <param name="value">The returned value.</param>
    protected Result(T value)
        : base(true, null)
    {
        _value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class representing failure.
    /// </summary>
    /// <param name="errors">The collection of error messages.</param>
    protected Result(IEnumerable<string> errors)
        : base(false, errors)
    {
        _value = default;
    }

    /// <summary>
    /// Gets the encapsulated value if the operation succeeded.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when accessing the value of a failed result.</exception>
    public T Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Cannot access the value of a failed result.");

    /// <summary>
    /// Creates a successful result encapsulating the provided value.
    /// </summary>
    /// <param name="value">The value to encapsulate.</param>
    /// <returns>A successful <see cref="Result{T}"/> instance.</returns>
    public static Result<T> Success(T value) => new(value);

    /// <summary>
    /// Creates a failed result with a single error message.
    /// </summary>
    /// <param name="error">The error message.</param>
    /// <returns>A failed <see cref="Result{T}"/> instance.</returns>
    public static new Result<T> Failure(string error) => new([error]);

    /// <summary>
    /// Creates a failed result with multiple error messages.
    /// </summary>
    /// <param name="errors">The collection of error messages.</param>
    /// <returns>A failed <see cref="Result{T}"/> instance.</returns>
    public static new Result<T> Failure(IEnumerable<string> errors) => new(errors);

    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="T"/> to a successful <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator Result<T>(T value) => Success(value);
}
