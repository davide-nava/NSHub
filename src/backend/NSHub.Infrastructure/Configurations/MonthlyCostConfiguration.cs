using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class MonthlyCostConfiguration : IEntityTypeConfiguration<MonthlyCost>
{
    public void Configure(EntityTypeBuilder<MonthlyCost> builder)
    {
        builder.ToTable("MonthlyCost", "dbo");

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
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.StartDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.EndDate).HasColumnType("datetime").IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
