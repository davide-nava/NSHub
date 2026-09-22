// <copyright file="IPasswordHasher.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Identity.Services;

/// <summary>
/// Domain service contract for cryptographic password hashing and verification.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Computes a secure hash and salt for the given plain-text password.
    /// </summary>
    (string Hash, string Salt) HashPassword(string password);

    /// <summary>
    /// Verifies whether the provided plain-text password matches the stored hash and salt.
    /// </summary>
    bool VerifyPassword(string password, string hash, string salt);
}
