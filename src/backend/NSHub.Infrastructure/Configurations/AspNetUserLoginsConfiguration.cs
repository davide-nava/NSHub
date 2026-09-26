using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class AspNetUserLoginsConfiguration : IEntityTypeConfiguration<AspNetUserLogins>
{
    public void Configure(EntityTypeBuilder<AspNetUserLogins> builder)
    {
        builder.ToTable("AspNetUserLogins", "dbo");

        builder.HasKey(e => new { e.LoginProvider, e.ProviderKey });

        builder.Property(e => e.LoginProvider).HasMaxLength(128).IsRequired();
        builder.Property(e => e.ProviderKey).HasMaxLength(128).IsRequired();
        builder.Property(e => e.ProviderDisplayName).IsRequired(false);
        builder.Property(e => e.UserId).HasMaxLength(450).IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(p => p.AspNetUserLoginses)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
