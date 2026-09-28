// <copyright file="PaginationResultModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Models;

public record PaginationResultModel<T>
{
    public PaginationModel? Pagination { get; init; }

    public IEnumerable<T> Records { get; init; } = [];
}
