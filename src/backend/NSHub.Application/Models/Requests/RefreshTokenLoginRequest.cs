// <copyright file="RefreshTokenLoginRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.NSHub.Models.Requests;

public class RefreshTokenLoginRequest
{
	public string RefreshToken { get; set; } = string.Empty;
}

