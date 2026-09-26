// <copyright file="PartyConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class PartyConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Party>
{
    public void Configure(EntityTypeBuilder<Party> builder)
    {
        builder.ToTable("Party", "dbo");

        builder.Property(e => e.InternalCode).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.PartyTypeCode).HasMaxLength(20).IsRequired();
        builder.Property(e => e.DisplayName).HasMaxLength(255).IsRequired();
        builder.Property(e => e.TaxIdentificationNumber).HasMaxLength(30).IsRequired(false);
        builder.Property(e => e.VatNumber).HasMaxLength(30).IsRequired(false);
        builder.Property(e => e.Notes).IsRequired(false);
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.CreatedOn).HasColumnType("datetimeoffset(7)").HasMaxLength(7).IsRequired();
        builder.Property(e => e.UpdatedOn).HasColumnType("datetimeoffset(7)").HasMaxLength(7).IsRequired();

        builder.HasOne(e => e.Person).WithOne(p => p.Party).HasForeignKey<Person>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Organization).WithOne(o => o.Party).HasForeignKey<Organization>(o => o.Id).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.PartyType)
            .WithMany(p => p.Parties)
            .HasForeignKey(e => e.PartyTypeCode)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
