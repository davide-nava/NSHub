// <copyright file="IssueInvoiceCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Commands.IssueInvoice;

using MediatR;
using NSHub.Application.Invoicing.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Exceptions;
using NSHub.Domain.Invoicing.Repositories;
using NSHub.Domain.Invoicing.Services;
using NSHub.Domain.Invoicing.ValueObjects;

/// <summary>
/// Handler for <see cref="IssueInvoiceCommand"/>.
/// </summary>
public sealed class IssueInvoiceCommandHandler(
    IInvoiceRepository invoiceRepository,
    IInvoiceNumberSequenceService sequenceService,
    IUnitOfWork unitOfWork) : IRequestHandler<IssueInvoiceCommand, Result<InvoiceDto>>
{
    public async Task<Result<InvoiceDto>> Handle(IssueInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await invoiceRepository.GetByIdAsync(new InvoiceId(request.InvoiceId), cancellationToken);
        if (invoice is null)
        {
            return Result<InvoiceDto>.Failure(Error.NotFound("Invoice.NotFound", $"Invoice with ID '{request.InvoiceId}' was not found."));
        }

        try
        {
            var now = DateTime.UtcNow;
            var invoiceNumber = await sequenceService.GetNextInvoiceNumberAsync(now.Year, cancellationToken);

            invoice.Issue(invoiceNumber, now);
            invoiceRepository.Update(invoice);
            _ = await unitOfWork.SaveChangesAsync(cancellationToken);

            var linesDto = invoice.Lines.Select(l => new InvoiceLineDto(
                l.Id.Value,
                l.Description,
                l.Quantity,
                l.UnitPrice,
                l.DiscountPercentage,
                l.VatRate,
                l.LineTotalNet,
                l.LineTotalVat,
                l.LineTotalGross)).ToList();

            var dto = new InvoiceDto(
                invoice.Id.Value,
                invoice.CustomerId.Value,
                invoice.InvoiceNumber,
                invoice.Status.ToString(),
                invoice.PaymentTerm.ToString(),
                invoice.IssueDateUtc,
                invoice.DueDateUtc,
                invoice.CreatedAtUtc,
                invoice.TotalNet,
                invoice.TotalVat,
                invoice.TotalGross,
                linesDto);

            return Result<InvoiceDto>.Success(dto);
        }
        catch (DomainException ex)
        {
            return Result<InvoiceDto>.Failure(Error.Conflict("Invoice.IssueFailed", ex.Message));
        }
    }
}
