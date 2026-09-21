// <copyright file="NotificationType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class NotificationType : BaseEntityType
{


    public virtual ICollection<Notification> Notifications { get; set; } = [];

}
