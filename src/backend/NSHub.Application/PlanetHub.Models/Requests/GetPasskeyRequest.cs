// <copyright file="GetPasskeyRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.PlanetHub.Models.Requests;

public class GetPasskeyRequest
{
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public ApplicationUser User { get; set; } = null!;

    public IEnumerable<byte> CredentialId { get; set; } = [];
}

