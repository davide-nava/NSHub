// <copyright file="InvoiceDto.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.DTOs;

/// <summary>
/// Data transfer object for an invoice line.
/// </summary>
public sealed record InvoiceLineDto(
    Guid Id,
    string Description,
    decimal Quantity,
    decimal UnitPrice,
    decimal DiscountPercentage,
    decimal VatRate,
    decimal LineTotalNet,
    decimal LineTotalVat,
    decimal LineTotalGross);

/// <summary>
/// Data transfer object for a sales invoice.
/// </summary>
public sealed record InvoiceDto(
    Guid Id,
    Guid CustomerId,
    string InvoiceNumber,
    string Status,
    string PaymentTerm,
    DateTime? IssueDateUtc,
    DateTime? DueDateUtc,
    DateTime CreatedAtUtc,
    decimal TotalNet,
    decimal TotalVat,
    decimal TotalGross,
    IReadOnlyList<InvoiceLineDto> Lines);
