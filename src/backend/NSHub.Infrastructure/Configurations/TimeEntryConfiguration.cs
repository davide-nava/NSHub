// <copyright file="TimeEntryConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TimeEntryConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<TimeEntry>
{
    public void Configure(EntityTypeBuilder<TimeEntry> builder)
    {
        _ = builder.ToTable("TimeEntry", "dbo");

        _ = builder.Property(e => e.EmployeeId).IsRequired(false);
        _ = builder.Property(e => e.WorkDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.StartTime).HasColumnType("time(0)").IsRequired(false);
        _ = builder.Property(e => e.EndTime).HasColumnType("time(0)").IsRequired(false);
        _ = builder.Property(e => e.BreakDurationMinutes).IsRequired(false);
        _ = builder.Property(e => e.TotalHoursWorked).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.IsNightWork).IsRequired();
        _ = builder.Property(e => e.IsSundayWork).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Employee)
            .WithMany(p => p.TimeEntries)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
}
