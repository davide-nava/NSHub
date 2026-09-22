// <copyright file="NSHubOption.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Options;

public class NSHubOption
{
    public Guid? ApplicationId
    {
        get; set;
    }

    public string? ApiKey
    {
        get; set;
    }

    public string Cors { get; set; } = string.Empty;

    public bool UseSwagger
    {
        get; set;
    }

    public bool SerilogMSSqlServer { get; set; } = true;

    public bool SerilogSQLite { get; set; } = true;

    public bool SerilogEmail { get; set; } = true;

    public bool TestMode
    {
        get; set;
    }

    public string Api { get; set; } = string.Empty;

    public string? Hub
    {
        get; set;
    }

    public string Blazor { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;
}
