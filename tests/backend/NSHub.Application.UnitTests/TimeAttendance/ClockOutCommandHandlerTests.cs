// <copyright file="ClockOutCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Features.TimeTracking.Commands.ClockOut;
using NSHub.Application.Features.TimeTracking.Repositories;
using NSHub.Domain.Entities.TimeAttendance;
using NSHub.Domain.Enums;
using Xunit;

namespace NSHub.Application.UnitTests.TimeAttendance;

public class ClockOutCommandHandlerTests
{
    private readonly Mock<ITimeEntryRepository> timeEntryRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly Mock<IDateTimeService> dateTimeServiceMock = new();
    private readonly ClockOutCommandHandler handler;

    public ClockOutCommandHandlerTests()
    {
        _ = dateTimeServiceMock.Setup(d => d.UtcNow)
            .Returns(new DateTime(2026, 9, 27, 17, 0, 0, DateTimeKind.Utc));

        handler = new ClockOutCommandHandler(
            timeEntryRepositoryMock.Object,
            unitOfWorkMock.Object,
            dateTimeServiceMock.Object);
    }

    [Fact]
    public async Task Handle_WhenNoActiveShift_ShouldReturnFailureResult()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var command = new ClockOutCommand(employeeId, 30);

        _ = timeEntryRepositoryMock.Setup(r => r.GetActiveEntryAsync(employeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((TimeEntry?)null);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Errors.Should().Contain("No active shift found for this employee.");
        timeEntryRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TimeEntry>(), It.IsAny<CancellationToken>()), Times.Never);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task Handle_WithActiveShift_ShouldCloseShiftAndReturnSuccess()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var command = new ClockOutCommand(employeeId, BreakDurationMinutes: 60);
        var activeEntry = new TimeEntry
        {
            Id = Guid.NewGuid(),
            EmployeeId = employeeId,
            WorkDate = new DateTime(2026, 9, 27, 0, 0, 0, DateTimeKind.Utc),
            StartTime = TimeSpan.FromHours(8), // Started at 08:00
            Status = TimeEntryStatus.Open,
            DateInsert = new DateTime(2026, 9, 27, 8, 0, 0, DateTimeKind.Utc),
        };

        _ = timeEntryRepositoryMock.Setup(r => r.GetActiveEntryAsync(employeeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(activeEntry);
        _ = timeEntryRepositoryMock.Setup(r => r.UpdateAsync(It.IsAny<TimeEntry>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _ = unitOfWorkMock.Setup(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.Should().NotBeNull();
        _ = result.Value.Status.Should().Be(TimeEntryStatus.Closed);
        _ = activeEntry.BreakDurationMinutes.Should().Be(60);
        _ = activeEntry.TotalHoursWorked.Should().Be(8.00m); // 17:00 - 08:00 = 9h - 1h break = 8.00h
        timeEntryRepositoryMock.Verify(r => r.UpdateAsync(activeEntry, It.IsAny<CancellationToken>()), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
