// <copyright file="NotificationCommandRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Interfaces.Repositories.Commands;
using NSHub.Caches.Interfaces;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories.Commands;

public class NotificationCommandRepository(TenantDbContext dbContext, INSHubMemoryCacheService? nSHubMemoryCacheService = null) : BaseCommandRepository<Notification>(dbContext, nSHubMemoryCacheService), INotificationCommandRepository;
