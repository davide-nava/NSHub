// <copyright file="UserConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Identity.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Identity.ValueObjects;

/// <summary>
/// Entity configuration for <see cref="User"/>.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        _ = builder.ToTable("Users");

        _ = builder.HasKey(u => u.Id);
        _ = builder.Property(u => u.Id)
            .HasConversion(id => id.Value, value => new UserId(value))
            .ValueGeneratedNever();

        _ = builder.Property(u => u.Email)
            .HasMaxLength(256)
            .IsRequired();

        _ = builder.HasIndex(u => u.Email).IsUnique();

        _ = builder.Property(u => u.PasswordHash)
            .HasMaxLength(512)
            .IsRequired();

        _ = builder.Property(u => u.PasswordSalt)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.Property(u => u.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.Property(u => u.LastName)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(u => u.FailedLoginAttempts)
            .IsRequired();

        _ = builder.Property(u => u.LockoutEndUtc);

        _ = builder.HasMany(u => u.Roles)
            .WithOne()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Metadata.FindNavigation(nameof(User.Roles))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        _ = builder.HasMany(u => u.Claims)
            .WithOne()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Metadata.FindNavigation(nameof(User.Claims))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
