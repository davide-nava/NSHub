// <copyright file="ClockInCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Features.Employees.Repositories;
using NSHub.Application.Features.TimeTracking.Commands.ClockIn;
using NSHub.Application.Features.TimeTracking.Repositories;
using NSHub.Domain.Entities.TimeAttendance;
using NSHub.Domain.Enums;
using Xunit;

namespace NSHub.Application.UnitTests.TimeAttendance;

public class ClockInCommandHandlerTests
{
    private readonly Mock<IEmployeeRepository> employeeRepositoryMock = new();
    private readonly Mock<ITimeEntryRepository> timeEntryRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly Mock<IDateTimeService> dateTimeServiceMock = new();
    private readonly ClockInCommandHandler handler;

    public ClockInCommandHandlerTests()
    {
        _ = dateTimeServiceMock.Setup(d => d.UtcNow)
            .Returns(new DateTime(2026, 9, 27, 8, 0, 0, DateTimeKind.Utc));

        handler = new ClockInCommandHandler(
            employeeRepositoryMock.Object,
            timeEntryRepositoryMock.Object,
            unitOfWorkMock.Object,
            dateTimeServiceMock.Object);
    }

    [Fact]
    public async Task Handle_WhenEmployeeNotFound_ShouldReturnFailureResult()
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
        _ = result.Errors.Should().Contain($"Employee with ID '{employeeId}' was not found.");
        timeEntryRepositoryMock.Verify(r => r.AddAsync(It.IsAny<TimeEntry>(), It.IsAny<CancellationToken>()), Times.Never);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task Handle_WhenActiveShiftAlreadyExists_ShouldReturnFailureResult()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var command = new ClockInCommand(employeeId);
        var employee = new Employee
        {
            Id = employeeId,
            FirstName = "Mario",
            LastName = "Rossi",
            Email = "mario@navasoft.ch",
            IsActive = true,
        };
        var activeEntry = new TimeEntry
        {
            Id = Guid.NewGuid(),
            EmployeeId = employeeId,
            WorkDate = new DateTime(2026, 9, 27, 0, 0, 0, DateTimeKind.Utc),
            StartTime = TimeSpan.FromHours(8),
            Status = TimeEntryStatus.Open,
        };

        _ = employeeRepositoryMock.Setup(r => r.GetByIdAsync(employeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(employee);
        _ = timeEntryRepositoryMock.Setup(r => r.GetActiveEntryAsync(employeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(activeEntry);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Errors.Should().Contain("An active shift already exists for this employee.");
        timeEntryRepositoryMock.Verify(r => r.AddAsync(It.IsAny<TimeEntry>(), It.IsAny<CancellationToken>()), Times.Never);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task Handle_WithValidCommand_ShouldCreateTimeEntryAndReturnSuccess()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var command = new ClockInCommand(employeeId, Notes: "Starting morning shift");
        var employee = new Employee
        {
            Id = employeeId,
            FirstName = "Mario",
            LastName = "Rossi",
            Email = "mario@navasoft.ch",
            IsActive = true,
        };

        _ = employeeRepositoryMock.Setup(r => r.GetByIdAsync(employeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(employee);
        _ = timeEntryRepositoryMock.Setup(r => r.GetActiveEntryAsync(employeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((TimeEntry?)null);
        _ = timeEntryRepositoryMock.Setup(r => r.AddAsync(It.IsAny<TimeEntry>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((TimeEntry entry, CancellationToken _) => entry);
        _ = unitOfWorkMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.Should().NotBeNull();
        _ = result.Value.EmployeeId.Should().Be(employeeId);
        _ = result.Value.Status.Should().Be(TimeEntryStatus.Open);
        timeEntryRepositoryMock.Verify(r => r.AddAsync(It.IsAny<TimeEntry>(), It.IsAny<CancellationToken>()), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
