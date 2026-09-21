// <copyright file="SettingConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Configurations;

public class SettingConfiguration(IRequestContext requestContext) : BaseConfiguration<Setting>, IEntityTypeConfiguration<Setting>
{
    public   void Configure(EntityTypeBuilder<Setting> builder) =>  base.Configure(builder, requestContext);
}
