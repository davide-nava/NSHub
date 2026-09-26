using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class AspNetUsersConfiguration : IEntityTypeConfiguration<AspNetUsers>
{
    public void Configure(EntityTypeBuilder<AspNetUsers> builder)
    {
        builder.ToTable("AspNetUsers", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasMaxLength(450).IsRequired();
        builder.Property(e => e.UserName).HasMaxLength(256).IsRequired(false);
        builder.Property(e => e.NormalizedUserName).HasMaxLength(256).IsRequired(false);
        builder.Property(e => e.Email).HasMaxLength(256).IsRequired(false);
        builder.Property(e => e.NormalizedEmail).HasMaxLength(256).IsRequired(false);
        builder.Property(e => e.EmailConfirmed).IsRequired();
        builder.Property(e => e.PasswordHash).IsRequired(false);
        builder.Property(e => e.SecurityStamp).IsRequired(false);
        builder.Property(e => e.ConcurrencyStamp).IsRequired(false);
        builder.Property(e => e.PhoneNumber).HasMaxLength(256).IsRequired(false);
        builder.Property(e => e.PhoneNumberConfirmed).IsRequired();
        builder.Property(e => e.TwoFactorEnabled).IsRequired();
        builder.Property(e => e.LockoutEnd).HasColumnType("datetimeoffset(7)").HasMaxLength(7).IsRequired(false);
        builder.Property(e => e.LockoutEnabled).IsRequired();
        builder.Property(e => e.AccessFailedCount).IsRequired();

    }
}
