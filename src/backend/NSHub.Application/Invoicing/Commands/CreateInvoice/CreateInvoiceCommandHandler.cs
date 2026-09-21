// <copyright file="CreateInvoiceCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Commands.CreateInvoice;

using MediatR;
using NSHub.Application.Invoicing.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Invoicing.Entities;
using NSHub.Domain.Invoicing.Repositories;
using NSHub.Domain.Invoicing.ValueObjects;

/// <summary>
/// Handler for <see cref="CreateInvoiceCommand"/>.
/// </summary>
public sealed class CreateInvoiceCommandHandler(
    IInvoiceRepository invoiceRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateInvoiceCommand, Result<InvoiceDto>>
{
    public async Task<Result<InvoiceDto>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = new Invoice(
            InvoiceId.New(),
            new CustomerId(request.CustomerId),
            request.PaymentTerm);

        await invoiceRepository.AddAsync(invoice, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

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
            []);

        return Result<InvoiceDto>.Success(dto);
    }
}
