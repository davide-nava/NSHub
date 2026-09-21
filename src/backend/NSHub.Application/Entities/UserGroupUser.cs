// <copyright file="UserGroupUser.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class UserGroupUser : BaseEntity
{
    public DateTime From { get; set; }
    
    public DateTime To { get; set; }

    public Guid UserId { get; set; }

    public Guid UserGroupId { get; set; }

    public virtual UserGroup? UserGroup { get; set; }

    public virtual User? User { get; set; }
}
