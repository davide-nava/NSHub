// <copyright file="InterventionAttachmentConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class InterventionAttachmentConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<InterventionAttachment>
{
    public void Configure(EntityTypeBuilder<InterventionAttachment> builder)
    {
        builder.ToTable("InterventionAttachment", "dbo");


        builder.Property(e => e.InterventionId).IsRequired();
        builder.Property(e => e.Src).IsUnicode(false).IsRequired();
        builder.Property(e => e.Title).HasMaxLength(256).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Intervention)
            .WithMany(p => p.InterventionAttachments)
            .HasForeignKey(e => e.InterventionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
