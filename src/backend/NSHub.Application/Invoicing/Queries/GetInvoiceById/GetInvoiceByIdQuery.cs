// <copyright file="GetInvoiceByIdQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Queries.GetInvoiceById;

using MediatR;
using NSHub.Application.Invoicing.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Query to retrieve a sales invoice by identifier.
/// </summary>
public sealed record GetInvoiceByIdQuery(Guid Id) : IRequest<Result<InvoiceDto>>;
