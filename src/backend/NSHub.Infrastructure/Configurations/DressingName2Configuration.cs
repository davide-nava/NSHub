using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class DressingName2Configuration : IEntityTypeConfiguration<DressingName2>
{
    public void Configure(EntityTypeBuilder<DressingName2> builder)
    {
        builder.ToTable("DressingName2", "dbo");

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
        builder.Property(e => e.LanguageId).IsRequired();
        builder.Property(e => e.Retreat).IsRequired();
        builder.Property(e => e.Chip).IsRequired();
        builder.Property(e => e.Ancl).IsRequired();
        builder.Property(e => e.AllInt).IsRequired();
        builder.Property(e => e.AllExt).IsRequired();
        builder.Property(e => e.OutVel).IsRequired();
        builder.Property(e => e.Vel).IsRequired();
        builder.Property(e => e.Removal).IsRequired();
        builder.Property(e => e.Cycle2).IsRequired();
        builder.Property(e => e.Cycle3).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
