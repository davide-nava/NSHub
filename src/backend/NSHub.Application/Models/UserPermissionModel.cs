// <copyright file="UserPermissionModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.NSHub.Models;

public class UserPermissionModel
{
	public bool Read { get; set; } = true;

	public bool Edit { get; set; } = true;

	public bool Create { get; set; } = true;

	public bool Delete { get; set; } = true;
}

