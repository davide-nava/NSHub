// <copyright file="RegisterUserCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Identity;

using Moq;
using NSHub.Application.Identity.Commands.RegisterUser;
using NSHub.Domain.Common;
using NSHub.Domain.Identity.Entities;
using NSHub.Domain.Identity.Repositories;
using NSHub.Domain.Identity.Services;

public class RegisterUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> userRepositoryMock = new();
    private readonly Mock<IPasswordHasher> passwordHasherMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly RegisterUserCommandHandler handler;

    public RegisterUserCommandHandlerTests()
    {
        handler = new RegisterUserCommandHandler(
            userRepositoryMock.Object,
            passwordHasherMock.Object,
            unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_WhenEmailAlreadyExists_ShouldReturnConflictError()
    {
        // Arrange
        var command = new RegisterUserCommand("existing@nshub.com", "Password123!", "John", "Doe");
        _ = userRepositoryMock.Setup(r => r.ExistsByEmailAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("User.EmailExists");
        userRepositoryMock.Verify(r => r.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task Handle_WithValidCommand_ShouldCreateUserAndReturnSuccess()
    {
        // Arrange
        var command = new RegisterUserCommand("newuser@nshub.com", "Password123!", "Alice", "Wonder");
        _ = userRepositoryMock.Setup(r => r.ExistsByEmailAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);
        _ = passwordHasherMock.Setup(h => h.HashPassword(command.Password))
            .Returns(("hashed_secret", "salt_value"));

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.Email.Should().Be(command.Email);
        _ = result.Value.FirstName.Should().Be(command.FirstName);
        _ = result.Value.LastName.Should().Be(command.LastName);
        userRepositoryMock.Verify(r => r.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
