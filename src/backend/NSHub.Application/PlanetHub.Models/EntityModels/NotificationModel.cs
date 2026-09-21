// <copyright file="NotificationModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Enums;

namespace NSHub.Application.PlanetHub.Models.EntityModels;

public class NotificationModel : BaseEntityModel
{
    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string User { get; set; } = null!;

    public string Page { get; set; } = null!;

    public DateTime Date { get; set; }

    public string ConnectionId { get; set; } = null!;

    public NotificationType NotificationType { get; set; } = NotificationType.Info;
}

