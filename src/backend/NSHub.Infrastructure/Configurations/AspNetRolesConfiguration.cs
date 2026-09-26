using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class AspNetRolesConfiguration : IEntityTypeConfiguration<AspNetRoles>
{
    public void Configure(EntityTypeBuilder<AspNetRoles> builder)
    {
        builder.ToTable("AspNetRoles", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasMaxLength(450).IsRequired();
        builder.Property(e => e.Name).HasMaxLength(256).IsRequired(false);
        builder.Property(e => e.NormalizedName).HasMaxLength(256).IsRequired(false);
        builder.Property(e => e.ConcurrencyStamp).IsRequired(false);

    }
}
