// <copyright file="OrganizationConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;
using OrganizationEntity = NSHub.Domain.Entities.Organization.Organization;

namespace NSHub.Infrastructure.Persistence.Configurations.Organization;

public class OrganizationConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<OrganizationEntity>
{
    public void Configure(EntityTypeBuilder<OrganizationEntity> builder)
    {
        _ = builder.ToTable("Organization", "dbo");

        _ = builder.Property(e => e.LegalName).HasMaxLength(255).IsRequired();
        _ = builder.Property(e => e.TradeName).HasMaxLength(255).IsRequired(false);
        _ = builder.Property(e => e.LegalForm).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.ElectronicInvoicingCode).HasMaxLength(30).IsRequired(false);
        _ = builder.Property(e => e.CommercialRegisterNumber).HasMaxLength(50).IsRequired(false);
        _ = builder.Property(e => e.ShareCapital).HasPrecision(18, 2).IsRequired(false);
        _ = builder.Property(e => e.CurrencyCode).HasMaxLength(3).IsUnicode(false).IsRequired(false).HasDefaultValueSql("('CHF')");
    }
}
