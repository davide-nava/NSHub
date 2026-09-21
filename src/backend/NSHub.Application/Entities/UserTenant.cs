// <copyright file="UserTenant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class UserTenant : BaseEntity
{
    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public bool CanRead { get; set; }

    public Guid CanEdit { get; set; }

    public Guid UserId { get; set; }

    public virtual User? User { get; set; }
}
