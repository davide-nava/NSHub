// <copyright file="RoleConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Identity.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Identity.ValueObjects;

/// <summary>
/// Entity configuration for <see cref="Role"/>.
/// </summary>
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        _ = builder.ToTable("Roles");

        _ = builder.HasKey(r => r.Id);
        _ = builder.Property(r => r.Id)
            .HasConversion(id => id.Value, value => new RoleId(value))
            .ValueGeneratedNever();

        _ = builder.Property(r => r.Name)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.HasIndex(r => r.Name).IsUnique();

        _ = builder.Property(r => r.Description)
            .HasMaxLength(500);
    }
}
