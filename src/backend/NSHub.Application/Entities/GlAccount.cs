// <copyright file="GlAccount.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class GlAccount
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public Guid? UserUpdateId { get; set; }

    public Guid? UserInsertId { get; set; }

    public DateTime DateUpdate { get; set; }

    public DateTime DateInsert { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public Guid CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string AccountType { get; set; } = null!;

    public bool IsPostingAllowed { get; set; }
}
