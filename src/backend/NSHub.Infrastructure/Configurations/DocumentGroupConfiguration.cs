// <copyright file="DocumentGroupConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DocumentGroupConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<DocumentGroup>
{
    public void Configure(EntityTypeBuilder<DocumentGroup> builder)
    {
        _ = builder.ToTable("DocumentGroup", "dbo");

        _ = builder.Property(e => e.DocumentTypeId).IsRequired();
        _ = builder.Property(e => e.Title).HasMaxLength(256).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.DocumentType)
            .WithMany(p => p.DocumentGroups)
            .HasForeignKey(e => e.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
