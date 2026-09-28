// <copyright file="ConnectionStringOption.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Options;

/// <summary>
/// Represents the database connection string settings used by the application.
/// </summary>
public class ConnectionStringOption
{
    /// <summary>
    /// Gets or sets the connection string for the NSHub database.
    /// </summary>
    public string NSHub { get; set; } = null!;
}
