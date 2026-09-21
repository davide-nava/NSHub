// <copyright file="NotificationCommandService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Commands;
using NSHub.Application.Interfaces.Services.Commands;
using NSHub.Application.NSHub.Models.EntityModels;

namespace NSHub.Application.Services.Commands;

public class NotificationCommandService(INotificationCommandRepository repo, IMapper<Notification, NotificationModel> mapper) : BaseCommandService<Notification, NotificationModel, INotificationCommandRepository>(repo, mapper), INotificationCommandService;
