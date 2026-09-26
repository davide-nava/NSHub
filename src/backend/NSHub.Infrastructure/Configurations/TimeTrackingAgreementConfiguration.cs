// <copyright file="TimeTrackingAgreementConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TimeTrackingAgreementConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<TimeTrackingAgreement>
{
    public void Configure(EntityTypeBuilder<TimeTrackingAgreement> builder)
    {
        builder.ToTable("TimeTrackingAgreement", "dbo");


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
