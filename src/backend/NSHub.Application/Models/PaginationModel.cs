// <copyright file="PaginationModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Models;

public record PaginationModel
{
    public int TotalRecords { get; init; }

    public int RecordPerPage { get; init; }

    public int TotalPages { get; init; }

    public int CurrentPage { get; init; }
}
