// <copyright file="ApplicationUser.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace NSHub.Application.NSHub.Models;

public class ApplicationUser : IdentityUser<Guid>
{
	public Guid? TenantId
	{
		get; set;
	}
}

