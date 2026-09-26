// <copyright file="PaymentScheduleConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class PaymentScheduleConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<PaymentSchedule>
{
    public void Configure(EntityTypeBuilder<PaymentSchedule> builder)
    {
        _ = builder.ToTable("PaymentSchedule", "dbo");

        _ = builder.Property(e => e.InvoiceId).IsRequired();
        _ = builder.Property(e => e.InstallmentNumber).IsRequired();
        _ = builder.Property(e => e.DueDate).HasColumnType("date").IsRequired();
        _ = builder.Property(e => e.Amount).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.PaidAmount).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.IsPaid).IsRequired();
        _ = builder.Property(e => e.PaymentDate).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.BankAccountId).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.BankAccount)
            .WithMany(p => p.PaymentSchedules)
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Invoice)
            .WithMany(p => p.PaymentSchedules)
            .HasForeignKey(e => e.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
