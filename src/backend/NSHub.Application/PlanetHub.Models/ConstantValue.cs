// <copyright file="ConstantValue.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.PlanetHub.Models;

public class ConstantValue
{
    public string Description { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public Guid Id { get; set; }

    public int Index { get; set; }
}

