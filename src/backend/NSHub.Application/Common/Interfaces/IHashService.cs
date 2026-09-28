// <copyright file="IHashService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Service contract for computing and verifying cryptographic hashes.
/// </summary>
public interface IHashService
{
    /// <summary>
    /// Computes an HMAC-SHA256 hash for raw byte data.
    /// </summary>
    /// <param name="data">The byte data to hash.</param>
    /// <param name="key">The key used for HMAC calculation.</param>
    /// <returns>Hex-encoded hash string.</returns>
    string ComputeHash(byte[] data, string key);

    /// <summary>
    /// Computes an HMAC-SHA256 hash for string data.
    /// </summary>
    /// <param name="data">The string data to hash.</param>
    /// <param name="key">The key used for HMAC calculation.</param>
    /// <returns>Hex-encoded hash string.</returns>
    string ComputeHash(string data, string key);

    /// <summary>
    /// Verifies whether the provided raw byte data matches the expected hash.
    /// </summary>
    /// <param name="data">The byte data to verify.</param>
    /// <param name="hash">The expected hex-encoded hash.</param>
    /// <param name="key">The key used for HMAC calculation.</param>
    /// <returns>True if the hash matches; otherwise, false.</returns>
    bool VerifyHash(byte[] data, string hash, string key);

    /// <summary>
    /// Verifies whether the provided string data matches the expected hash.
    /// </summary>
    /// <param name="data">The string data to verify.</param>
    /// <param name="hash">The expected hex-encoded hash.</param>
    /// <param name="key">The key used for HMAC calculation.</param>
    /// <returns>True if the hash matches; otherwise, false.</returns>
    bool VerifyHash(string data, string hash, string key);
}
