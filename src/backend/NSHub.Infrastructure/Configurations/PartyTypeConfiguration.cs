using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class PartyTypeConfiguration : IEntityTypeConfiguration<PartyType>
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
