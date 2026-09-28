// <copyright file="UserConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Identity;

/// <summary>
/// Entity configuration for <see cref="User"/>.
/// </summary>
public class UserConfiguration : AuditableEntityConfigurationBase<User>, IEntityTypeConfiguration<User>
{
    /// <inheritdoc/>
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        base.Configure(builder);

        _ = builder.ToTable("User", "dbo");

        _ = builder.Property(e => e.AspNetUserId).HasMaxLength(450).IsRequired();
        _ = builder.Property(e => e.Email).HasMaxLength(256);

        _ = builder.HasOne(e => e.CurrentTenant)
            .WithMany()
            .HasForeignKey(e => e.CurrentTenantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
