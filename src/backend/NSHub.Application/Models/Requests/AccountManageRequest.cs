// <copyright file="AccountManageRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace NSHub.Application.NSHub.Models.Requests;

public class AccountManageRequest
{
	[Phone]
	[Display(Name = "Phone number")]
	public string? PhoneNumber
	{
		get; set;
	}
}

