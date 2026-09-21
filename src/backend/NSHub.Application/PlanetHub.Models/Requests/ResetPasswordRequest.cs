// <copyright file="ResetPasswordRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.NSHub.Models.Requests;

public class ResetPasswordRequest
{
    [Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
    public ApplicationUser User { get; set; } = null!;

	public string Code { get; set; } = string.Empty;

	[DataType(DataType.EmailAddress, ErrorMessageResourceName = nameof(SharedResource.ErrorEmailAddress), ErrorMessageResourceType = typeof(SharedResource))]
	[EmailAddress]
	public string Email { get; set; } = string.Empty;

	[DataType(DataType.Password, ErrorMessageResourceName = nameof(SharedResource.ErrorDataTypePassword), ErrorMessageResourceType = typeof(SharedResource))]
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]

	[StringLength(100, ErrorMessageResourceName = nameof(SharedResource.EnableAuthenticatorRequestCodeStringLength), ErrorMessageResourceType = typeof(SharedResource), MinimumLength = 6)]
	public string Password { get; set; } = string.Empty;

	[DataType(DataType.Password, ErrorMessageResourceName = nameof(SharedResource.ErrorDataTypePassword), ErrorMessageResourceType = typeof(SharedResource))]
	[Compare("Password", ErrorMessageResourceName = nameof(SharedResource.ErrorComparePawword), ErrorMessageResourceType = typeof(SharedResource))]
	[Display(Name = "Confirm password")]
	public string ConfirmPassword { get; set; } = string.Empty;
}
