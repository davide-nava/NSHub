// <copyright file="RelationshipTypeConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Organization;

public class RelationshipTypeConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<RelationshipType>
{
    public void Configure(EntityTypeBuilder<RelationshipType> builder)
    {
        _ = builder.ToTable("RelationshipType", "dbo");

        _ = builder.Ignore(e => e.Id);
        _ = builder.HasKey(e => e.RelationshipTypeCode);

        _ = builder.Property(e => e.RelationshipTypeCode).HasMaxLength(30).IsRequired();
        _ = builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
        _ = builder.Property(e => e.SourceRole).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.TargetRole).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(250).IsRequired(false);
    }
}
