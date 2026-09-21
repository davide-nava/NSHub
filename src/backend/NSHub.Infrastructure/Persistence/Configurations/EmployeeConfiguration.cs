// <copyright file="EmployeeConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Persistence.Configurations;

/// <summary>
/// Entity configuration for <see cref="Employee"/>.
/// </summary>
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        _ = builder.ToTable("Employees");

        _ = builder.HasKey(e => e.Id);
        _ = builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new NSHub.Domain.HR.ValueObjects.EmployeeId(value))
            .ValueGeneratedNever();

        _ = builder.Property(e => e.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .IsRequired();

        _ = builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsRequired();

        _ = builder.HasIndex(e => e.Email)
            .IsUnique();

        _ = builder.Property(e => e.Department)
            .HasMaxLength(100);

        _ = builder.Property(e => e.ContractualWeeklyHours)
            .HasPrecision(5, 2)
            .IsRequired();

        _ = builder.Property(e => e.StatutoryWeeklyLimit)
            .IsRequired();

        _ = builder.Property(e => e.Oll1Regime)
            .IsRequired();

        _ = builder.Property(e => e.PreferredLanguage)
            .IsRequired();

        _ = builder.Property(e => e.IsActive)
            .IsRequired();
    }
}
