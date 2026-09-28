// <copyright file="VerifyTwoFactorTokenRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;
using NSHub.Domain.Entities;

namespace NSHub.Application.Models.Requests;

public class VerifyTwoFactorTokenRequest
{
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public ApplicationUser User { get; set; } = null!;

    public string? TokenProvider
    {
        get; set;
    }

    public string? Token
    {
        get; set;
    }
}

