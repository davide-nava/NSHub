// <copyright file="ResolveTicketCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Tickets;

using Moq;
using NSHub.Application.Tickets.Commands.ResolveTicket;
using NSHub.Domain.Common;
using NSHub.Domain.Tickets.Entities;
using NSHub.Domain.Tickets.Enums;
using NSHub.Domain.Tickets.Repositories;
using NSHub.Domain.Tickets.ValueObjects;

public class ResolveTicketCommandHandlerTests
{
    private readonly Mock<ITicketRepository> ticketRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly ResolveTicketCommandHandler handler;

    public ResolveTicketCommandHandlerTests()
    {
        handler = new ResolveTicketCommandHandler(
            ticketRepositoryMock.Object,
            unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_WhenTicketNotFound_ShouldReturnNotFoundError()
    {
        // Arrange
        var ticketId = Guid.NewGuid();
        var command = new ResolveTicketCommand(ticketId, "Fixed database connection.");

        _ = ticketRepositoryMock.Setup(r => r.GetByIdAsync(new TicketId(ticketId), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Ticket?)null);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("Ticket.NotFound");
    }

    [Fact]
    public async Task Handle_WithValidNotes_ShouldResolveTicket()
    {
        // Arrange
        var ticketId = Guid.NewGuid();
        var ticket = new Ticket(new TicketId(ticketId), "Network slow", "Latency spike", Guid.NewGuid(), TicketPriority.High);
        var command = new ResolveTicketCommand(ticketId, "Upgraded bandwidth allocation.");

        _ = ticketRepositoryMock.Setup(r => r.GetByIdAsync(new TicketId(ticketId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(ticket);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.Status.Should().Be(TicketStatus.Resolved.ToString());
        _ = result.Value.ResolutionNotes.Should().Be("Upgraded bandwidth allocation.");
        ticketRepositoryMock.Verify(r => r.Update(ticket), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
