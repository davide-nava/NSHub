// <copyright file="UserConfigurationJson.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities.Json;

public class UserConfigurationJson
{
    public string Theme { get; set; } = "NSHubTheme";

    public string Language { get; set; } = "it-IT";

    public string NumberDecimalSeparator { get; set; } = ".";

    public string NumberGroupSeparator { get; set; } = ",";

    public string? DateTimeFormat { get; set; } = "dd/MM/yyyy";
}
