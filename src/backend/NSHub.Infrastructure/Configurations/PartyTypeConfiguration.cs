// <copyright file="PartyTypeConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class PartyTypeConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<PartyType>
{
    public void Configure(EntityTypeBuilder<PartyType> builder)
    {
        builder.ToTable("PartyType", "dbo");

        builder.Ignore(e => e.Id);
        builder.HasKey(e => e.PartyTypeCode);

        builder.Property(e => e.PartyTypeCode).HasMaxLength(20).IsRequired();
        builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(250).IsRequired(false);

    }
}
