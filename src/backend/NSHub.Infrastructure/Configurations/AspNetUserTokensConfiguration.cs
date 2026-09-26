using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class AspNetUserTokensConfiguration : IEntityTypeConfiguration<AspNetUserTokens>
{
    public void Configure(EntityTypeBuilder<AspNetUserTokens> builder)
    {
        builder.ToTable("AspNetUserTokens", "dbo");

        builder.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

        builder.Property(e => e.UserId).HasMaxLength(450).IsRequired();
        builder.Property(e => e.LoginProvider).HasMaxLength(128).IsRequired();
        builder.Property(e => e.Name).HasMaxLength(128).IsRequired();
        builder.Property(e => e.Value).IsRequired(false);

        builder.HasOne(e => e.User)
            .WithMany(p => p.AspNetUserTokenses)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
