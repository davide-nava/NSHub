// <copyright file="ClockInCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.TimeAttendance;

using Microsoft.Extensions.Localization;
using Moq;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.TimeTracking.Commands.ClockIn;
using NSHub.Application.Resources;
using NSHub.Domain.Common;
using NSHub.Domain.Entities;
using NSHub.Domain.Enums;

public class ClockInCommandHandlerTests
{
    private readonly Mock<ITimeEntryRepository> timeEntryRepositoryMock = new();
    private readonly Mock<IEmployeeRepository> employeeRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly Mock<IDateTimeProvider> dateTimeProviderMock = new();
    private readonly Mock<IStringLocalizer<ValidationMessages>> localizerMock = new();
    private readonly ClockInCommandHandler handler;

    public ClockInCommandHandlerTests()
    {
        _ = localizerMock.Setup(l => l[It.IsAny<string>()])
            .Returns((string key) => new LocalizedString(key, key));

        _ = dateTimeProviderMock.Setup(d => d.UtcNow).Returns(new DateTime(2026, 9, 21, 8, 0, 0, DateTimeKind.Utc));

        handler = new ClockInCommandHandler(
            timeEntryRepositoryMock.Object,
            employeeRepositoryMock.Object,
            unitOfWorkMock.Object,
            dateTimeProviderMock.Object,
            localizerMock.Object);
    }

    [Fact]
    public async Task Handle_WhenEmployeeNotFound_ShouldReturnNotFoundError()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var command = new ClockInCommand(employeeId);
        _ = employeeRepositoryMock.Setup(r => r.GetByIdAsync(employeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Employee?)null);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("Employee.NotFound");
    }

    [Fact]
    public async Task Handle_WhenActiveShiftAlreadyExists_ShouldReturnConflictError()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var command = new ClockInCommand(employeeId);
        var employee = new Employee(employeeId, "Mario", "Rossi", "mario@openx.ch", "IT", 40.0m, StatutoryWeeklyLimit.Hours45, Oll1Regime.StandardRecord, LanguageCode.It);
        var activeEntry = new TimeEntry(Guid.NewGuid(), employeeId, DateTime.UtcNow.AddHours(-2));

        _ = employeeRepositoryMock.Setup(r => r.GetByIdAsync(employeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(employee);
        _ = timeEntryRepositoryMock.Setup(r => r.GetActiveEntryForEmployeeAsync(employeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(activeEntry);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("TimeEntry.ActiveExists");
    }
}
