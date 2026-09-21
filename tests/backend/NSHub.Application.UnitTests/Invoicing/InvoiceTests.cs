// <copyright file="InvoiceTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Invoicing;

using NSHub.Domain.Exceptions;
using NSHub.Domain.Invoicing.Entities;
using NSHub.Domain.Invoicing.Enums;
using NSHub.Domain.Invoicing.ValueObjects;

public class InvoiceTests
{
    [Fact]
    public void AddLine_ToDraftInvoice_ShouldCalculateNetVatAndGrossTotals()
    {
        // Arrange
        var invoice = new Invoice(InvoiceId.New(), CustomerId.New(), PaymentTerm.Net30);

        // Act
        _ = invoice.AddLine("Consulting services", quantity: 10, unitPrice: 100m, discountPercentage: 10m, vatRate: 8.1m);

        // Assert
        // LineTotalNet: 10 * 100 * 0.9 = 900.00
        // LineTotalVat: 900 * 0.081 = 72.90
        // LineTotalGross: 972.90
        _ = invoice.TotalNet.Should().Be(900.00m);
        _ = invoice.TotalVat.Should().Be(72.90m);
        _ = invoice.TotalGross.Should().Be(972.90m);
    }

    [Fact]
    public void AddLine_WhenInvoiceIssued_ShouldThrowInvoiceAlreadyIssuedException()
    {
        // Arrange
        var invoice = new Invoice(InvoiceId.New(), CustomerId.New(), PaymentTerm.Net30);
        _ = invoice.AddLine("Item 1", 1, 50m, 0, 8.1m);
        invoice.Issue("INV-2026-00001", DateTime.UtcNow);

        // Act
        var act = () => invoice.AddLine("Item 2", 1, 20m, 0, 8.1m);

        // Assert
        _ = act.Should().Throw<InvoiceAlreadyIssuedException>();
    }

    [Fact]
    public void Issue_WithoutLines_ShouldThrowBusinessRuleValidationException()
    {
        // Arrange
        var invoice = new Invoice(InvoiceId.New(), CustomerId.New(), PaymentTerm.Net30);

        // Act
        var act = () => invoice.Issue("INV-2026-00001", DateTime.UtcNow);

        // Assert
        _ = act.Should().Throw<BusinessRuleValidationException>()
            .WithMessage("*without lines*");
    }

    [Fact]
    public void Issue_WithLines_ShouldAssignInvoiceNumberAndLockInvoice()
    {
        // Arrange
        var invoice = new Invoice(InvoiceId.New(), CustomerId.New(), PaymentTerm.Net30);
        _ = invoice.AddLine("Item 1", 2, 100m, 0, 8.1m);
        var issueDate = new DateTime(2026, 9, 21, 10, 0, 0, DateTimeKind.Utc);

        // Act
        invoice.Issue("INV-2026-00001", issueDate);

        // Assert
        _ = invoice.Status.Should().Be(InvoiceStatus.Issued);
        _ = invoice.InvoiceNumber.Should().Be("INV-2026-00001");
        _ = invoice.IssueDateUtc.Should().Be(issueDate);
        _ = invoice.DueDateUtc.Should().Be(issueDate.AddDays(30));
    }

    [Fact]
    public void MarkPaid_WhenIssued_ShouldTransitionToPaid()
    {
        // Arrange
        var invoice = new Invoice(InvoiceId.New(), CustomerId.New(), PaymentTerm.Net30);
        _ = invoice.AddLine("Item 1", 1, 100m, 0, 8.1m);
        invoice.Issue("INV-2026-00001", DateTime.UtcNow);

        // Act
        invoice.MarkPaid();

        // Assert
        _ = invoice.Status.Should().Be(InvoiceStatus.Paid);
    }

    [Fact]
    public void Cancel_WhenPaid_ShouldThrowInvalidStateTransitionException()
    {
        // Arrange
        var invoice = new Invoice(InvoiceId.New(), CustomerId.New(), PaymentTerm.Net30);
        _ = invoice.AddLine("Item 1", 1, 100m, 0, 8.1m);
        invoice.Issue("INV-2026-00001", DateTime.UtcNow);
        invoice.MarkPaid();

        // Act
        var act = () => invoice.Cancel();

        // Assert
        _ = act.Should().Throw<InvalidStateTransitionException>()
            .WithMessage("*Paid invoices cannot be cancelled directly*");
    }
}
