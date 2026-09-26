// <copyright file="IHasRowVersion.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Defines an entity that has a row version for concurrency control.
/// </summary>
public interface IHasRowVersion
{
    /// <summary>
    /// Gets or sets the row version for concurrency control.
    /// </summary>
    public IEnumerable<byte> RowVersion { get; set; }
}
