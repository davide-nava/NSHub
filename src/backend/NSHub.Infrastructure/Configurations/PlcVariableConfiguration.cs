// <copyright file="PlcVariableConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class PlcVariableConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<PlcVariable>
{
    public void Configure(EntityTypeBuilder<PlcVariable> builder)
    {
        _ = builder.ToTable("PlcVariable", "dbo");

        _ = builder.Property(e => e.PlcVariableTypeId).IsRequired();
        _ = builder.Property(e => e.PlcVariableGroupTypeId).IsRequired();
        _ = builder.Property(e => e.Name).IsRequired();
        _ = builder.Property(e => e.IconOn).IsRequired(false);
        _ = builder.Property(e => e.Image).IsRequired(false);
        _ = builder.Property(e => e.IconOff).IsRequired(false);
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.AccessRights).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.IsWriting).IsRequired();
        _ = builder.Property(e => e.Notes).IsRequired(false);
        _ = builder.Property(e => e.IsHistorize).IsRequired();
        _ = builder.Property(e => e.Order).IsRequired();
        _ = builder.Property(e => e.MachineNumber).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.PlcVariableGroupType)
            .WithMany(p => p.PlcVariables)
            .HasForeignKey(e => e.PlcVariableGroupTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.PlcVariableType)
            .WithMany(p => p.PlcVariables)
            .HasForeignKey(e => e.PlcVariableTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
