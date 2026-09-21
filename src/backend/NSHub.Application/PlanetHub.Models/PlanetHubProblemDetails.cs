// <copyright file="PlanetHubProblemDetails.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace NSHub.Application.PlanetHub.Models;

public class NSHubProblemDetails : ProblemDetails
{
    public string? NodeId { get; set; } = string.Empty;

    public string? Method { get; set; } = string.Empty;

    public string? Path { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public string? Host { get; set; } = string.Empty;

    public string? TraceId { get; set; } = string.Empty;
}

