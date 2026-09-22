// <copyright file="ForgotPasswordRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.NSHub.Models.Requests;

public class ForgotPasswordRequest
{
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[EmailAddress(ErrorMessageResourceName = nameof(SharedResource.ErrorEmailAddress), ErrorMessageResourceType = typeof(SharedResource))]
	public string Email { get; set; } = string.Empty;

	public string Log { get; set; } = string.Empty;
}

