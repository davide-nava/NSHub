// <copyright file="DocumentConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class DocumentConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        _ = builder.ToTable("Document", "dbo");

        _ = builder.Property(e => e.PurchaseInvoiceId).IsRequired();
        _ = builder.Property(e => e.DocumentId).IsRequired();
        _ = builder.Property(e => e.CustomerId).IsRequired();
        _ = builder.Property(e => e.DocumentGroupId).IsRequired();
        _ = builder.Property(e => e.SupplierId).IsRequired();
        _ = builder.Property(e => e.MachineTypeId).IsRequired(false);
        _ = builder.Property(e => e.MachineId).IsRequired(false);
        _ = builder.Property(e => e.DocumentTypeId).IsRequired();
        _ = builder.Property(e => e.Name).IsRequired(false);
        _ = builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.FileData).IsRequired(false);
        _ = builder.Property(e => e.Extension).IsRequired(false);
        _ = builder.Property(e => e.ArticleCode).HasMaxLength(255).IsUnicode(false).IsRequired();
        _ = builder.Property(e => e.IsEnabled).IsRequired(false);
        _ = builder.Property(e => e.Title).HasMaxLength(256).IsRequired();
        _ = builder.Property(e => e.Url).IsRequired();
        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.Src).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Customer)
            .WithMany(p => p.Documents)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.DocumentGroup)
            .WithMany(p => p.Documents)
            .HasForeignKey(e => e.DocumentGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.DocumentType)
            .WithMany(p => p.Documents)
            .HasForeignKey(e => e.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
