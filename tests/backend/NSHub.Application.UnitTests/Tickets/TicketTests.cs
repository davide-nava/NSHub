// <copyright file="TicketTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Tickets;

using NSHub.Domain.Exceptions;
using NSHub.Domain.Tickets.Entities;
using NSHub.Domain.Tickets.Enums;
using NSHub.Domain.Tickets.ValueObjects;

public class TicketTests
{
    [Theory]
    [InlineData(TicketPriority.Critical, 4)]
    [InlineData(TicketPriority.High, 8)]
    [InlineData(TicketPriority.Medium, 24)]
    [InlineData(TicketPriority.Low, 72)]
    public void Constructor_ShouldCalculateSlaDeadlinesBasedOnPriority(TicketPriority priority, int expectedHours)
    {
        // Act
        var ticket = new Ticket(TicketId.New(), "Printer broken", "Network printer offline", Guid.NewGuid(), priority);

        // Assert
        _ = ticket.Sla.MaximumResolutionTime.Should().Be(TimeSpan.FromHours(expectedHours));
        _ = ticket.Sla.ResolutionDeadlineUtc.Should().BeCloseTo(DateTime.UtcNow.AddHours(expectedHours), TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void AssignTechnician_ShouldSetTechnicianAndTransitionToInProgress()
    {
        // Arrange
        var ticket = new Ticket(TicketId.New(), "VPN down", "Cannot reach gateway", Guid.NewGuid(), TicketPriority.High);
        var techId = Guid.NewGuid();

        // Act
        ticket.AssignTechnician(techId);

        // Assert
        _ = ticket.AssignedTechnicianId.Should().Be(techId);
        _ = ticket.Status.Should().Be(TicketStatus.InProgress);
    }

    [Fact]
    public void Resolve_WithoutResolutionNotes_ShouldThrowBusinessRuleValidationException()
    {
        // Arrange
        var ticket = new Ticket(TicketId.New(), "VPN down", "Cannot reach gateway", Guid.NewGuid(), TicketPriority.High);

        // Act
        var act = () => ticket.Resolve("");

        // Assert
        _ = act.Should().Throw<BusinessRuleValidationException>()
            .WithMessage("*Resolution notes are required*");
    }

    [Fact]
    public void Resolve_WithNotes_ShouldSetResolvedStatus()
    {
        // Arrange
        var ticket = new Ticket(TicketId.New(), "VPN down", "Cannot reach gateway", Guid.NewGuid(), TicketPriority.High);

        // Act
        ticket.Resolve("Reset VPN gateway service.");

        // Assert
        _ = ticket.Status.Should().Be(TicketStatus.Resolved);
        _ = ticket.ResolutionNotes.Should().Be("Reset VPN gateway service.");
        _ = ticket.ResolvedAtUtc.Should().NotBeNull();
    }

    [Fact]
    public void Close_WhenResolved_ShouldTransitionToClosed()
    {
        // Arrange
        var ticket = new Ticket(TicketId.New(), "VPN down", "Cannot reach gateway", Guid.NewGuid(), TicketPriority.High);
        ticket.Resolve("Fixed routing.");

        // Act
        ticket.Close();

        // Assert
        _ = ticket.Status.Should().Be(TicketStatus.Closed);
        _ = ticket.ClosedAtUtc.Should().NotBeNull();
    }

    [Fact]
    public void AddComment_WhenClosed_ShouldThrowTicketClosedException()
    {
        // Arrange
        var ticket = new Ticket(TicketId.New(), "VPN down", "Cannot reach gateway", Guid.NewGuid(), TicketPriority.High);
        ticket.Resolve("Fixed routing.");
        ticket.Close();

        // Act
        var act = () => ticket.AddComment(Guid.NewGuid(), "Can I add details?");

        // Assert
        _ = act.Should().Throw<TicketClosedException>();
    }

    [Fact]
    public void AssignTechnician_WhenClosed_ShouldThrowTicketClosedException()
    {
        // Arrange
        var ticket = new Ticket(TicketId.New(), "VPN down", "Cannot reach gateway", Guid.NewGuid(), TicketPriority.High);
        ticket.Resolve("Fixed routing.");
        ticket.Close();

        // Act
        var act = () => ticket.AssignTechnician(Guid.NewGuid());

        // Assert
        _ = act.Should().Throw<TicketClosedException>();
    }
}
