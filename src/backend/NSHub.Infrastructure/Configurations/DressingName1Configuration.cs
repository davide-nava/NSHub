using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class DressingName1Configuration : IEntityTypeConfiguration<DressingName1>
{
    public void Configure(EntityTypeBuilder<DressingName1> builder)
    {
        builder.ToTable("DressingName1", "dbo");

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
        builder.Property(e => e.Pos).IsRequired();
        builder.Property(e => e.Pos2).IsRequired();
        builder.Property(e => e.Pos3).IsRequired();
        builder.Property(e => e.Cycle1).IsRequired();
        builder.Property(e => e.Cycle2).IsRequired();
        builder.Property(e => e.Cycle3).IsRequired();
        builder.Property(e => e.OilOff).IsRequired();
        builder.Property(e => e.OilInt).IsRequired();
        builder.Property(e => e.OilOn).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
