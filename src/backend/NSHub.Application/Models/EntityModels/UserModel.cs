// <copyright file="UserModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Models.EntityModels.JsonModels;
using NSHub.Domain.Entities;

namespace NSHub.Application.Models.EntityModels;

public class UserModel : AuditableTenantEntityModel
{
    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string WhatsApp { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool IsActive
    {
        get; set;
    }

    public Guid? TenantUsedId
    {
        get; set;
    }

    public Guid? ApplicationUserId
    {
        get; set;
    }

    public virtual ApplicationUser? ApplicationUser
    {
        get; set;
    }

    public virtual TenantModel? TenantUsed
    {
        get; set;
    }

    public UserConfigurationJsonModel Configuration { get; set; } = new();
}
