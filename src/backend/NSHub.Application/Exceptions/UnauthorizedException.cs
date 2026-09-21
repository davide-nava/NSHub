// <copyright file="UnauthorizedException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException()
    {
    }

    public UnauthorizedException(string? message)
        : base(message)
    {
    }

    public UnauthorizedException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
