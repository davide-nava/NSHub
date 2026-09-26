// <copyright file="DressingName1Configuration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DressingName1Configuration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<DressingName1>
{
    public void Configure(EntityTypeBuilder<DressingName1> builder)
    {
        _ = builder.ToTable("DressingName1", "dbo");

        _ = builder.Property(e => e.LanguageId).IsRequired();
        _ = builder.Property(e => e.Pos).IsRequired();
        _ = builder.Property(e => e.Pos2).IsRequired();
        _ = builder.Property(e => e.Pos3).IsRequired();
        _ = builder.Property(e => e.Cycle1).IsRequired();
        _ = builder.Property(e => e.Cycle2).IsRequired();
        _ = builder.Property(e => e.Cycle3).IsRequired();
        _ = builder.Property(e => e.OilOff).IsRequired();
        _ = builder.Property(e => e.OilInt).IsRequired();
        _ = builder.Property(e => e.OilOn).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
}
