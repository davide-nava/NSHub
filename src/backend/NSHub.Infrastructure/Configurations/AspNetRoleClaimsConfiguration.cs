using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class AspNetRoleClaimsConfiguration : IEntityTypeConfiguration<AspNetRoleClaims>
{
    public void Configure(EntityTypeBuilder<AspNetRoleClaims> builder)
    {
        builder.ToTable("AspNetRoleClaims", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.RoleId).HasMaxLength(450).IsRequired();
        builder.Property(e => e.ClaimType).IsRequired(false);
        builder.Property(e => e.ClaimValue).IsRequired(false);

        builder.HasOne(e => e.Role)
            .WithMany(p => p.AspNetRoleClaimses)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
