// <copyright file="Result.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace NSHub.Application.Common.Models;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string? Error { get; }
    public IReadOnlyCollection<string> Errors { get; }

    protected Result(bool isSuccess, string? error = null, IEnumerable<string>? errors = null)
    {
        if (isSuccess && !string.IsNullOrEmpty(error))
            throw new InvalidOperationException("Successful result cannot have an error.");
        if (!isSuccess && string.IsNullOrEmpty(error) && (errors == null || !errors.Any()))
            throw new InvalidOperationException("Failed result must have an error.");

        IsSuccess = isSuccess;
        Error = error;
        Errors = errors?.ToList().AsReadOnly() ?? (error != null ? new List<string> { error }.AsReadOnly() : new List<string>().AsReadOnly());
    }

    public static Result Success() => new(true);
    public static Result Failure(string error) => new(false, error: error);
    public static Result Failure(IEnumerable<string> errors) => new(false, error: errors.FirstOrDefault(), errors: errors);

    public static Result<T> Success<T>(T value) => Result<T>.Success(value);
    public static Result<T> Failure<T>(string error) => Result<T>.Failure(error);
    public static Result<T> Failure<T>(IEnumerable<string> errors) => Result<T>.Failure(errors);
}

public class Result<T> : Result
{
    private readonly T? _value;

    public T Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Cannot access the value of a failure result.");

    protected internal Result(bool isSuccess, T? value, string? error = null, IEnumerable<string>? errors = null)
        : base(isSuccess, error, errors)
    {
        _value = value;
    }

    public static Result<T> Success(T value) => new(true, value);
    public new static Result<T> Failure(string error) => new(false, default, error: error);
    public new static Result<T> Failure(IEnumerable<string> errors) => new(false, default, error: errors.FirstOrDefault(), errors: errors);

    public static implicit operator Result<T>(T value) => Success(value);
}
