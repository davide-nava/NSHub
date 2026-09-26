using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class AspNetUserRolesConfiguration : IEntityTypeConfiguration<AspNetUserRoles>
{
    public void Configure(EntityTypeBuilder<AspNetUserRoles> builder)
    {
        builder.ToTable("AspNetUserRoles", "dbo");

        builder.HasKey(e => new { e.UserId, e.RoleId });

        builder.Property(e => e.UserId).HasMaxLength(450).IsRequired();
        builder.Property(e => e.RoleId).HasMaxLength(450).IsRequired();

        builder.HasOne(e => e.Role)
            .WithMany(p => p.AspNetUserRoleses)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.User)
            .WithMany(p => p.AspNetUserRoleses)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
