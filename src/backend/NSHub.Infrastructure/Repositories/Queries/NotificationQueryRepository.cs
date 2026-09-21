// <copyright file="NotificationQueryRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.ApplicationCore.Interfaces.Repositories.Queries;
using PlanetHub.Caches.Interfaces;
using PlanetHub.Infrastructure.DbContexts;

namespace PlanetHub.Infrastructure.Repositories.Queries;

public class NotificationQueryRepository(TenantDbContext dbContext, IPlanetHubMemoryCacheService? planetHubMemoryCacheService = null) : BaseQueryRepository<Notification>(dbContext, planetHubMemoryCacheService), INotificationQueryRepository;
