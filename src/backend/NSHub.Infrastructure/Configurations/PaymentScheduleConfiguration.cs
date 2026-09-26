// <copyright file="PaymentScheduleConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class PaymentScheduleConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<PaymentSchedule>
{
    public void Configure(EntityTypeBuilder<PaymentSchedule> builder)
    {
        builder.ToTable("PaymentSchedule", "dbo");


        builder.Property(e => e.InvoiceId).IsRequired();
        builder.Property(e => e.InstallmentNumber).IsRequired();
        builder.Property(e => e.DueDate).HasColumnType("date").IsRequired();
        builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.PaidAmount).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.IsPaid).IsRequired();
        builder.Property(e => e.PaymentDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.BankAccountId).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.BankAccount)
            .WithMany(p => p.PaymentSchedules)
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Invoice)
            .WithMany(p => p.PaymentSchedules)
            .HasForeignKey(e => e.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
