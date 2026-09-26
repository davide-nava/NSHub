// <copyright file="MachineConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class MachineConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Machine>
{
    public void Configure(EntityTypeBuilder<Machine> builder)
    {
        builder.ToTable("Machine", "dbo");


        builder.Property(e => e.Notes).IsRequired();
        builder.Property(e => e.Number).IsRequired();
        builder.Property(e => e.WarrantyEndDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.AcceptanceDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.DeliveryDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.CustomerCode).IsRequired();
        builder.Property(e => e.Customer).IsRequired();
        builder.Property(e => e.Pneumatic).IsRequired();
        builder.Property(e => e.Hydraulic).IsRequired();
        builder.Property(e => e.WorkpieceProbe).IsRequired();
        builder.Property(e => e.WheelProbe).IsRequired();
        builder.Property(e => e.Nakanishi).IsRequired();
        builder.Property(e => e.Hh).IsRequired();
        builder.Property(e => e.TBelt).IsRequired();
        builder.Property(e => e.Clutch).IsRequired();
        builder.Property(e => e.AxisU).IsRequired();
        builder.Property(e => e.SpindleCode).IsRequired();
        builder.Property(e => e.WheelMotorCode).IsRequired();
        builder.Property(e => e.Pc).IsRequired();
        builder.Property(e => e.PcBox).IsRequired();
        builder.Property(e => e.ModuleCode).IsRequired();
        builder.Property(e => e.AxisModules).IsRequired();
        builder.Property(e => e.SafetyMod).IsRequired();
        builder.Property(e => e.Inverters).IsRequired();
        builder.Property(e => e.MachineBuilderId).IsRequired();
        builder.Property(e => e.MachineTypeId).IsRequired();
        builder.Property(e => e.PlcTypeId).IsRequired();
        builder.Property(e => e.CustomerId).IsRequired(false);
        builder.Property(e => e.AddressId).IsRequired();
        builder.Property(e => e.Temperature).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.JobOrder).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.CustomerEntity)
            .WithMany(p => p.Machines)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.MachineBuilder)
            .WithMany(p => p.Machines)
            .HasForeignKey(e => e.MachineBuilderId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.MachineType)
            .WithMany(p => p.Machines)
            .HasForeignKey(e => e.MachineTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.PlcType)
            .WithMany(p => p.Machines)
            .HasForeignKey(e => e.PlcTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
