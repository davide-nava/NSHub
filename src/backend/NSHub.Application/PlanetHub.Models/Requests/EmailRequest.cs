// <copyright file="EmailRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using NSHub.Application.Localizations;

namespace NSHub.Application.PlanetHub.Models.Requests;

public class EmailRequest
{
	[Required(ErrorMessageResourceName = nameof(SharedResource.ErrorRequired), ErrorMessageResourceType = typeof(SharedResource))]
	[EmailAddress]
	[Display(Name = "New email")]
	public string? NewEmail { get; set; }
}

