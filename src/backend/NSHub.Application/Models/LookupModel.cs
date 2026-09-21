// <copyright file="LookupModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Models;

public class LookupModel
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;
}
