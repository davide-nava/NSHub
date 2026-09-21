// <copyright file="ISettingCommandRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>


using NSHub.Application.NSHub.Models.EntityModels;

namespace NSHub.Application.Interfaces.Repositories.Commands;

public interface ISettingCommandRepository : IBaseCommandRepository<SettingModel>;
