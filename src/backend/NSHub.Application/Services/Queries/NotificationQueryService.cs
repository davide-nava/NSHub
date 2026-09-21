// <copyright file="NotificationQueryService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Queries;
using NSHub.Application.Interfaces.Services.Queries;
using NSHub.Application.NSHub.Models.EntityModels;

namespace NSHub.Application.Services.Queries;

public class NotificationQueryService(INotificationQueryRepository repo, IMapper<Notification, NotificationModel> mapper) : BaseQueryService<Notification, NotificationModel, INotificationQueryRepository>(repo,   mapper), INotificationQueryService;
