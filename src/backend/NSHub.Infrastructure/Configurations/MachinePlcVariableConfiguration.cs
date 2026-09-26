// <copyright file="MachinePlcVariableConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class MachinePlcVariableConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<MachinePlcVariable>
{
    public void Configure(EntityTypeBuilder<MachinePlcVariable> builder)
    {
        builder.ToTable("MachinePlcVariable", "dbo");


        builder.Property(e => e.PlcVariableId).IsRequired();
        builder.Property(e => e.Name).IsRequired(false);
        builder.Property(e => e.Value).IsRequired(false);
        builder.Property(e => e.MachineNumber).IsRequired(false);
        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.Program).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.PlcVariable)
            .WithMany(p => p.MachinePlcVariables)
            .HasForeignKey(e => e.PlcVariableId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
