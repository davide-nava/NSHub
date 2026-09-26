// <copyright file="MachinePlcVariableConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class MachinePlcVariableConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<MachinePlcVariable>
{
    public void Configure(EntityTypeBuilder<MachinePlcVariable> builder)
    {
        _ = builder.ToTable("MachinePlcVariable", "dbo");

        _ = builder.Property(e => e.PlcVariableId).IsRequired();
        _ = builder.Property(e => e.Name).IsRequired(false);
        _ = builder.Property(e => e.Value).IsRequired(false);
        _ = builder.Property(e => e.MachineNumber).IsRequired(false);
        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.Program).IsRequired(false);

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.PlcVariable)
            .WithMany(p => p.MachinePlcVariables)
            .HasForeignKey(e => e.PlcVariableId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
