// <copyright file="NotificationConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Configurations;

public class NotificationConfiguration(IRequestContext requestContext) : BaseConfiguration<Notification>, IEntityTypeConfiguration<Notification>
{
    public   void Configure(EntityTypeBuilder<Notification> builder) =>  base.Configure(builder, requestContext);
}
