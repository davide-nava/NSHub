// <copyright file="EnableAuthenticatorRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.Models.Requests;

public class EnableAuthenticatorRequest
{
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[StringLength(7, ErrorMessageResourceName = nameof(SharedResource.EnableAuthenticatorRequestCodeStringLength), ErrorMessageResourceType = typeof(SharedResource), MinimumLength = 6)]
	[DataType(DataType.Text)]
	[Display(Name = "Verification Code")]
	public string Code { get; set; } = string.Empty;
}

