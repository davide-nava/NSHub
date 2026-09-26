// <copyright file="DncTextConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DncTextConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<DncText>
{
    public void Configure(EntityTypeBuilder<DncText> builder)
    {
        builder.ToTable("DncText", "dbo");


        builder.Property(e => e.LanguageId).IsRequired();
        builder.Property(e => e.Number).IsRequired();
        builder.Property(e => e.Text).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Language)
            .WithMany(p => p.DncTexts)
            .HasForeignKey(e => e.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
