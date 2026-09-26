using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class AspNetUserClaimsConfiguration : IEntityTypeConfiguration<AspNetUserClaims>
{
    public void Configure(EntityTypeBuilder<AspNetUserClaims> builder)
    {
        builder.ToTable("AspNetUserClaims", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.UserId).HasMaxLength(450).IsRequired();
        builder.Property(e => e.ClaimType).IsRequired(false);
        builder.Property(e => e.ClaimValue).IsRequired(false);

        builder.HasOne(e => e.User)
            .WithMany(p => p.AspNetUserClaimses)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
