// <copyright file="DeletePersonalDataRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace NSHub.Application.Models.Requests;

public class DeletePersonalDataRequest
{
	[DataType(DataType.Password)]
	public string Password { get; set; } = string.Empty;
}

