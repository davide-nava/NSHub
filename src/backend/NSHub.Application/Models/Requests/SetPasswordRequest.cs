// <copyright file="SetPasswordRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.NSHub.Models.Requests;

public class SetPasswordRequest
{
	[StringLength(100, MinimumLength = 6, ErrorMessageResourceName = nameof(SharedResource.EnableAuthenticatorRequestCodeStringLength), ErrorMessageResourceType = typeof(SharedResource))]
	[DataType(DataType.Password)]
	[Display(Name = "New password")]
	public string? NewPassword
	{
		get; set;
	}

	[DataType(DataType.Password)]
	[Display(Name = "Confirm new password")]
	[Compare("NewPassword", ErrorMessageResourceName = nameof(SharedResource.TheNewPasswordAndConfirmationPasswordDoNotMatch), ErrorMessageResourceType = typeof(SharedResource))]
	public string? ConfirmPassword
	{
		get; set;
	}
}

