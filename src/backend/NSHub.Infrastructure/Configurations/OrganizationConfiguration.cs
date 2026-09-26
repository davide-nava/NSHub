using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organization", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.LegalName).HasMaxLength(255).IsRequired();
        builder.Property(e => e.TradeName).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.LegalForm).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.ElectronicInvoicingCode).HasMaxLength(30).IsRequired(false);
        builder.Property(e => e.CommercialRegisterNumber).HasMaxLength(50).IsRequired(false);
        builder.Property(e => e.ShareCapital).HasPrecision(18, 2).IsRequired(false);
        builder.Property(e => e.CurrencyCode).HasMaxLength(3).IsUnicode(false).IsRequired(false).HasDefaultValueSql("('CHF')");

    }
}
