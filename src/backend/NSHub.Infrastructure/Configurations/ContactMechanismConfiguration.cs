using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class ContactMechanismConfiguration : IEntityTypeConfiguration<ContactMechanism>
{
    public void Configure(EntityTypeBuilder<ContactMechanism> builder)
    {
        builder.ToTable("ContactMechanism", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.PartyId).IsRequired();
        builder.Property(e => e.ContactChannelTypeCode).HasMaxLength(20).IsRequired();
        builder.Property(e => e.ContactValue).HasMaxLength(255).IsRequired();
        builder.Property(e => e.UsageDescription).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.IsDefault).IsRequired();
        builder.Property(e => e.IsVerified).IsRequired();
        builder.Property(e => e.Notes).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.CreatedOn).HasColumnType("datetimeoffset(7)").HasMaxLength(7).IsRequired();

        builder.HasOne(e => e.ContactChannelType)
            .WithMany(p => p.ContactMechanisms)
            .HasForeignKey(e => e.ContactChannelTypeCode)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Party)
            .WithMany(p => p.ContactMechanisms)
            .HasForeignKey(e => e.PartyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
