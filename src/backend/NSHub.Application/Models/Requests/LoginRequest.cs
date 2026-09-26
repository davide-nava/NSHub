// <copyright file="LoginRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.Models.Requests;

public class LoginRequest
{
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[EmailAddress(ErrorMessageResourceName = nameof(SharedResource.ErrorEmailAddress), ErrorMessageResourceType = typeof(SharedResource))]
	public string Email { get; set; } = string.Empty;

	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[DataType(DataType.Password, ErrorMessageResourceName = nameof(SharedResource.ErrorDataTypePassword), ErrorMessageResourceType = typeof(SharedResource))]
	public string Password { get; set; } = string.Empty;

	[Display(Name = "Remember me?")]
	public bool RememberMe
	{
		get; set;
	}

	public PasskeyModel? Passkey
	{
		get; set;
	}
}

