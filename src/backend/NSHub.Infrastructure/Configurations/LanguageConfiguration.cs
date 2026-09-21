// <copyright file="LanguageConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Entities;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Configurations;

public class LanguageConfiguration(IRequestContext requestContext) : BaseConfiguration<Language>, IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder) =>  base.Configure(builder, requestContext);
}
