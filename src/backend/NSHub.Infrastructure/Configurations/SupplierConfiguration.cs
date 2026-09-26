using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Supplier", "dbo");

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
        builder.Property(e => e.Name).HasMaxLength(100).IsUnicode(false).IsRequired();
        builder.Property(e => e.Search).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.Number).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.VatNumber).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.TaxCode).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.SdiCode).HasMaxLength(10).IsRequired(false);
        builder.Property(e => e.PecEmail).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.Email).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.Phone).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.AddressId).IsRequired(false);
        builder.Property(e => e.PaymentId).IsRequired(false);
        builder.Property(e => e.BankAccountId).IsRequired(false);
        builder.Property(e => e.IsActive).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.BankAccount)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Payment)
            .WithMany(p => p.Suppliers)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
