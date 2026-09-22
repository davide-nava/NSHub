// <copyright file="NegativeStockException.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Globalization;

namespace NSHub.Domain.Exceptions;

/// <summary>
/// Exception thrown when an inventory operation would result in an illegal negative stock balance.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NegativeStockException"/> class.
/// </remarks>
/// <param name="articleSku">The product SKU violating stock limits.</param>
/// <param name="locationCode">The stock location identifier.</param>
/// <param name="availableQuantity">The current available quantity.</param>
/// <param name="requestedQuantity">The requested outgoing or reserved quantity.</param>
public class NegativeStockException(string articleSku, string locationCode, decimal availableQuantity, decimal requestedQuantity) : DomainException("Warehouse.NegativeStock", string.Create(CultureInfo.InvariantCulture, $"Insufficient stock for article '{articleSku}' at location '{locationCode}'. Available: {availableQuantity}, Requested: {requestedQuantity}."));
