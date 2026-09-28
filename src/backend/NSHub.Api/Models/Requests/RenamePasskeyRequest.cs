// <copyright file="RenamePasskeyRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.Models.Requests;

public class RenamePasskeyRequest
{
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[StringLength(200, ErrorMessageResourceName = nameof(SharedResource.PasskeyNamesMustBeNoLongerThanCharacters), ErrorMessageResourceType = typeof(SharedResource))]
	public string Name { get; set; } = string.Empty;
}

