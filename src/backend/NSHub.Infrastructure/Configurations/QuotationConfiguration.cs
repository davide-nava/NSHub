// <copyright file="QuotationConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class QuotationConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Quotation>
{
    public void Configure(EntityTypeBuilder<Quotation> builder)
    {
        builder.ToTable("Quotation", "dbo");


        builder.Property(e => e.QuotationNumber).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Year).IsRequired();
        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.CustomerId).IsRequired(false);
        builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired(false);
        builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.IsClosed).IsRequired(false);
        builder.Property(e => e.VatId).IsRequired(false);
        builder.Property(e => e.PaymentId).IsRequired();
        builder.Property(e => e.IsSale).IsRequired();
        builder.Property(e => e.OurReference).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.TheirReference).HasColumnType("text").IsRequired(false);
        builder.Property(e => e.ValidityDays).IsRequired();
        builder.Property(e => e.TotalNetAmount).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.TotalGrossAmount).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.StatusCode).HasMaxLength(30).IsRequired().HasDefaultValueSql("('Pending')");

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Customer)
            .WithMany(p => p.Quotations)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Payment)
            .WithMany(p => p.Quotations)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Vat)
            .WithMany(p => p.Quotations)
            .HasForeignKey(e => e.VatId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
