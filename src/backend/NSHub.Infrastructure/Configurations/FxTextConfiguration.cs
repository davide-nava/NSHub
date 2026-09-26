// <copyright file="FxTextConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class FxTextConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<FxText>
{
    public void Configure(EntityTypeBuilder<FxText> builder)
    {
        _ = builder.ToTable("FxText", "dbo");

        _ = builder.Property(e => e.Number).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.LanguageId).IsRequired();
        _ = builder.Property(e => e.FxTextTypeId).IsRequired();
        _ = builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.FxTextType)
            .WithMany(p => p.FxTexts)
            .HasForeignKey(e => e.FxTextTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Language)
            .WithMany(p => p.FxTexts)
            .HasForeignKey(e => e.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
