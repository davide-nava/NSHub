// <copyright file="PartyConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Organization;

public class PartyConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Party>
{
    public void Configure(EntityTypeBuilder<Party> builder)
    {
        _ = builder.ToTable("Party", "dbo");

        _ = builder.Property(e => e.InternalCode).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.PartyTypeCode).HasMaxLength(20).IsRequired();
        _ = builder.Property(e => e.DisplayName).HasMaxLength(255).IsRequired();
        _ = builder.Property(e => e.TaxIdentificationNumber).HasMaxLength(30).IsRequired(false);
        _ = builder.Property(e => e.VatNumber).HasMaxLength(30).IsRequired(false);
        _ = builder.Property(e => e.Notes).IsRequired(false);
        _ = builder.Property(e => e.IsActive).IsRequired();
        _ = builder.Property(e => e.CreatedOn).HasColumnType("datetimeoffset(7)").HasMaxLength(7).IsRequired();
        _ = builder.Property(e => e.UpdatedOn).HasColumnType("datetimeoffset(7)").HasMaxLength(7).IsRequired();

        _ = builder.HasOne(e => e.Person).WithOne(p => p.Party).HasForeignKey<Person>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        _ = builder.HasOne(e => e.Organization).WithOne(o => o.Party).HasForeignKey<NSHub.Domain.Entities.Organization.Organization>(o => o.Id).OnDelete(DeleteBehavior.Cascade);
        _ = builder.HasOne(e => e.PartyType)
            .WithMany(p => p.Parties)
            .HasForeignKey(e => e.PartyTypeCode)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
