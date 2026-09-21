// <copyright file="TimeCorrectionAuditConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Persistence.Configurations;

/// <summary>
/// Entity configuration for <see cref="TimeCorrectionAudit"/>.
/// </summary>
public class TimeCorrectionAuditConfiguration : IEntityTypeConfiguration<TimeCorrectionAudit>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<TimeCorrectionAudit> builder)
    {
        _ = builder.ToTable("TimeCorrectionAudits");

        _ = builder.HasKey(a => a.Id);

        _ = builder.Property(a => a.TimeEntryId)
            .IsRequired();

        _ = builder.Property(a => a.OperatorId)
            .IsRequired();

        _ = builder.Property(a => a.TimestampUtc)
            .IsRequired();

        _ = builder.Property(a => a.PreCorrectionClockInUtc)
            .IsRequired();

        _ = builder.Property(a => a.PostCorrectionClockInUtc)
            .IsRequired();

        _ = builder.Property(a => a.MandatoryReason)
            .HasMaxLength(1000)
            .IsRequired();

        _ = builder.Property(a => a.IpAddress)
            .HasMaxLength(50);

        _ = builder.HasIndex(a => a.TimeEntryId);
    }
}
