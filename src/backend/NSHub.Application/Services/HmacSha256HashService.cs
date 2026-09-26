// <copyright file="HmacSha256HashService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Security.Cryptography;
using System.Text;
using NSHub.Application.Common.Interfaces;

namespace NSHub.Application.Services;

public class HmacSha256HashService : IHashService
{
    public string ComputeHash(byte[] data, string key)
    {
        using var hmacSha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key));
        var hash = hmacSha256.ComputeHash(data);
        return Convert.ToHexString(hash);
    }

    public string ComputeHash(string data, string key)
    {
        return ComputeHash(Encoding.UTF8.GetBytes(data), key);
    }

    public bool VerifyHash(byte[] data, string hash, string key)
    {
        var dataHash = ComputeHash(data, key);
        return CompareHashes(dataHash, hash);
    }

    public bool VerifyHash(string data, string hash, string key)
    {
        return VerifyHash(Encoding.UTF8.GetBytes(data), hash, key);
    }

    private static bool CompareHashes(string computedHash, string originHash)
    {
        if (string.IsNullOrEmpty(computedHash) || string.IsNullOrEmpty(originHash))
        {
            return false;
        }

        if (computedHash.Length != originHash.Length)
        {
            return false;
        }

        var computedHashSpan = computedHash.AsSpan();
        var originHashSpan = originHash.AsSpan();

        var result = 0;
        for (var i = 0; i < computedHashSpan.Length; i++)
        {
            result |= computedHashSpan[i] ^ originHashSpan[i];
        }

        return result == 0;
    }
}
