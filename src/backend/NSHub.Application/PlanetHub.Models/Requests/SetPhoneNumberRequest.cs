// <copyright file="SetPhoneNumberRequest.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace NSHub.Application.NSHub.Models.Requests;

public class SetPhoneNumberRequest
{
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;
}

