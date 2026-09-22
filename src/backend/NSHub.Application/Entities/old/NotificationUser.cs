// <copyright file="NotificationUser.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class NotificationUser : BaseEntity
{
    public DateTime? ReadDate { get; set; }

    public Guid NotificationId { get; set; }

    public Guid UserId { get; set; }

    public DateTime? DateRead { get; set; }

    public NotificationType NotificationType { get; set; }

    public virtual Notification? Notification { get; set; }

    public virtual User? User { get; set; }

}
