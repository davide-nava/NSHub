// <copyright file="BaseFilter.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Enums;

namespace NSHub.Application.NSHub.Models;

public class BaseFilter
{
	public string? Text
	{
		get; set;
	}

	public int? PageSize
	{
		get; set;
	}

	public int? PageNumber
	{
		get; set;
	}

	public SortingDirectionType? SortingDirectionType
	{
		get; set;
	}

	public string? SortingBy
	{
		get; set;
	}

	public List<Guid>? ExcludeIDs
	{
		get; set;
	}
}

