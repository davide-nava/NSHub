// <copyright file="CreateEmployeeCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Features.Employees.Commands.CreateEmployee;
using NSHub.Application.Features.Employees.Repositories;
using NSHub.Domain.Entities.TimeAttendance;
using NSHub.Domain.Enums;
using Xunit;

namespace NSHub.Application.UnitTests.HR;

public class CreateEmployeeCommandHandlerTests
{
    private readonly Mock<IEmployeeRepository> employeeRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly CreateEmployeeCommandHandler handler;

    public CreateEmployeeCommandHandlerTests()
    {
        handler = new CreateEmployeeCommandHandler(
            employeeRepositoryMock.Object,
            unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_WhenEmailExists_ShouldReturnFailureResult()
    {
        // Arrange
        var command = new CreateEmployeeCommand(
            "Mario",
            "Rossi",
            "mario@navasoft.ch",
            "Engineering",
            42.0m,
            StatutoryWeeklyLimit.Hours45,
            Oll1RegimeType.StandardArt73,
            "it");

        _ = employeeRepositoryMock.Setup(r => r.EmailExistsAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Errors.Should().Contain("An employee with the specified email already exists.");
        employeeRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()), Times.Never);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task Handle_WithValidCommand_ShouldCreateEmployeeAndReturnSuccess()
    {
        // Arrange
        var command = new CreateEmployeeCommand(
            "Mario",
            "Rossi",
            "mario@navasoft.ch",
            "Engineering",
            42.0m,
            StatutoryWeeklyLimit.Hours45,
            Oll1RegimeType.StandardArt73,
            "it");

        _ = employeeRepositoryMock.Setup(r => r.EmailExistsAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        _ = employeeRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Employee e, CancellationToken _) => e);

        _ = unitOfWorkMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.Should().NotBeNull();
        _ = result.Value.Email.Should().Be(command.Email);
        _ = result.Value.FirstName.Should().Be(command.FirstName);
        _ = result.Value.LastName.Should().Be(command.LastName);
        employeeRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
