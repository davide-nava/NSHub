// <copyright file="NotificationQueryRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Interfaces.Repositories.Queries;
using NSHub.Caches.Interfaces;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories.Queries;

public class NotificationQueryRepository(TenantDbContext dbContext, INSHubMemoryCacheService? nSHubMemoryCacheService = null) : BaseQueryRepository<Notification>(dbContext, nSHubMemoryCacheService), INotificationQueryRepository;
