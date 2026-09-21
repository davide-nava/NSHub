// <copyright file="GetByClaimsPrincipalRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Security.Claims;

namespace NSHub.Application.NSHub.Models.Requests;

public class GetByClaimsPrincipalRequest
{
	public ClaimsPrincipal? ClaimsPrincipal { get; set; }
}
