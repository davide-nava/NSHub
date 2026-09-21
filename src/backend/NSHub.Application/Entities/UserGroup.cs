// <copyright file="UserGroup.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class UserGroup : BaseEntityType
{
    public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; } = [];

}
