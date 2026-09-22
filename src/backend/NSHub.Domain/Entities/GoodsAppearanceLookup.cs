// <copyright file="GoodsAppearanceLookup.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents lookup data for outer goods appearance in transport documents.
/// </summary>
public class GoodsAppearanceLookup
{
    /// <summary>Gets or sets the goods appearance code (Primary Key).</summary>
    public string CodGoodsAppearance { get; set; } = null!;

    /// <summary>Gets or sets the description.</summary>
    public string? Description
    {
        get; set;
    }

    /// <summary>Gets or sets notes.</summary>
    public string? Notes
    {
        get; set;
    }
}