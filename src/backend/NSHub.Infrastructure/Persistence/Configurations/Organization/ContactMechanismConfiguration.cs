// <copyright file="ContactMechanismConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Organization;

public class ContactMechanismConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<ContactMechanism>
{
    public void Configure(EntityTypeBuilder<ContactMechanism> builder)
    {
        _ = builder.ToTable("ContactMechanism", "dbo");

        _ = builder.Property(e => e.PartyId).IsRequired();
        _ = builder.Property(e => e.ContactChannelTypeCode).HasMaxLength(20).IsRequired();
        _ = builder.Property(e => e.ContactValue).HasMaxLength(255).IsRequired();
        _ = builder.Property(e => e.UsageDescription).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.IsDefault).IsRequired();
        _ = builder.Property(e => e.IsVerified).IsRequired();
        _ = builder.Property(e => e.Notes).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.CreatedOn).HasColumnType("datetimeoffset(7)").HasMaxLength(7).IsRequired();

        _ = builder.HasOne(e => e.ContactChannelType)
            .WithMany()
            .HasForeignKey(e => e.ContactChannelTypeCode)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Party)
            .WithMany()
            .HasForeignKey(e => e.PartyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
