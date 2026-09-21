// <copyright file="UserLoggedModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.PlanetHub.Models.EntityModels.JsonModels;

namespace NSHub.Application.PlanetHub.Models;

public class UserLoggedModel
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string FirsttName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public UserConfigurationJsonModel Configuration { get; set; } = new();

    public NavMenu NavMenu { get; set; } = new();

    public string TenantName { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public int BadgeCount { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string? RefreshToken { get; set; }

    public string? Token { get; set; }

    public int TokenExpiresInSeconds { get; set; }

    public string? AccessToken { get; set; }
}

