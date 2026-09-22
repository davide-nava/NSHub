// <copyright file="ITenantCommandService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.NSHub.Models.EntityModels;

namespace NSHub.Application.Interfaces.Services.Commands;

public interface ITenantCommandService : IBaseCommandService<TenantModel>;

