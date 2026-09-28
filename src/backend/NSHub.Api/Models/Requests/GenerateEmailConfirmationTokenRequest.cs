// <copyright file="GenerateEmailConfirmationTokenRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>


using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;
using NSHub.Domain.Entities;

namespace NSHub.Application.Models.Requests;

public class GenerateEmailConfirmationTokenRequest
{
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public ApplicationUser User { get; set; } = null!;
}

