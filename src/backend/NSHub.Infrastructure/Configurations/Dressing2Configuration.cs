using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class Dressing2Configuration : IEntityTypeConfiguration<Dressing2>
{
    public void Configure(EntityTypeBuilder<Dressing2> builder)
    {
        builder.ToTable("Dressing2", "dbo");

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
        builder.Property(e => e.Retraction).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Chip).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Chip2).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Chip3).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Ancl).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.AllInt).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.AllExt).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.WorkAdv).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.ExtAxVel).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.ExtAxVel2).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.ExtAxVel3).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Removal).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Removal2).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.Removal3).HasPrecision(18, 4).IsRequired();
        builder.Property(e => e.IsCycle2).IsRequired();
        builder.Property(e => e.IsCycle3).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
