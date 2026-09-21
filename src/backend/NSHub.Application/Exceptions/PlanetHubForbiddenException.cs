// <copyright file="PlanetHubForbiddenException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Exceptions;

public class NSHubForbiddenException : Exception
{
    public NSHubForbiddenException()
    {
    }

    public NSHubForbiddenException(string? message)
        : base(message)
    {
    }

    public NSHubForbiddenException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
