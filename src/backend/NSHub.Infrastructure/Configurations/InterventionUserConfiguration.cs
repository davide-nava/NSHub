using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class InterventionUserConfiguration : IEntityTypeConfiguration<InterventionUser>
{
    public void Configure(EntityTypeBuilder<InterventionUser> builder)
    {
        builder.ToTable("InterventionUser", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.DateInsert).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.DateDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.DateUpdate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.UserInsertId).IsRequired(false);
        builder.Property(e => e.UserDeleteId).IsRequired(false);
        builder.Property(e => e.UserUpdateId).IsRequired(false);
        builder.Property(e => e.TenantId).IsRequired(false);
        builder.Property(e => e.RowVersion).IsRowVersion();
        builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.InterventionId).IsRequired();
        builder.Property(e => e.EndDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.StartDate).HasColumnType("datetime").IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Intervention)
            .WithMany(p => p.InterventionUsers)
            .HasForeignKey(e => e.InterventionId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.User)
            .WithMany(p => p.InterventionUsers)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
