// <copyright file="PlcVariableConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class PlcVariableConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<PlcVariable>
{
    public void Configure(EntityTypeBuilder<PlcVariable> builder)
    {
        builder.ToTable("PlcVariable", "dbo");


        builder.Property(e => e.PlcVariableTypeId).IsRequired();
        builder.Property(e => e.PlcVariableGroupTypeId).IsRequired();
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.IconOn).IsRequired(false);
        builder.Property(e => e.Image).IsRequired(false);
        builder.Property(e => e.IconOff).IsRequired(false);
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.AccessRights).HasMaxLength(255).IsRequired(false);
        builder.Property(e => e.IsWriting).IsRequired();
        builder.Property(e => e.Notes).IsRequired(false);
        builder.Property(e => e.IsHistorize).IsRequired();
        builder.Property(e => e.Order).IsRequired();
        builder.Property(e => e.MachineNumber).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.PlcVariableGroupType)
            .WithMany(p => p.PlcVariables)
            .HasForeignKey(e => e.PlcVariableGroupTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.PlcVariableType)
            .WithMany(p => p.PlcVariables)
            .HasForeignKey(e => e.PlcVariableTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
