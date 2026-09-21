// <copyright file="RoleConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.PlanetHub.Models;

namespace NSHub.Application.Constants;

public static class RoleConstant
{
    public static ConstantValue Admin => new() { Id = new("368BA8D8-3E8C-429C-8991-97EC06B4F3DE"), Name = "Admin", Index = 1 };

    public static ConstantValue Consultant => new() { Id = new("8572F0F6-AE31-48C5-8B22-298DAC08197F"), Name = "Consultant", Index = 2 };

    public static ConstantValue User => new() { Id = new("045C2964-6CE5-474D-B6F2-ADE00F6D52F7"), Name = "User", Index = 3 };

    public static ConstantValue Editor => new() { Id = new("A1A62873-5D91-49FA-AEB7-203997BA5392"), Name = "Editor", Index = 5 };

    private static readonly List<ConstantValue> roles =
[
        Admin,
        Consultant,
        User,
        Editor,
    ];

    public static bool CheckId(Guid id) => roles.Any(e => e.Id == id);

    public static bool CheckName(string name) => roles.Any(e => e.Name == name);
}

