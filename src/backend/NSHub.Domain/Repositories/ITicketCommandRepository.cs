// <copyright file="ITicketCommandRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Repositories;

/// <summary>
/// Repository contract for managing support tickets.
/// </summary>
public interface ITicketCommandRepository : IBaseCommandRepository<Ticket>;
