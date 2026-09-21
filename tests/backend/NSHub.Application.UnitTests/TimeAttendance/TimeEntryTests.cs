// <copyright file="TimeEntryTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.TimeAttendance;

using NSHub.Domain.Entities;
using NSHub.Domain.Enums;

public class TimeEntryTests
{
    [Fact]
    public void ClockOut_WithClockOutPrecedingClockIn_ShouldReturnFailure()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var clockIn = DateTime.UtcNow;
        var entry = new TimeEntry(Guid.NewGuid(), employeeId, clockIn);

        // Act
        var result = entry.ClockOut(clockIn.AddHours(-1), 0);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("TimeEntry.InvalidClockOut");
    }

    [Fact]
    public void ClockOut_WithBreakExceedingShift_ShouldReturnFailure()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var clockIn = DateTime.UtcNow;
        var clockOut = clockIn.AddHours(4); // 240 mins
        var entry = new TimeEntry(Guid.NewGuid(), employeeId, clockIn);

        // Act
        var result = entry.ClockOut(clockOut, breakDurationMinutes: 300);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("TimeEntry.BreakExceedsDuration");
    }

    [Fact]
    public void ClockOut_WithValidParameters_ShouldCompleteShift()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var clockIn = DateTime.UtcNow.AddHours(-8);
        var clockOut = DateTime.UtcNow;
        var entry = new TimeEntry(Guid.NewGuid(), employeeId, clockIn);

        // Act
        var result = entry.ClockOut(clockOut, breakDurationMinutes: 30);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = entry.Status.Should().Be(TimeEntryStatus.Completed);
        _ = entry.ClockOutUtc.Should().Be(clockOut);
        _ = entry.BreakDurationMinutes.Should().Be(30);
    }

    [Fact]
    public void ApplyCorrection_WithoutMandatoryReason_ShouldReturnFailure()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var entry = new TimeEntry(Guid.NewGuid(), employeeId, DateTime.UtcNow.AddHours(-8));

        // Act
        var result = entry.ApplyCorrection(
            Guid.NewGuid(),
            DateTime.UtcNow.AddHours(-9),
            DateTime.UtcNow,
            30,
            mandatoryReason: "");

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("TimeCorrection.ReasonRequired");
    }

    [Fact]
    public void ApplyCorrection_WithValidData_ShouldCreateAuditRecordAndApproveEntry()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var originalClockIn = DateTime.UtcNow.AddHours(-8);
        var entry = new TimeEntry(Guid.NewGuid(), employeeId, originalClockIn);

        var operatorId = Guid.NewGuid();
        var newClockIn = originalClockIn.AddHours(-1);
        var newClockOut = DateTime.UtcNow;

        // Act
        var result = entry.ApplyCorrection(
            operatorId,
            newClockIn,
            newClockOut,
            newBreakMinutes: 45,
            mandatoryReason: "Employee forgot to punch in on arrival.",
            ipAddress: "192.168.1.100");

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = entry.ClockInUtc.Should().Be(newClockIn);
        _ = entry.ClockOutUtc.Should().Be(newClockOut);
        _ = entry.BreakDurationMinutes.Should().Be(45);
        _ = entry.Status.Should().Be(TimeEntryStatus.Approved);
        _ = entry.AuditTrail.Should().HaveCount(1);
        _ = entry.AuditTrail.First().MandatoryReason.Should().Be("Employee forgot to punch in on arrival.");
    }
}
