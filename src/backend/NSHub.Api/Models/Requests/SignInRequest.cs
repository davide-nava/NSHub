// <copyright file="SignInRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using NSHub.Application.Localizations;
using NSHub.Domain.Entities;

namespace NSHub.Application.Models.Requests;

public class SignInRequest
{
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public ApplicationUser User { get; set; } = null!;

    public bool IsPersistent
    {
        get; set;
    }

    public string? AuthenticationMethod
    {
        get; set;
    }

    public AuthenticationProperties? AuthenticationProperties
    {
        get; set;
    }
}

