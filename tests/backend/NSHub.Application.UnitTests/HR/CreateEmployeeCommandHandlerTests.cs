// <copyright file="CreateEmployeeCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.HR;

using Moq;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.Employees.Commands.CreateEmployee;
using NSHub.Domain.Common;
using NSHub.Domain.Entities;
using NSHub.Domain.Enums;

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
    public async Task Handle_WhenEmailExists_ShouldReturnConflictError()
    {
        // Arrange
        var command = new CreateEmployeeCommand(
            "Mario",
            "Rossi",
            "mario@openx.ch",
            "Engineering",
            42.0m,
            StatutoryWeeklyLimit.Hours45,
            Oll1Regime.StandardRecord,
            LanguageCode.It);

        _ = employeeRepositoryMock.Setup(r => r.GetByEmailAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Employee(Guid.NewGuid(), "Mario", "Rossi", "mario@openx.ch", "Engineering", 42.0m, StatutoryWeeklyLimit.Hours45, Oll1Regime.StandardRecord, LanguageCode.It));

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("Employee.EmailExists");
        employeeRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task Handle_WithValidRequest_ShouldCreateEmployeeAndReturnDto()
    {
        // Arrange
        var command = new CreateEmployeeCommand(
            "Mario",
            "Rossi",
            "mario@openx.ch",
            "Engineering",
            42.0m,
            StatutoryWeeklyLimit.Hours45,
            Oll1Regime.StandardRecord,
            LanguageCode.It);

        _ = employeeRepositoryMock.Setup(r => r.GetByEmailAsync(command.Email, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Employee?)null);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.Email.Should().Be(command.Email);
        _ = result.Value.FirstName.Should().Be(command.FirstName);
        _ = result.Value.LastName.Should().Be(command.LastName);
        employeeRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
