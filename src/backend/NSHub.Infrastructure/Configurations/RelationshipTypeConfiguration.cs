using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class RelationshipTypeConfiguration : IEntityTypeConfiguration<RelationshipType>
{
    public void Configure(EntityTypeBuilder<RelationshipType> builder)
    {
        builder.ToTable("RelationshipType", "dbo");

        builder.Ignore(e => e.Id);
        builder.HasKey(e => e.RelationshipTypeCode);

        builder.Property(e => e.RelationshipTypeCode).HasMaxLength(30).IsRequired();
        builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
        builder.Property(e => e.SourceRole).HasMaxLength(50).IsRequired();
        builder.Property(e => e.TargetRole).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(250).IsRequired(false);

    }
}
