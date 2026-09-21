// <copyright file="IDateTimeProvider.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Abstraction for clock operations and Swiss legal timezone conversions.
/// </summary>
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
    DateTime SwissNow { get; }
    DateTime ToSwissTime(DateTime utcDateTime);
    DateTime ToUtc(DateTime swissDateTime);
}
