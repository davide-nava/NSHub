// <copyright file="CorrectTimeEntryCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Features.TimeTracking.Commands.CorrectTimeEntry;
using NSHub.Application.Features.TimeTracking.Repositories;
using NSHub.Domain.Entities.TimeAttendance;
using NSHub.Domain.Enums;
using Xunit;

namespace NSHub.Application.UnitTests.TimeAttendance;

public class CorrectTimeEntryCommandHandlerTests
{
    private readonly Mock<ITimeEntryRepository> timeEntryRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly Mock<IDateTimeService> dateTimeServiceMock = new();
    private readonly CorrectTimeEntryCommandHandler handler;

    public CorrectTimeEntryCommandHandlerTests()
    {
        _ = dateTimeServiceMock.Setup(d => d.UtcNow)
            .Returns(new DateTime(2026, 9, 27, 18, 0, 0, DateTimeKind.Utc));

        handler = new CorrectTimeEntryCommandHandler(
            timeEntryRepositoryMock.Object,
            unitOfWorkMock.Object,
            dateTimeServiceMock.Object);
    }

    [Fact]
    public async Task Handle_WhenTimeEntryNotFound_ShouldReturnFailureResult()
    {
        // Arrange
        var timeEntryId = Guid.NewGuid();
        var operatorId = Guid.NewGuid();
        var command = new CorrectTimeEntryCommand(
            timeEntryId,
            operatorId,
            new DateTime(2026, 9, 27, 8, 0, 0, DateTimeKind.Utc),
            new DateTime(2026, 9, 27, 17, 0, 0, DateTimeKind.Utc),
            60,
            "Forgot to clock out");

        _ = timeEntryRepositoryMock.Setup(r => r.GetByIdAsync(timeEntryId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((TimeEntry?)null);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Errors.Should().Contain($"Time entry with ID '{timeEntryId}' was not found.");
        timeEntryRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TimeEntry>(), It.IsAny<CancellationToken>()), Times.Never);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task Handle_WithValidCorrection_ShouldUpdateEntryAndReturnSuccess()
    {
        // Arrange
        var timeEntryId = Guid.NewGuid();
        var employeeId = Guid.NewGuid();
        var operatorId = Guid.NewGuid();
        var existingEntry = new TimeEntry
        {
            Id = timeEntryId,
            EmployeeId = employeeId,
            WorkDate = new DateTime(2026, 9, 27, 0, 0, 0, DateTimeKind.Utc),
            StartTime = TimeSpan.FromHours(8),
            Status = TimeEntryStatus.Open,
            DateInsert = new DateTime(2026, 9, 27, 8, 0, 0, DateTimeKind.Utc),
        };

        var newClockIn = new DateTime(2026, 9, 27, 8, 30, 0, DateTimeKind.Utc);
        var newClockOut = new DateTime(2026, 9, 27, 17, 30, 0, DateTimeKind.Utc);
        var command = new CorrectTimeEntryCommand(
            timeEntryId,
            operatorId,
            newClockIn,
            newClockOut,
            30,
            "Badge failure at morning gate");

        _ = timeEntryRepositoryMock.Setup(r => r.GetByIdAsync(timeEntryId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingEntry);
        _ = timeEntryRepositoryMock.Setup(r => r.UpdateAsync(It.IsAny<TimeEntry>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _ = unitOfWorkMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.Should().NotBeNull();
        _ = result.Value.Status.Should().Be(TimeEntryStatus.Corrected);
        _ = existingEntry.Status.Should().Be(TimeEntryStatus.Corrected);
        _ = existingEntry.StartTime.Should().Be(newClockIn.TimeOfDay);
        _ = existingEntry.EndTime.Should().Be(newClockOut.TimeOfDay);
        _ = existingEntry.BreakDurationMinutes.Should().Be(30);
        _ = existingEntry.TotalHoursWorked.Should().Be(8.50m); // 9h - 0.5h = 8.5h
        timeEntryRepositoryMock.Verify(r => r.UpdateAsync(existingEntry, It.IsAny<CancellationToken>()), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
