// <copyright file="PaginationModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Enums;

namespace NSHub.Application.PlanetHub.Models;

public class PaginationModel
{
	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }

	public SortingDirectionType SortingDirectionType { get; set; } = SortingDirectionType.Asc;

	public string? SortingBy { get; set; }
}

