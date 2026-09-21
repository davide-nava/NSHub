// <copyright file="InvoiceConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Invoicing.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Invoicing.Entities;
using NSHub.Domain.Invoicing.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="Invoice"/>.
/// </summary>
public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        _ = builder.ToTable("Invoices");

        _ = builder.HasKey(i => i.Id);
        _ = builder.Property(i => i.Id)
            .HasConversion(id => id.Value, value => new InvoiceId(value))
            .ValueGeneratedNever();

        _ = builder.Property(i => i.CustomerId)
            .HasConversion(id => id.Value, value => new CustomerId(value))
            .IsRequired();

        _ = builder.Property(i => i.InvoiceNumber)
            .HasMaxLength(50);

        _ = builder.HasIndex(i => i.InvoiceNumber);

        _ = builder.Property(i => i.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(i => i.PaymentTerm)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(i => i.IssueDateUtc);
        _ = builder.Property(i => i.DueDateUtc);
        _ = builder.Property(i => i.CreatedAtUtc).IsRequired();

        _ = builder.Ignore(i => i.TotalNet);
        _ = builder.Ignore(i => i.TotalVat);
        _ = builder.Ignore(i => i.TotalGross);

        _ = builder.HasMany(i => i.Lines)
            .WithOne()
            .HasForeignKey(l => l.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Metadata.FindNavigation(nameof(Invoice.Lines))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
