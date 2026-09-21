// <copyright file="CreateInvoiceCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Commands.CreateInvoice;

using MediatR;
using NSHub.Application.Invoicing.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Invoicing.Enums;

/// <summary>
/// Command to initiate a new draft sales invoice.
/// </summary>
public sealed record CreateInvoiceCommand(
    Guid CustomerId,
    PaymentTerm PaymentTerm) : IRequest<Result<InvoiceDto>>;
