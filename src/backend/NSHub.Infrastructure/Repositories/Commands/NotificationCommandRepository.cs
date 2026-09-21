// <copyright file="NotificationCommandRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.ApplicationCore.Interfaces.Repositories.Commands;
using PlanetHub.Caches.Interfaces;
using PlanetHub.Infrastructure.DbContexts;

namespace PlanetHub.Infrastructure.Repositories.Commands;

public class NotificationCommandRepository(TenantDbContext dbContext, IPlanetHubMemoryCacheService? planetHubMemoryCacheService = null) : BaseCommandRepository<Notification>(dbContext, planetHubMemoryCacheService), INotificationCommandRepository;
