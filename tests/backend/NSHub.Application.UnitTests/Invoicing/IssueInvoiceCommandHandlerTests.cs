// <copyright file="IssueInvoiceCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Invoicing;

using Moq;
using NSHub.Application.Invoicing.Commands.IssueInvoice;
using NSHub.Domain.Common;
using NSHub.Domain.Invoicing.Entities;
using NSHub.Domain.Invoicing.Enums;
using NSHub.Domain.Invoicing.Repositories;
using NSHub.Domain.Invoicing.Services;
using NSHub.Domain.Invoicing.ValueObjects;

public class IssueInvoiceCommandHandlerTests
{
    private readonly Mock<IInvoiceRepository> invoiceRepositoryMock = new();
    private readonly Mock<IInvoiceNumberSequenceService> sequenceServiceMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly IssueInvoiceCommandHandler handler;

    public IssueInvoiceCommandHandlerTests()
    {
        handler = new IssueInvoiceCommandHandler(
            invoiceRepositoryMock.Object,
            sequenceServiceMock.Object,
            unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_WhenInvoiceNotFound_ShouldReturnNotFound()
    {
        // Arrange
        var invoiceId = Guid.NewGuid();
        _ = invoiceRepositoryMock.Setup(r => r.GetByIdAsync(new InvoiceId(invoiceId), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Invoice?)null);

        // Act
        var result = await handler.Handle(new IssueInvoiceCommand(invoiceId), CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("Invoice.NotFound");
    }

    [Fact]
    public async Task Handle_WithValidDraft_ShouldGenerateSequenceNumberAndIssue()
    {
        // Arrange
        var invoiceId = Guid.NewGuid();
        var invoice = new Invoice(new InvoiceId(invoiceId), CustomerId.New(), PaymentTerm.Net30);
        _ = invoice.AddLine("Hosting fee", 1, 120m, 0, 8.1m);

        _ = invoiceRepositoryMock.Setup(r => r.GetByIdAsync(new InvoiceId(invoiceId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(invoice);
        _ = sequenceServiceMock.Setup(s => s.GetNextInvoiceNumberAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync("INV-2026-00042");

        // Act
        var result = await handler.Handle(new IssueInvoiceCommand(invoiceId), CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.InvoiceNumber.Should().Be("INV-2026-00042");
        _ = result.Value.Status.Should().Be(InvoiceStatus.Issued.ToString());
        invoiceRepositoryMock.Verify(r => r.Update(invoice), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
