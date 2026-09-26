// <copyright file="Result.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Represents the result of an operation, indicating success or failure with error details.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="isSuccess">A value indicating whether the operation succeeded.</param>
    /// <param name="error">The primary error if the operation failed.</param>
    /// <param name="errors">An optional collection of errors.</param>
    /// <exception cref="InvalidOperationException">Thrown when status and errors are inconsistent.</exception>
    protected Result(bool isSuccess, Error error, IReadOnlyList<Error>? errors = null)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException("A successful result cannot contain an error.");
        }

        if (!isSuccess && error == Error.None && (errors == null || errors.Count == 0))
        {
            throw new InvalidOperationException("A failed result must contain at least one error.");
        }

        IsSuccess = isSuccess;
        Error = error;
        Errors = errors ?? (error != Error.None ? [error] : []);
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
    /// Gets the primary error associated with a failure.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Gets the collection of errors associated with a failure.
    /// </summary>
    public IReadOnlyList<Error> Errors { get; }

    /// <summary>
    /// Creates a successful <see cref="Result"/>.
    /// </summary>
    /// <returns>A successful result instance.</returns>
    public static Result Success() => new(true, Error.None);

    /// <summary>
    /// Creates a failed <see cref="Result"/> with the specified error.
    /// </summary>
    /// <param name="error">The failure error.</param>
    /// <returns>A failed result instance.</returns>
    public static Result Failure(Error error) => new(false, error);

    /// <summary>
    /// Creates a failed <see cref="Result"/> with a collection of errors.
    /// </summary>
    /// <param name="errors">The collection of failure errors.</param>
    /// <returns>A failed result instance.</returns>
    public static Result Failure(IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var errorList = errors.ToList();
        return new Result(false, errorList.FirstOrDefault() ?? Error.Failure("General.Error", "Unknown error"), errorList);
    }

    /// <summary>
    /// Creates a failed <see cref="Result"/> with a collection of string error messages.
    /// </summary>
    /// <param name="errors">The collection of error message strings.</param>
    /// <returns>A failed result instance.</returns>
    public static Result Failure(IEnumerable<string> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var errorList = errors.Select(e => Error.Failure("Validation.Error", e)).ToList();
        return new Result(false, errorList.FirstOrDefault() ?? Error.Failure("General.Error", "Unknown error"), errorList);
    }

    /// <summary>
    /// Creates a successful <see cref="Result{TValue}"/> with the specified value.
    /// </summary>
    /// <typeparam name="TValue">The type of the encapsulated value.</typeparam>
    /// <param name="value">The produced value.</param>
    /// <returns>A successful typed result containing the value.</returns>
    public static Result<TValue> Success<TValue>(TValue value) => Result<TValue>.Success(value);

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with the specified error.
    /// </summary>
    /// <typeparam name="TValue">The type of the encapsulated value.</typeparam>
    /// <param name="error">The failure error.</param>
    /// <returns>A failed typed result instance.</returns>
    public static Result<TValue> Failure<TValue>(Error error) => Result<TValue>.Failure(error);

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with a collection of string error messages.
    /// </summary>
    /// <typeparam name="TValue">The type of the encapsulated value.</typeparam>
    /// <param name="errors">The collection of error messages.</param>
    /// <returns>A failed typed result instance.</returns>
    public static Result<TValue> Failure<TValue>(IEnumerable<string> errors) => Result<TValue>.Failure(errors);

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with a collection of errors.
    /// </summary>
    /// <typeparam name="TValue">The type of the encapsulated value.</typeparam>
    /// <param name="errors">The collection of errors.</param>
    /// <returns>A failed typed result instance.</returns>
    public static Result<TValue> Failure<TValue>(IEnumerable<Error> errors) => Result<TValue>.Failure(errors);
}

/// <summary>
/// Represents the result of an operation that produces a value of type <typeparamref name="TValue"/>.
/// </summary>
/// <typeparam name="TValue">The type of the encapsulated value.</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class.
    /// </summary>
    /// <param name="value">The produced value if successful.</param>
    /// <param name="isSuccess">A value indicating whether the operation was successful.</param>
    /// <param name="error">The error associated with a failed operation.</param>
    /// <param name="errors">An optional collection of errors.</param>
    protected internal Result(TValue? value, bool isSuccess, Error error, IReadOnlyList<Error>? errors = null)
        : base(isSuccess, error, errors)
    {
        this._value = value;
    }

    /// <summary>
    /// Gets the result value if successful.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when accessing the value of a failed result or when value is null on success.</exception>
    public TValue Value => IsSuccess
        ? (_value ?? throw new InvalidOperationException("Null value encountered in successful result."))
        : throw new InvalidOperationException("Cannot access the value of a failed result.");

    /// <summary>
    /// Creates a successful <see cref="Result{TValue}"/> with the specified value.
    /// </summary>
    /// <param name="value">The produced value.</param>
    /// <returns>A successful result containing the value.</returns>
    public static Result<TValue> Success(TValue value) => new(value, true, Error.None);

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with the specified error.
    /// </summary>
    /// <param name="error">The failure error.</param>
    /// <returns>A failed result instance.</returns>
    public new static Result<TValue> Failure(Error error) => new(default, false, error);

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with a collection of errors.
    /// </summary>
    /// <param name="errors">The collection of failure errors.</param>
    /// <returns>A failed result instance.</returns>
    public new static Result<TValue> Failure(IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var errorList = errors.ToList();
        return new Result<TValue>(default, false, errorList.FirstOrDefault() ?? Error.Failure("General.Error", "Unknown error"), errorList);
    }

    /// <summary>
    /// Creates a failed <see cref="Result{TValue}"/> with a collection of string error messages.
    /// </summary>
    /// <param name="errors">The collection of string error messages.</param>
    /// <returns>A failed result instance.</returns>
    public new static Result<TValue> Failure(IEnumerable<string> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        var errorList = errors.Select(e => Error.Failure("Validation.Error", e)).ToList();
        return new Result<TValue>(default, false, errorList.FirstOrDefault() ?? Error.Failure("General.Error", "Unknown error"), errorList);
    }

    /// <summary>
    /// Implicitly converts a value into a successful <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="value">The value to encapsulate.</param>
    public static implicit operator Result<TValue>(TValue value) => Success(value);
}
