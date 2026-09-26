using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class DeliveryNoteConfiguration : IEntityTypeConfiguration<DeliveryNote>
{
    public void Configure(EntityTypeBuilder<DeliveryNote> builder)
    {
        builder.ToTable("DeliveryNote", "dbo");

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
        builder.Property(e => e.DeliveryNoteNumber).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Year).IsRequired();
        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.OrderId).IsRequired(false);
        builder.Property(e => e.InvoiceCustomerId).IsRequired(false);
        builder.Property(e => e.GoodsCustomerId).IsRequired(false);
        builder.Property(e => e.ShippingAddressId).IsRequired(false);
        builder.Property(e => e.TransportReasonCode).HasMaxLength(50).IsRequired();
        builder.Property(e => e.GoodsAppearanceCode).HasMaxLength(50).IsRequired();
        builder.Property(e => e.TransportCareCode).HasMaxLength(50).IsRequired();
        builder.Property(e => e.CarriageCode).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Notes).IsRequired(false);
        builder.Property(e => e.PackageCount).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.Weight).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.Carriers).IsRequired(false);
        builder.Property(e => e.IsClosed).IsRequired(false);
        builder.Property(e => e.OurReference).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.OrderReference).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.TheirReference).HasColumnType("text").IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.GoodsCustomer)
            .WithMany(p => p.GoodsDeliveryNotes)
            .HasForeignKey(e => e.GoodsCustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.InvoiceCustomer)
            .WithMany(p => p.InvoiceDeliveryNotes)
            .HasForeignKey(e => e.InvoiceCustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Order)
            .WithMany(p => p.DeliveryNotes)
            .HasForeignKey(e => e.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
