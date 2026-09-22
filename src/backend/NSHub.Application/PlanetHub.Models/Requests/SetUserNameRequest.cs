// <copyright file="SetUserNameRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.NSHub.Models.Requests;

public class SetUserNameRequest
{
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public ApplicationUser User { get; set; } = null!;

    [EmailAddress]
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public string UserName { get; set; } = null!;
}

