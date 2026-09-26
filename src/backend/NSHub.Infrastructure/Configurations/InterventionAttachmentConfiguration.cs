// <copyright file="InterventionAttachmentConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class InterventionAttachmentConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<InterventionAttachment>
{
    public void Configure(EntityTypeBuilder<InterventionAttachment> builder)
    {
        _ = builder.ToTable("InterventionAttachment", "dbo");

        _ = builder.Property(e => e.InterventionId).IsRequired();
        _ = builder.Property(e => e.Src).IsUnicode(false).IsRequired();
        _ = builder.Property(e => e.Title).HasMaxLength(256).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Intervention)
            .WithMany(p => p.InterventionAttachments)
            .HasForeignKey(e => e.InterventionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
