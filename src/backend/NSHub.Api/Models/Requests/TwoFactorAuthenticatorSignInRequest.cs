// <copyright file="TwoFactorAuthenticatorSignInRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Models.Requests;

public class TwoFactorAuthenticatorSignInRequest
{
    public string Code { get; set; } = string.Empty;

    public bool IsPersistent
    {
        get; set;
    }

    public bool RememberClient
    {
        get; set;
    }
}

