// <copyright file="ExternalLoginSignInRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.NSHub.Models.Requests;

public class ExternalLoginSignInRequest
{
    public bool IsPersistent { get; set; }

    public bool BypassTwoFactor { get; set; }

	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public string ProviderKey { get; set; }= null!;

    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired),
        ErrorMessageResourceType = typeof(SharedResource))]
    public string LoginProvider { get; set; } = null!;
}
