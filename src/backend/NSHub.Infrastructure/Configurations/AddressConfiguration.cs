using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(t => t.HasCheckConstraint("CK_Address_ValidityRange", "([ValidTo] IS NULL OR [ValidTo]>=[ValidFrom])"));
        builder.ToTable("Address", "dbo");

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
        builder.Property(e => e.PartyId).IsRequired();
        builder.Property(e => e.AddressTypeId).IsRequired();
        builder.Property(e => e.NationId).IsRequired(false);
        builder.Property(e => e.StreetName).HasMaxLength(200).IsRequired();
        builder.Property(e => e.BuildingNumber).HasMaxLength(30).IsRequired(false);
        builder.Property(e => e.AddressLine2).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.PostalCode).HasMaxLength(20).IsRequired();
        builder.Property(e => e.City).HasMaxLength(100).IsRequired();
        builder.Property(e => e.StateProvince).HasMaxLength(100).IsRequired(false);
        builder.Property(e => e.CountryCode).HasMaxLength(2).IsUnicode(false).IsRequired().HasDefaultValueSql("('CH')");
        builder.Property(e => e.CareOf).HasMaxLength(150).IsRequired(false);
        builder.Property(e => e.ValidFrom).HasColumnType("date").IsRequired();
        builder.Property(e => e.ValidTo).HasColumnType("date").IsRequired(false);
        builder.Property(e => e.IsDefault).IsRequired();
        builder.Property(e => e.Street).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.StreetNumber).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.ZipCode).HasMaxLength(20).IsRequired(false);
        builder.Property(e => e.Province).HasMaxLength(10).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.AddressType)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => e.AddressTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Nation)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => e.NationId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Party)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => e.PartyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
