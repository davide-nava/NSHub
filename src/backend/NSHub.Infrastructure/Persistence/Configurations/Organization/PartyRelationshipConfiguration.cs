// <copyright file="PartyRelationshipConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Organization;

public class PartyRelationshipConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<PartyRelationship>
{
    public void Configure(EntityTypeBuilder<PartyRelationship> builder)
    {
        _ = builder.ToTable(t => t.HasCheckConstraint("CK_PartyRelationship_PreventSelfLoop", "([SourcePartyId]<>[TargetPartyId])"));
        _ = builder.ToTable(t => t.HasCheckConstraint("CK_PartyRelationship_ValidityRange", "([ValidTo] IS NULL OR [ValidTo]>=[ValidFrom])"));
        _ = builder.ToTable("PartyRelationship", "dbo");

        _ = builder.Property(e => e.SourcePartyId).IsRequired();
        _ = builder.Property(e => e.TargetPartyId).IsRequired();
        _ = builder.Property(e => e.RelationshipTypeCode).HasMaxLength(30).IsRequired();
        _ = builder.Property(e => e.ValidFrom).HasColumnType("date").IsRequired();
        _ = builder.Property(e => e.ValidTo).HasColumnType("date").IsRequired(false);
        _ = builder.Property(e => e.Notes).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.CreatedOn).HasColumnType("datetimeoffset(7)").HasMaxLength(7).IsRequired();

        _ = builder.HasOne(e => e.SourceParty)
            .WithMany(p => p.SourceRelationships)
            .HasForeignKey(e => e.SourcePartyId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.TargetParty)
            .WithMany(p => p.TargetRelationships)
            .HasForeignKey(e => e.TargetPartyId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.RelationshipType)
            .WithMany()
            .HasForeignKey(e => e.RelationshipTypeCode)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
