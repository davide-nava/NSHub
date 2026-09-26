// <copyright file="InterventionUserConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class InterventionUserConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<InterventionUser>
{
    public void Configure(EntityTypeBuilder<InterventionUser> builder)
    {
        _ = builder.ToTable("InterventionUser", "dbo");

        _ = builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.UserId).IsRequired();
        _ = builder.Property(e => e.InterventionId).IsRequired();
        _ = builder.Property(e => e.EndDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.StartDate).HasColumnType("datetime").IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Intervention)
            .WithMany(p => p.InterventionUsers)
            .HasForeignKey(e => e.InterventionId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.User)
            .WithMany(p => p.InterventionUsers)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
