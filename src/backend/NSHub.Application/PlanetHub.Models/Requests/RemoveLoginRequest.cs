// <copyright file="RemoveLoginRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.PlanetHub.Models.Requests;

public class RemoveLoginRequest
{
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public ApplicationUser User { get; set; } = null!;

    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public string LoginProvider { get; set; } = null!;

    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public string ProviderKey { get; set; } = null!;
}

