// <copyright file="UserClaimConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Identity.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Identity.Entities;
using NSHub.Domain.Identity.ValueObjects;

/// <summary>
/// Entity configuration for <see cref="UserClaim"/>.
/// </summary>
public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        _ = builder.ToTable("UserClaims");

        _ = builder.HasKey(uc => uc.Id);

        _ = builder.Property(uc => uc.UserId)
            .HasConversion(id => id.Value, value => new UserId(value));

        _ = builder.Property(uc => uc.Type)
            .HasMaxLength(256)
            .IsRequired();

        _ = builder.Property(uc => uc.Value)
            .HasMaxLength(1024)
            .IsRequired();
    }
}
