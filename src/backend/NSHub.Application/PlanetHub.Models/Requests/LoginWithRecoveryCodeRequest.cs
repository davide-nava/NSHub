// <copyright file="LoginWithRecoveryCodeRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.PlanetHub.Models.Requests;

public class LoginWithRecoveryCodeRequest
{
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[DataType(DataType.Text)]
	[Display(Name = "Recovery Code")]
	public string RecoveryCode { get; set; } = string.Empty;
}

