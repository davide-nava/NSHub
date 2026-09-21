// <copyright file="IEfCoreQueryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Interfaces.Repositories.Queries;

public interface IEfCoreQueryRepository
{
    Task<bool> GenericAsync();
}
