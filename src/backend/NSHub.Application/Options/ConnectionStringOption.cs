// <copyright file="ConnectionStringOption.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Services;

namespace NSHub.Application.Options;

public class ConnectionStringOption
{
    public string NSHub { get => AesService.Decrypt(field); set; } = null!;
}
