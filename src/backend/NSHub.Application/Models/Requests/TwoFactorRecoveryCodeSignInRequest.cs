// <copyright file="TwoFactorRecoveryCodeSignInRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Models.Requests;

public class TwoFactorRecoveryCodeSignInRequest
{
	public string RecoveryCode { get; set; } = string.Empty;
}

