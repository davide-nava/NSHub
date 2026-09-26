// <copyright file="LoginWith2FaRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.NSHub.Models.Requests;

public class LoginWith2FaRequest
{
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[StringLength(7, MinimumLength = 6, ErrorMessageResourceName = nameof(SharedResource.ErrorDataTypePassword), ErrorMessageResourceType = typeof(SharedResource))]
	[DataType(DataType.Text)]
	[Display(Name = "Authenticator code")]
	public string? TwoFactorCode
	{
		get; set;
	}

	[Display(Name = "Remember this machine")]
	public bool RememberMachine
	{
		get; set;
	}
}

