// <copyright file="Result.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Represents the result of an operation, indicating success or failure.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="isSuccess">A value indicating whether the operation was successful.</param>
    /// <param name="error">The error associated with a failed operation.</param>
    /// <param name="errors">An optional collection of errors.</param>
    /// <exception cref="InvalidOperationException">Thrown when invariants between status and errors are violated.</exception>
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
        var errorList = errors.ToList();
        return new Result(false, errorList.FirstOrDefault() ?? Error.Failure("General.Error", "Unknown error"), errorList);
    }
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
        var errorList = errors.ToList();
        return new Result<TValue>(default, false, errorList.FirstOrDefault() ?? Error.Failure("General.Error", "Unknown error"), errorList);
    }

    /// <summary>
    /// Implicitly converts a value into a successful <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="value">The value to encapsulate.</param>
    public static implicit operator Result<TValue>(TValue value) => Success(value);
}
