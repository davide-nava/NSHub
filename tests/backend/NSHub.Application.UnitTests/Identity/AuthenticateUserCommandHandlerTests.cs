// <copyright file="AuthenticateUserCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Identity;

using Moq;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Identity.Commands.AuthenticateUser;
using NSHub.Domain.Common;
using NSHub.Domain.Identity.Entities;
using NSHub.Domain.Identity.Repositories;
using NSHub.Domain.Identity.Services;
using NSHub.Domain.Identity.ValueObjects;

public class AuthenticateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> userRepositoryMock = new();
    private readonly Mock<IPasswordHasher> passwordHasherMock = new();
    private readonly Mock<IJwtTokenService> jwtTokenServiceMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly AuthenticateUserCommandHandler handler;

    public AuthenticateUserCommandHandlerTests()
    {
        handler = new AuthenticateUserCommandHandler(
            userRepositoryMock.Object,
            passwordHasherMock.Object,
            jwtTokenServiceMock.Object,
            unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_WhenUserNotFound_ShouldReturnUnauthorized()
    {
        // Arrange
        var command = new AuthenticateUserCommand("nonexistent@nshub.com", "Password123!");
        _ = userRepositoryMock.Setup(r => r.GetByEmailAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("Auth.InvalidCredentials");
    }

    [Fact]
    public async Task Handle_WhenAccountLockedOut_ShouldReturnForbidden()
    {
        // Arrange
        var command = new AuthenticateUserCommand("locked@nshub.com", "Password123!");
        var user = new User(UserId.New(), command.Email, "hash", "salt", "Locked", "User");
        for (var i = 0; i < 5; i++)
        {
            user.RecordFailedLoginAttempt(5, TimeSpan.FromMinutes(30));
        }

        _ = userRepositoryMock.Setup(r => r.GetByEmailAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("Auth.AccountLocked");
    }

    [Fact]
    public async Task Handle_WithValidCredentials_ShouldReturnTokenAndUserDto()
    {
        // Arrange
        var command = new AuthenticateUserCommand("active@nshub.com", "Password123!");
        var user = new User(UserId.New(), command.Email, "correct_hash", "correct_salt", "Active", "User");

        _ = userRepositoryMock.Setup(r => r.GetByEmailAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);
        _ = passwordHasherMock.Setup(h => h.VerifyPassword(command.Password, "correct_hash", "correct_salt"))
            .Returns(true);
        _ = jwtTokenServiceMock.Setup(j => j.GenerateUserToken(user, It.IsAny<IEnumerable<string>>()))
            .Returns("fake_jwt_token_sample");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.Token.Should().Be("fake_jwt_token_sample");
        _ = result.Value.User.Email.Should().Be(command.Email);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
