using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class Dressing1Configuration : IEntityTypeConfiguration<Dressing1>
{
    public void Configure(EntityTypeBuilder<Dressing1> builder)
    {
        builder.ToTable("Dressing1", "dbo");

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
        builder.Property(e => e.X).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Y).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Z).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.V).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.W).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.IsPos1).IsRequired();
        builder.Property(e => e.IsPos2).IsRequired();
        builder.Property(e => e.IsPos3).IsRequired();
        builder.Property(e => e.IsCycle1).IsRequired();
        builder.Property(e => e.IsCycle2).IsRequired();
        builder.Property(e => e.IsCycle3).IsRequired();
        builder.Property(e => e.IsOilOff).IsRequired();
        builder.Property(e => e.IsOilnt).IsRequired();
        builder.Property(e => e.IsOilOn).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
