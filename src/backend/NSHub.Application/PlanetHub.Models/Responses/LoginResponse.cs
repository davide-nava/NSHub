// <copyright file="LoginResponse.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.NSHub.Models.Responses;

public class LoginResponse
{
	public string TokenType { get; set; } = string.Empty;

	public string AccessToken { get; set; } = string.Empty;

	public string RefreshToken { get; set; } = string.Empty;

	public int ExpiresIn { get; set; }
}
