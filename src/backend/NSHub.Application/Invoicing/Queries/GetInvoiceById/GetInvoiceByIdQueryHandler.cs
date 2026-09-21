// <copyright file="GetInvoiceByIdQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Queries.GetInvoiceById;

using MediatR;
using NSHub.Application.Invoicing.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Invoicing.Repositories;
using NSHub.Domain.Invoicing.ValueObjects;

/// <summary>
/// Handler for <see cref="GetInvoiceByIdQuery"/>.
/// </summary>
public sealed class GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository) : IRequestHandler<GetInvoiceByIdQuery, Result<InvoiceDto>>
{
    public async Task<Result<InvoiceDto>> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var invoice = await invoiceRepository.GetByIdAsync(new InvoiceId(request.Id), cancellationToken);
        if (invoice is null)
        {
            return Result<InvoiceDto>.Failure(Error.NotFound("Invoice.NotFound", $"Invoice with ID '{request.Id}' was not found."));
        }

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
}
