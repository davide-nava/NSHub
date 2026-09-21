// <copyright file="ConfirmEmailResponse.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.PlanetHub.Models.Responses;

public class ConfirmEmailResponse
{
	public bool UserFound { get; set; }

	public bool Confirm { get; set; }
}

