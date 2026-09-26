// <copyright file="PasskeySignInRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.NSHub.Models.Requests;

public class PasskeySignInRequest
{
    public string CredentialJson { get; set; } = string.Empty;
}

