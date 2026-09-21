// <copyright file="UserRoleConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Identity.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Identity.Entities;
using NSHub.Domain.Identity.ValueObjects;

/// <summary>
/// Entity configuration for <see cref="UserRole"/>.
/// </summary>
public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        _ = builder.ToTable("UserRoles");

        _ = builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        _ = builder.Property(ur => ur.UserId)
            .HasConversion(id => id.Value, value => new UserId(value));

        _ = builder.Property(ur => ur.RoleId)
            .HasConversion(id => id.Value, value => new RoleId(value));

        _ = builder.Property(ur => ur.AssignedAtUtc)
            .IsRequired();
    }
}
