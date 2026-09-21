// <copyright file="PasswordSignInRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.PlanetHub.Models.Requests;

public class PasswordSignInRequest
{
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public ApplicationUser User { get; set; } = null!;

    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public bool IsPersistent { get; set; }

    public bool LockoutOnFailure { get; set; }
}

