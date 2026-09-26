// <copyright file="PersonConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class PersonConfiguration : AuditableTenantEntityConfiguration, IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable(t => t.HasCheckConstraint("CK_Person_Gender", "([Gender]='O' OR [Gender]='F' OR [Gender]='M')"));
        builder.ToTable("Person", "dbo");

        builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
        builder.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false).IsRequired(false);
        builder.Property(e => e.BirthDate).HasColumnType("date").IsRequired(false);
        builder.Property(e => e.BirthPlace).HasMaxLength(100).IsRequired(false);
        builder.Property(e => e.BirthCountryCode).HasMaxLength(2).IsUnicode(false).IsRequired(false).HasDefaultValueSql("('CH')");
        builder.Property(e => e.CivilStatus).HasMaxLength(30).IsRequired(false);

    }
}
