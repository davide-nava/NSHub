using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class PartyRelationshipConfiguration : IEntityTypeConfiguration<PartyRelationship>
{
    public void Configure(EntityTypeBuilder<PartyRelationship> builder)
    {
        builder.ToTable(t => t.HasCheckConstraint("CK_PartyRelationship_PreventSelfLoop", "([SourcePartyId]<>[TargetPartyId])"));
        builder.ToTable(t => t.HasCheckConstraint("CK_PartyRelationship_ValidityRange", "([ValidTo] IS NULL OR [ValidTo]>=[ValidFrom])"));
        builder.ToTable("PartyRelationship", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.SourcePartyId).IsRequired();
        builder.Property(e => e.TargetPartyId).IsRequired();
        builder.Property(e => e.RelationshipTypeCode).HasMaxLength(30).IsRequired();
        builder.Property(e => e.ValidFrom).HasColumnType("date").IsRequired();
        builder.Property(e => e.ValidTo).HasColumnType("date").IsRequired(false);
        builder.Property(e => e.Notes).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.CreatedOn).HasColumnType("datetimeoffset(7)").HasMaxLength(7).IsRequired();

        builder.HasOne(e => e.SourceParty)
            .WithMany(p => p.SourceRelationships)
            .HasForeignKey(e => e.SourcePartyId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.TargetParty)
            .WithMany(p => p.TargetRelationships)
            .HasForeignKey(e => e.TargetPartyId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.RelationshipType)
            .WithMany(p => p.PartyRelationships)
            .HasForeignKey(e => e.RelationshipTypeCode)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
