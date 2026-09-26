using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class AspNetUserPasskeysConfiguration : IEntityTypeConfiguration<AspNetUserPasskeys>
{
    public void Configure(EntityTypeBuilder<AspNetUserPasskeys> builder)
    {
        builder.ToTable("AspNetUserPasskeys", "dbo");

        builder.Ignore(e => e.Id);
        builder.HasKey(e => e.CredentialId);

        builder.Property(e => e.CredentialId).HasMaxLength(1024).IsRequired();
        builder.Property(e => e.UserId).HasMaxLength(450).IsRequired();
        builder.Property(e => e.Data).IsRequired();

        builder.HasOne(e => e.User)
            .WithMany(p => p.AspNetUserPasskeyses)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
