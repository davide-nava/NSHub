// <copyright file="AuditableTenantEntityConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Common;

namespace NSHub.Infrastructure.Common;

public class AuditableTenantEntityConfiguration(
    IRequestContext requestContext)
    : AuditableEntityConfigurationBase<AuditableTenantEntity>
{
    public override void Configure(
        EntityTypeBuilder<AuditableTenantEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder.Property(e => e.TenantId)
            .IsRequired(false);

        builder.HasQueryFilter(e =>
            EF.Property<DateTime?>(e, nameof(ISoftDeletable.DateDelete)) == null &&
            (
                e.TenantId == requestContext.TenantId
            ));
    }
}
