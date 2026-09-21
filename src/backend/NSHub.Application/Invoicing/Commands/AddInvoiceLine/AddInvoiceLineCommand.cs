// <copyright file="AddInvoiceLineCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Commands.AddInvoiceLine;

using MediatR;
using NSHub.Application.Invoicing.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Command to append an itemized line to a draft sales invoice.
/// </summary>
public sealed record AddInvoiceLineCommand(
    Guid InvoiceId,
    string Description,
    decimal Quantity,
    decimal UnitPrice,
    decimal DiscountPercentage,
    decimal VatRate) : IRequest<Result<InvoiceDto>>;
