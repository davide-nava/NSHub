// <copyright file="Notification.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class Notification : BaseEntity
{
    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string User { get; set; } = null!;

    public string Page { get; set; } = null!;

    public DateTime Dt { get; set; }

    public Guid ConnectionId { get; set; }

    public NotificationType NotificationType { get; set; } = NotificationType.Info;
}
