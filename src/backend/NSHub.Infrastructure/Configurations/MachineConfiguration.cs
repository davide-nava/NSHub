// <copyright file="MachineConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class MachineConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Machine>
{
    public void Configure(EntityTypeBuilder<Machine> builder)
    {
        _ = builder.ToTable("Machine", "dbo");

        _ = builder.Property(e => e.Notes).IsRequired();
        _ = builder.Property(e => e.Number).IsRequired();
        _ = builder.Property(e => e.WarrantyEndDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.AcceptanceDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.DeliveryDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.CustomerCode).IsRequired();
        _ = builder.Property(e => e.Customer).IsRequired();
        _ = builder.Property(e => e.Pneumatic).IsRequired();
        _ = builder.Property(e => e.Hydraulic).IsRequired();
        _ = builder.Property(e => e.WorkpieceProbe).IsRequired();
        _ = builder.Property(e => e.WheelProbe).IsRequired();
        _ = builder.Property(e => e.Nakanishi).IsRequired();
        _ = builder.Property(e => e.Hh).IsRequired();
        _ = builder.Property(e => e.TBelt).IsRequired();
        _ = builder.Property(e => e.Clutch).IsRequired();
        _ = builder.Property(e => e.AxisU).IsRequired();
        _ = builder.Property(e => e.SpindleCode).IsRequired();
        _ = builder.Property(e => e.WheelMotorCode).IsRequired();
        _ = builder.Property(e => e.Pc).IsRequired();
        _ = builder.Property(e => e.PcBox).IsRequired();
        _ = builder.Property(e => e.ModuleCode).IsRequired();
        _ = builder.Property(e => e.AxisModules).IsRequired();
        _ = builder.Property(e => e.SafetyMod).IsRequired();
        _ = builder.Property(e => e.Inverters).IsRequired();
        _ = builder.Property(e => e.MachineBuilderId).IsRequired();
        _ = builder.Property(e => e.MachineTypeId).IsRequired();
        _ = builder.Property(e => e.PlcTypeId).IsRequired();
        _ = builder.Property(e => e.CustomerId).IsRequired(false);
        _ = builder.Property(e => e.AddressId).IsRequired();
        _ = builder.Property(e => e.Temperature).HasPrecision(18, 8).IsRequired();
        _ = builder.Property(e => e.JobOrder).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.CustomerEntity)
            .WithMany(p => p.Machines)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.MachineBuilder)
            .WithMany(p => p.Machines)
            .HasForeignKey(e => e.MachineBuilderId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.MachineType)
            .WithMany(p => p.Machines)
            .HasForeignKey(e => e.MachineTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.PlcType)
            .WithMany(p => p.Machines)
            .HasForeignKey(e => e.PlcTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
