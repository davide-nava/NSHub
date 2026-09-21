// <copyright file="IssueInvoiceCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Commands.IssueInvoice;

using MediatR;
using NSHub.Application.Invoicing.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Command to issue an invoice, allocating a sequential invoice number and locking lines.
/// </summary>
public sealed record IssueInvoiceCommand(Guid InvoiceId) : IRequest<Result<InvoiceDto>>;
