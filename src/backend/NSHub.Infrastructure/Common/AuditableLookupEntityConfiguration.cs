// <copyright file="AuditableLookupEntityConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Common;

namespace NSHub.Infrastructure.Common;

public sealed class AuditableLookupEntityConfiguration(IRequestContext requestContext)
    : AuditableEntityConfigurationBase<AuditableLookupEntity>
{
    public override void Configure(EntityTypeBuilder<AuditableLookupEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder.Property(e => e.TenantId).IsRequired(false);

        builder.Property(e => e.Code).HasMaxLength(256).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();

        builder.HasQueryFilter(e =>
            EF.Property<DateTime?>(e, nameof(ISoftDeletable.DateDelete)) == null &&
            (
                e.TenantId == requestContext.TenantId
            ));
    }
}
