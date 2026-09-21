// <copyright file="AuthenticationOption.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Services;

namespace NSHub.Application.Options;

public class AuthenticationOption
{
    public string MicrosoftClientId { get => AesService.Decrypt(field); set; } = "xxxx";

    public string MicrosoftClientSecret { get => AesService.Decrypt(field); set; } = "xxxx";

    public string GoogleClientId { get => AesService.Decrypt(field); set; } = "xxxx";

    public string GoogleClientSecret { get => AesService.Decrypt(field); set; } = "xxxx";

    public string PersistKeysToFileSystem { get => AesService.Decrypt(field); set; } = "xxxx";

    public string CookieDomain { get => AesService.Decrypt(field); set; } = "xxxx";

    public bool IsGoogle { get; set; }

    public bool IsMicrosoft { get; set; }
}
