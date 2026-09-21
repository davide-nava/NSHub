// <copyright file="ChangePasswordRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.PlanetHub.Models.Requests;

public class ChangePasswordRequest
{
	[DataType(DataType.Password, ErrorMessageResourceName = nameof(SharedResource.ErrorDataTypePassword), ErrorMessageResourceType = typeof(SharedResource))]
	public string OldPassword { get; set; } = string.Empty;

	[DataType(DataType.Password, ErrorMessageResourceName = nameof(SharedResource.ErrorDataTypePassword), ErrorMessageResourceType = typeof(SharedResource))]

	public string NewPassword { get; set; } = string.Empty;

	[DataType(DataType.Password, ErrorMessageResourceName = nameof(SharedResource.ErrorDataTypePassword), ErrorMessageResourceType = typeof(SharedResource))]
	[Compare("NewPassword", ErrorMessageResourceName = nameof(SharedResource.ErrorComparePawword), ErrorMessageResourceType = typeof(SharedResource))]
	public string ConfirmPassword { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;
}

