// <copyright file="Notification.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Notification : BaseEntity
{


    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string User { get; set; } = null!;

    public string Page { get; set; } = null!;

    public DateTime Dt { get; set; }

    public string ConnectionId { get; set; } = null!;

    public Guid NotificationTypeId { get; set; }

    public virtual NotificationType? NotificationType { get; set; }

}
