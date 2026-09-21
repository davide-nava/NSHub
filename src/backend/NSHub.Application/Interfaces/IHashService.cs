// <copyright file="IHashService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Interfaces;

public interface IHashService
{
    string ComputeHash(byte[] data, string key);

    string ComputeHash(string data, string key);

    bool VerifyHash(byte[] data, string hash, string key);

    bool VerifyHash(string data, string hash, string key);
}
