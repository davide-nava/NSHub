// <copyright file="BadRequestException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Exceptions;

public class BadRequestException : Exception
{
    public IEnumerable<string?> ErrorModel { get; } = [];

    public BadRequestException()
    {
    }

    public BadRequestException(Exception innerException)
        : base(string.Empty, innerException)
    {
    }

    public BadRequestException(string? message)
        : base(message)
    {
    }

    public BadRequestException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
