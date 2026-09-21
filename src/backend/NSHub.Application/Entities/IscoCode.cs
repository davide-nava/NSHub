// <copyright file="IscoCode.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class IscoCode : BaseEntityType
{

    public string? AvamNumber { get; set; }

    public string? BfsNumber { get; set; }

    public string? PartCodePilot { get; set; }

    public string? PartCode { get; set; }
 
}
