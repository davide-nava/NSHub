// <copyright file="User.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Exceptions;
using NSHub.Domain.Identity.Enums;
using NSHub.Domain.Identity.ValueObjects;

namespace NSHub.Domain.Identity.Entities;

/// <summary>
/// Aggregate root representing an enterprise user identity, authentication invariants, and roles.
/// </summary>
public class User : AggregateRoot<UserId>
{
    private readonly List<UserRole> _roles = [];
    private readonly List<UserClaim> _claims = [];

    /// <summary>
    /// Gets the unique normalized email address.
    /// </summary>
    public string Email { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the cryptographic password hash.
    /// </summary>
    public string PasswordHash { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the cryptographic salt associated with the password.
    /// </summary>
    public string PasswordSalt { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the user's first name.
    /// </summary>
    public string FirstName { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the user's last name.
    /// </summary>
    public string LastName { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the current account status.
    /// </summary>
    public UserStatus Status { get; private set; }

    /// <summary>
    /// Gets the consecutive failed login attempts counter.
    /// </summary>
    public int FailedLoginAttempts { get; private set; }

    /// <summary>
    /// Gets the UTC timestamp until which the user account is locked out.
    /// </summary>
    public DateTime? LockoutEndUtc { get; private set; }

    /// <summary>
    /// Gets the assigned security roles.
    /// </summary>
    public IReadOnlyCollection<UserRole> Roles => _roles.AsReadOnly();

    /// <summary>
    /// Gets the assigned identity claims.
    /// </summary>
    public IReadOnlyCollection<UserClaim> Claims => _claims.AsReadOnly();

    // Parameterless constructor for EF Core
    private User()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> aggregate root.
    /// </summary>
    /// <param name="id">The user identifier.</param>
    /// <param name="email">The corporate email address.</param>
    /// <param name="passwordHash">The computed password hash.</param>
    /// <param name="passwordSalt">The salt used for hashing.</param>
    /// <param name="firstName">The user's first name.</param>
    /// <param name="lastName">The user's last name.</param>
    public User(
        UserId id,
        string email,
        string passwordHash,
        string passwordSalt,
        string firstName,
        string lastName)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleValidationException("User.EmailRequired", "User email address is mandatory.");
        }

        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new BusinessRuleValidationException("User.FirstNameRequired", "User first name is mandatory.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new BusinessRuleValidationException("User.LastNameRequired", "User last name is mandatory.");
        }

        if (string.IsNullOrWhiteSpace(passwordHash) || string.IsNullOrWhiteSpace(passwordSalt))
        {
            throw new BusinessRuleValidationException("User.CredentialsRequired", "Password hash and salt are required.");
        }

        Id = id.Value == Guid.Empty ? UserId.New() : id;
        Email = email.Trim().ToLowerInvariant();
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Status = UserStatus.Active;
        FailedLoginAttempts = 0;
        LockoutEndUtc = null;
    }

    /// <summary>
    /// Records a failed authentication attempt and evaluates automatic lockout.
    /// </summary>
    /// <param name="maxAttempts">Maximum failed attempts permitted before lockout.</param>
    /// <param name="lockoutDuration">Duration of the security lockout.</param>
    public void RecordFailedLoginAttempt(int maxAttempts, TimeSpan lockoutDuration)
    {
        FailedLoginAttempts++;
        if (FailedLoginAttempts >= maxAttempts)
        {
            Status = UserStatus.LockedOut;
            LockoutEndUtc = DateTime.UtcNow.Add(lockoutDuration);
        }
    }

    /// <summary>
    /// Resets the failed login counter upon successful authentication.
    /// </summary>
    public void RecordSuccessfulLogin()
    {
        FailedLoginAttempts = 0;
        LockoutEndUtc = null;
    }

    /// <summary>
    /// Updates the user's password hash and salt.
    /// </summary>
    /// <param name="newHash">The new password hash.</param>
    /// <param name="newSalt">The new salt.</param>
    public void UpdatePassword(string newHash, string newSalt)
    {
        if (string.IsNullOrWhiteSpace(newHash) || string.IsNullOrWhiteSpace(newSalt))
        {
            throw new BusinessRuleValidationException("User.InvalidCredentials", "New password hash and salt cannot be empty.");
        }

        PasswordHash = newHash;
        PasswordSalt = newSalt;
    }

    /// <summary>
    /// Unlocks a locked out user account and restores it to active status.
    /// </summary>
    public void Unlock()
    {
        Status = UserStatus.Active;
        FailedLoginAttempts = 0;
        LockoutEndUtc = null;
    }

    /// <summary>
    /// Suspends the user account administratively.
    /// </summary>
    public void Suspend()
    {
        Status = UserStatus.Suspended;
    }

    /// <summary>
    /// Activates the user account.
    /// </summary>
    public void Activate()
    {
        Status = UserStatus.Active;
        LockoutEndUtc = null;
    }

    /// <summary>
    /// Assigns a security role to the user.
    /// </summary>
    /// <param name="roleId">The role to grant.</param>
    public void AssignRole(RoleId roleId)
    {
        if (_roles.TrueForAll(r => r.RoleId != roleId))
        {
            _roles.Add(new UserRole(Id, roleId));
        }
    }

    /// <summary>
    /// Revokes an assigned security role.
    /// </summary>
    /// <param name="roleId">The role to revoke.</param>
    public void RemoveRole(RoleId roleId)
    {
        _ = _roles.RemoveAll(r => r.RoleId == roleId);
    }

    /// <summary>
    /// Adds a fine-grained claim to the user profile.
    /// </summary>
    /// <param name="type">The claim type.</param>
    /// <param name="value">The claim value.</param>
    public void AddClaim(string type, string value)
    {
        if (_claims.TrueForAll(c => c.Type != type || c.Value != value))
        {
            _claims.Add(new UserClaim(Id, type, value));
        }
    }

    /// <summary>
    /// Removes a claim type from the user profile.
    /// </summary>
    /// <param name="type">The claim type to remove.</param>
    public void RemoveClaim(string type)
    {
        _ = _claims.RemoveAll(c => c.Type == type);
    }
}
