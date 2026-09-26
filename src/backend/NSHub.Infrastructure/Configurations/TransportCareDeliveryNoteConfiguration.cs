// <copyright file="TransportCareDeliveryNoteConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TransportCareDeliveryNoteConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<TransportCareDeliveryNote>
{
    public void Configure(EntityTypeBuilder<TransportCareDeliveryNote> builder)
    {
        builder.ToTable("TransportCareDeliveryNote", "dbo");


        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
    }
}
