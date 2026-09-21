// <copyright file="IRequestContext.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Interfaces;

public interface IRequestContext
{
    Guid  TenantId { get; set; }

    Guid UserId { get; set; }
}
