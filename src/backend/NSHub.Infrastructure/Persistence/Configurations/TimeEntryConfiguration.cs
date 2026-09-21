// <copyright file="TimeEntryConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Persistence.Configurations;

public class TimeEntryConfiguration : IEntityTypeConfiguration<TimeEntry>
{
    public void Configure(EntityTypeBuilder<TimeEntry> builder)
    {
        _ = builder.ToTable("TimeEntries");

        _ = builder.HasKey(t => t.Id);

        _ = builder.Property(t => t.EmployeeId)
            .IsRequired();

        _ = builder.Property(t => t.ClockInUtc)
            .IsRequired();

        _ = builder.Property(t => t.ClockOutUtc);

        _ = builder.Property(t => t.BreakDurationMinutes)
            .IsRequired();

        // OwnsOne per le coordinate GPS puntuali (Art. 26 OLL 3)
        _ = builder.OwnsOne(t => t.PunctualClockInGps, gps =>
        {
            _ = gps.Property(p => p.Latitude).HasColumnName("ClockInLatitude");
            _ = gps.Property(p => p.Longitude).HasColumnName("ClockInLongitude");
            _ = gps.Property(p => p.AccuracyMeters).HasColumnName("ClockInAccuracyMeters");
            _ = gps.Property(p => p.TimestampUtc).HasColumnName("ClockInGpsTimestampUtc");
        });

        _ = builder.OwnsOne(t => t.PunctualClockOutGps, gps =>
        {
            _ = gps.Property(p => p.Latitude).HasColumnName("ClockOutLatitude");
            _ = gps.Property(p => p.Longitude).HasColumnName("ClockOutLongitude");
            _ = gps.Property(p => p.AccuracyMeters).HasColumnName("ClockOutAccuracyMeters");
            _ = gps.Property(p => p.TimestampUtc).HasColumnName("ClockOutGpsTimestampUtc");
        });

        _ = builder.Property(t => t.Notes)
            .HasMaxLength(500);

        _ = builder.Property(t => t.Status)
            .IsRequired();

        _ = builder.Property(t => t.Violations)
            .IsRequired();

        _ = builder.HasMany(t => t.AuditTrail)
            .WithOne()
            .HasForeignKey(a => a.TimeEntryId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(t => new { t.EmployeeId, t.ClockInUtc });
    }
}
