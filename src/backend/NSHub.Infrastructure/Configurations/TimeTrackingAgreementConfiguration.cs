// <copyright file="TimeTrackingAgreementConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TimeTrackingAgreementConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<TimeTrackingAgreement>
{
    public void Configure(EntityTypeBuilder<TimeTrackingAgreement> builder)
    {
        _ = builder.ToTable("TimeTrackingAgreement", "dbo");

        _ = builder.Property(e => e.EmployeeId).IsRequired();
        _ = builder.Property(e => e.AgreementTypeId).IsRequired();
        _ = builder.Property(e => e.ValidFrom).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.ValidTo).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.IsRevoked).IsRequired();
        _ = builder.Property(e => e.DocumentReference).HasMaxLength(255).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.AgreementType)
            .WithMany(p => p.TimeTrackingAgreements)
            .HasForeignKey(e => e.AgreementTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Employee)
            .WithMany(p => p.TimeTrackingAgreements)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
