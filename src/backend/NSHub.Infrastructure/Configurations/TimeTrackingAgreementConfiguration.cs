using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class TimeTrackingAgreementConfiguration : IEntityTypeConfiguration<TimeTrackingAgreement>
{
    public void Configure(EntityTypeBuilder<TimeTrackingAgreement> builder)
    {
        builder.ToTable("TimeTrackingAgreement", "dbo");

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
        builder.Property(e => e.EmployeeId).IsRequired();
        builder.Property(e => e.AgreementTypeId).IsRequired();
        builder.Property(e => e.ValidFrom).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.ValidTo).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.IsRevoked).IsRequired();
        builder.Property(e => e.DocumentReference).HasMaxLength(255).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.AgreementType)
            .WithMany(p => p.TimeTrackingAgreements)
            .HasForeignKey(e => e.AgreementTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Employee)
            .WithMany(p => p.TimeTrackingAgreements)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
