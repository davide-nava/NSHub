// <copyright file="ChangeEmailRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.NSHub.Models.Requests;

public class ChangeEmailRequest
{
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired),
        ErrorMessageResourceType = typeof(SharedResource))]
    public ApplicationUser User { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; }

    public string? Code { get; set; }

}
