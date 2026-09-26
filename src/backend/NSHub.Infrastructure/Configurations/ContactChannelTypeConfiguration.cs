using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class ContactChannelTypeConfiguration : IEntityTypeConfiguration<ContactChannelType>
{
    public void Configure(EntityTypeBuilder<ContactChannelType> builder)
    {
        builder.ToTable("ContactChannelType", "dbo");

        builder.Ignore(e => e.Id);
        builder.HasKey(e => e.ContactChannelTypeCode);

        builder.Property(e => e.ContactChannelTypeCode).HasMaxLength(20).IsRequired();
        builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(250).IsRequired(false);

    }
}
