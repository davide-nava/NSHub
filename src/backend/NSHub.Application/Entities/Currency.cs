// <copyright file="Currency.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Currency        : BaseEntityType
{
    
    public string? Symbol { get; set; }


    public string Name { get; set; } = null!;

    public int? Decimals { get; set; }

 
}
