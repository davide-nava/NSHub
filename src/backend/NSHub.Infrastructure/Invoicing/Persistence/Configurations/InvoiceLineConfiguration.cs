// <copyright file="InvoiceLineConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Invoicing.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Invoicing.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="InvoiceLine"/>.
/// </summary>
public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<InvoiceLine> builder)
    {
        _ = builder.ToTable("InvoiceLines");

        _ = builder.HasKey(l => l.Id);
        _ = builder.Property(l => l.Id)
            .HasConversion(id => id.Value, value => new InvoiceLineId(value))
            .ValueGeneratedNever();

        _ = builder.Property(l => l.InvoiceId)
            .HasConversion(id => id.Value, value => new InvoiceId(value))
            .IsRequired();

        _ = builder.Property(l => l.Description)
            .HasMaxLength(500)
            .IsRequired();

        _ = builder.Property(l => l.Quantity)
            .HasPrecision(18, 4)
            .IsRequired();

        _ = builder.Property(l => l.UnitPrice)
            .HasPrecision(18, 4)
            .IsRequired();

        _ = builder.Property(l => l.DiscountPercentage)
            .HasPrecision(5, 2)
            .IsRequired();

        _ = builder.Property(l => l.VatRate)
            .HasPrecision(5, 2)
            .IsRequired();

        _ = builder.Ignore(l => l.LineTotalNet);
        _ = builder.Ignore(l => l.LineTotalVat);
        _ = builder.Ignore(l => l.LineTotalGross);
    }
}
