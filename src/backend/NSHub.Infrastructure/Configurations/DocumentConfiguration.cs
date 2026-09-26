using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("Document", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();
        builder.Property(e => e.DateInsert).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.DateDelete).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.DateUpdate).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.UserInsertId).IsRequired(false);
        builder.Property(e => e.UserDeleteId).IsRequired(false);
        builder.Property(e => e.UserUpdateId).IsRequired(false);
        builder.Property(e => e.TenantId).IsRequired(false);
        builder.Property(e => e.RowVersion).IsRowVersion();
        builder.Property(e => e.PurchaseInvoiceId).IsRequired();
        builder.Property(e => e.DocumentId).IsRequired();
        builder.Property(e => e.CustomerId).IsRequired();
        builder.Property(e => e.DocumentGroupId).IsRequired();
        builder.Property(e => e.SupplierId).IsRequired();
        builder.Property(e => e.MachineTypeId).IsRequired(false);
        builder.Property(e => e.MachineId).IsRequired(false);
        builder.Property(e => e.DocumentTypeId).IsRequired();
        builder.Property(e => e.Name).IsRequired(false);
        builder.Property(e => e.InsertionDate).HasColumnType("datetime").IsRequired(false);
        builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        builder.Property(e => e.FileData).IsRequired(false);
        builder.Property(e => e.Extension).IsRequired(false);
        builder.Property(e => e.ArticleCode).HasMaxLength(255).IsUnicode(false).IsRequired();
        builder.Property(e => e.IsEnabled).IsRequired(false);
        builder.Property(e => e.Title).HasMaxLength(256).IsRequired();
        builder.Property(e => e.Url).IsRequired();
        builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        builder.Property(e => e.Src).IsRequired();

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Customer)
            .WithMany(p => p.Documents)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.DocumentGroup)
            .WithMany(p => p.Documents)
            .HasForeignKey(e => e.DocumentGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.DocumentType)
            .WithMany(p => p.Documents)
            .HasForeignKey(e => e.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
