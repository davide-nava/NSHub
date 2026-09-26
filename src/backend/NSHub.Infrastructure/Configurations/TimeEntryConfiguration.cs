// <copyright file="TimeEntryConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TimeEntryConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<TimeEntry>
{
    public void Configure(EntityTypeBuilder<TimeEntry> builder)
    {
        builder.ToTable("TimeEntry", "dbo");


        builder.Property(e => e.EmployeeId).IsRequired(false);
        builder.Property(e => e.WorkDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.StartTime).HasColumnType("time(0)").IsRequired(false);
        builder.Property(e => e.EndTime).HasColumnType("time(0)").IsRequired(false);
        builder.Property(e => e.BreakDurationMinutes).IsRequired(false);
        builder.Property(e => e.TotalHoursWorked).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.IsNightWork).IsRequired();
        builder.Property(e => e.IsSundayWork).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Employee)
            .WithMany(p => p.TimeEntries)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
