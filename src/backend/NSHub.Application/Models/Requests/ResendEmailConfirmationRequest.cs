// <copyright file="ResendEmailConfirmationRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.Models.Requests;

public class ResendEmailConfirmationRequest
{
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[EmailAddress]
	public string Email { get; set; } = string.Empty;
}

