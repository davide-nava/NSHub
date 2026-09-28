// <copyright file="PersonConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Persistence.Configurations.Organization;

public class PersonConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        _ = builder.ToTable(t => t.HasCheckConstraint("CK_Person_Gender", "([Gender]='O' OR [Gender]='F' OR [Gender]='M')"));
        _ = builder.ToTable("Person", "dbo");

        _ = builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
        _ = builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
        _ = builder.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false).IsRequired(false);
        _ = builder.Property(e => e.BirthDate).HasColumnType("date").IsRequired(false);
        _ = builder.Property(e => e.BirthPlace).HasMaxLength(100).IsRequired(false);
        _ = builder.Property(e => e.BirthCountryCode).HasMaxLength(2).IsUnicode(false).IsRequired(false).HasDefaultValueSql("('CH')");
        _ = builder.Property(e => e.CivilStatus).HasMaxLength(30).IsRequired(false);
    }
}
