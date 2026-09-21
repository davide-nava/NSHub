// <copyright file="UserTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Identity;

using NSHub.Domain.Exceptions;
using NSHub.Domain.Identity.Entities;
using NSHub.Domain.Identity.Enums;
using NSHub.Domain.Identity.ValueObjects;

public class UserTests
{
    [Fact]
    public void Constructor_WithValidArguments_ShouldInitializeUserSuccessfully()
    {
        // Arrange
        var userId = UserId.New();
        const string email = "admin@nshub.com";
        const string hash = "hashed_pw";
        const string salt = "salt_123";
        const string first = "John";
        const string last = "Doe";

        // Act
        var user = new User(userId, email, hash, salt, first, last);

        // Assert
        _ = user.Id.Should().Be(userId);
        _ = user.Email.Should().Be(email);
        _ = user.FirstName.Should().Be(first);
        _ = user.LastName.Should().Be(last);
        _ = user.Status.Should().Be(UserStatus.Active);
        _ = user.FailedLoginAttempts.Should().Be(0);
        _ = user.LockoutEndUtc.Should().BeNull();
        _ = user.Roles.Should().BeEmpty();
    }

    [Fact]
    public void Constructor_WithEmptyEmail_ShouldThrowBusinessRuleValidationException()
    {
        // Act
        var act = () => new User(UserId.New(), "", "hash", "salt", "John", "Doe");

        // Assert
        _ = act.Should().Throw<BusinessRuleValidationException>()
            .WithMessage("*email*");
    }

    [Fact]
    public void RecordFailedLoginAttempt_WhenThresholdReached_ShouldLockoutUser()
    {
        // Arrange
        var user = new User(UserId.New(), "user@nshub.com", "hash", "salt", "Jane", "Smith");
        const int maxAttempts = 3;
        var lockoutDuration = TimeSpan.FromMinutes(15);

        // Act
        user.RecordFailedLoginAttempt(maxAttempts, lockoutDuration);
        user.RecordFailedLoginAttempt(maxAttempts, lockoutDuration);
        user.RecordFailedLoginAttempt(maxAttempts, lockoutDuration);

        // Assert
        _ = user.FailedLoginAttempts.Should().Be(3);
        _ = user.Status.Should().Be(UserStatus.LockedOut);
        _ = user.LockoutEndUtc.Should().NotBeNull();
        _ = user.LockoutEndUtc.Should().BeAfter(DateTime.UtcNow);
    }

    [Fact]
    public void RecordSuccessfulLogin_ShouldResetFailedAttemptsAndClearLockout()
    {
        // Arrange
        var user = new User(UserId.New(), "user@nshub.com", "hash", "salt", "Jane", "Smith");
        user.RecordFailedLoginAttempt(5, TimeSpan.FromMinutes(15));

        // Act
        user.RecordSuccessfulLogin();

        // Assert
        _ = user.FailedLoginAttempts.Should().Be(0);
        _ = user.LockoutEndUtc.Should().BeNull();
    }

    [Fact]
    public void AssignRole_WhenRoleNotAssigned_ShouldAddRole()
    {
        // Arrange
        var user = new User(UserId.New(), "user@nshub.com", "hash", "salt", "Jane", "Smith");
        var roleId = RoleId.New();

        // Act
        user.AssignRole(roleId);

        // Assert
        _ = user.Roles.Should().HaveCount(1);
        _ = user.Roles.First().RoleId.Should().Be(roleId);
    }

    [Fact]
    public void RemoveRole_WhenRoleAssigned_ShouldRemoveRole()
    {
        // Arrange
        var user = new User(UserId.New(), "user@nshub.com", "hash", "salt", "Jane", "Smith");
        var roleId = RoleId.New();
        user.AssignRole(roleId);

        // Act
        user.RemoveRole(roleId);

        // Assert
        _ = user.Roles.Should().BeEmpty();
    }
}
