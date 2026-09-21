// <copyright file="AesService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace NSHub.Application.Services;

public static class AesService
{
    public static (string key, string iv) GenerateKeys()
    {
        using var aes = Aes.Create();
        aes.KeySize = 256; // Massima sicurezza
        aes.GenerateKey();
        aes.GenerateIV();

        return (Convert.ToBase64String(aes.Key), Convert.ToBase64String(aes.IV));
    }

    public static string Encrypt(string txt, string? key = null, string? iv = null, string? aesIvName = null, string? aesKeyName = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(txt);

        byte[] res;

        using var aes = Aes.Create();
        aes.KeySize = 256; // Massima sicurezza

        aes.Key = string.IsNullOrWhiteSpace(key)
            ? Convert.FromBase64String(GetKey(aesKeyName!))
            : Convert.FromBase64String(key);

        aes.IV = string.IsNullOrWhiteSpace(iv)
            ? Convert.FromBase64String(GetIv(aesIvName!))
            : Convert.FromBase64String(iv);

#pragma warning disable CA5401 // Do not use CreateEncryptor with non-default IV
        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
#pragma warning restore CA5401 // Do not use CreateEncryptor with non-default IV

        using MemoryStream msEncrypt = new();
        using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (StreamWriter swEncrypt = new(csEncrypt))
        {
            swEncrypt.Write(txt);
        }

        res = msEncrypt.ToArray();

        return Convert.ToBase64String(res);
    }

    public static string Decrypt(string txt, string? key = null, string? iv = null, string? aesKeyName = null, string? aesIvName = null)
    {
        var res = string.Empty;

        if (!string.IsNullOrWhiteSpace(txt))
        {
            using var aes = Aes.Create();
            aes.KeySize = 256; // Massima sicurezza

            aes.Key = string.IsNullOrWhiteSpace(key)
    ? Convert.FromBase64String(GetKey(aesKeyName!))
    : Convert.FromBase64String(key);

            aes.IV = string.IsNullOrWhiteSpace(iv)
                ? Convert.FromBase64String(GetIv(aesIvName!))
                : Convert.FromBase64String(iv);

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream msDecrypt = new(Convert.FromBase64String(txt));
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            res = srDecrypt.ReadToEnd();
        }

        return res;
    }

    private static string GetIv(string aesIvName)
    {
        var tmpIv = Environment.GetEnvironmentVariable(aesIvName);

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        if (string.IsNullOrWhiteSpace(tmpIv))
        {
            tmpIv = configuration[aesIvName];
        }

        return tmpIv ?? string.Empty;
    }

    private static string GetKey(string aesKeyName)
    {
        var tmpKey = Environment.GetEnvironmentVariable(aesKeyName);

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        if (string.IsNullOrWhiteSpace(tmpKey))
        {
            tmpKey = configuration[aesKeyName];
        }

        return tmpKey ?? string.Empty;
    }
}
