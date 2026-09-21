// <copyright file="BaseEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace NSHub.Application.Entities;

public class BaseEntity
{
	public Guid Id { get; set; }

    public Guid? UserUpdateId { get; set; }

    public Guid? UserInsertId { get; set; }

    public Guid? UserDeletedId { get; set; }

    public DateTime? DateUpdate { get; set; } = DateTime.Now;

    public DateTime? DateInsert { get; set; } = DateTime.Now;

	public DateTime? DateDeleted { get; set; }

	public bool IsDeleted { get; set; }

    public Guid? TenantId { get; set; }

    public bool IsActive { get; set; }


    [Timestamp]
	public List<byte>? Version { get; set; }

    public virtual Tenant? Tenant { get; set; }

    public virtual User? UserInsert { get; set; }

    public virtual User? UserUpdate { get; set; }

}
