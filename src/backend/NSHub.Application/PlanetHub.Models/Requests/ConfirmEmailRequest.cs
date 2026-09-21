// <copyright file="ConfirmEmailRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.PlanetHub.Models.Requests;

public class ConfirmEmailRequest
{
	public Guid UserId { get; set; }

	public string Code { get; set; } = string.Empty;
}

