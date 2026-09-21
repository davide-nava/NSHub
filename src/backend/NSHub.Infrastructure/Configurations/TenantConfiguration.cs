// <copyright file="TenantConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Configurations;

public class TenantConfiguration(IRequestContext requestContext) : BaseConfiguration<Tenant>, IEntityTypeConfiguration<Tenant>
{
    public   void Configure(EntityTypeBuilder<Tenant> builder) =>  base.Configure(builder, requestContext);
}
