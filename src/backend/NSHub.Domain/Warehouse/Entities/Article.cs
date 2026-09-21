// <copyright file="Article.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Warehouse.Entities;

using NSHub.Domain.Common;
using NSHub.Domain.Exceptions;
using NSHub.Domain.Warehouse.Enums;
using NSHub.Domain.Warehouse.ValueObjects;

/// <summary>
/// Aggregate root representing an inventory article or product.
/// </summary>
public class Article : AggregateRoot<ArticleId>
{
    /// <summary>
    /// Gets the unique SKU or article code.
    /// </summary>
    public string Code { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the display name of the article.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the description.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the primary unit of measure.
    /// </summary>
    public ArticleUnitOfMeasure UnitOfMeasure { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the article is active for sales and stock.
    /// </summary>
    public bool IsActive { get; private set; } = true;

    // Parameterless constructor for EF Core
    private Article()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Article"/> aggregate root.
    /// </summary>
    public Article(
        ArticleId id,
        string code,
        string name,
        string description,
        ArticleUnitOfMeasure unitOfMeasure)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new BusinessRuleValidationException("Article.CodeRequired", "Article SKU code is mandatory.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BusinessRuleValidationException("Article.NameRequired", "Article name is mandatory.");
        }

        Id = id.Value == Guid.Empty ? ArticleId.New() : id;
        Code = code.Trim().ToUpperInvariant();
        Name = name.Trim();
        Description = description?.Trim() ?? string.Empty;
        UnitOfMeasure = unitOfMeasure;
        IsActive = true;
    }

    /// <summary>
    /// Deactivates the article preventing further stock transactions.
    /// </summary>
    public void Deactivate() => IsActive = false;

    /// <summary>
    /// Activates the article.
    /// </summary>
    public void Activate() => IsActive = true;
}
