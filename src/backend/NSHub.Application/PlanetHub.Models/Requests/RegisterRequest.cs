// <copyright file="RegisterRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.NSHub.Models.Requests;

public class RegisterRequest
{
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[EmailAddress]
	[Display(Name = "Email")]
	public string Email { get; set; } = string.Empty;

	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[StringLength(100, ErrorMessageResourceName = nameof(SharedResource.EnableAuthenticatorRequestCodeStringLength), ErrorMessageResourceType = typeof(SharedResource), MinimumLength = 6)]
	[DataType(DataType.Password)]
	[Display(Name = "Password")]
	public string Password { get; set; } = string.Empty;

	[DataType(DataType.Password)]
	[Display(Name = "Confirm password")]
	[Compare("Password", ErrorMessageResourceName = nameof(SharedResource.ThePasswordAndConfirmationPasswordDoNotMatch), ErrorMessageResourceType = typeof(SharedResource))]
	public string ConfirmPassword { get; set; } = string.Empty;
}
