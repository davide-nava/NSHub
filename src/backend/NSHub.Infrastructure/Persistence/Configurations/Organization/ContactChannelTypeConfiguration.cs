// <copyright file="ContactChannelTypeConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Organization;

public class ContactChannelTypeConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<ContactChannelType>
{
    public void Configure(EntityTypeBuilder<ContactChannelType> builder)
    {
        _ = builder.ToTable("ContactChannelType", "dbo");

        _ = builder.Ignore(e => e.Id);
        _ = builder.HasKey(e => e.ContactChannelTypeCode);

        _ = builder.Property(e => e.ContactChannelTypeCode).HasMaxLength(20).IsRequired();
        _ = builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(250).IsRequired(false);
    }
}
