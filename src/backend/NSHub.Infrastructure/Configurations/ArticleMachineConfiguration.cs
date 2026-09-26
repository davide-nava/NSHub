using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Configurations;

public class ArticleMachineConfiguration : IEntityTypeConfiguration<ArticleMachine>
{
    public void Configure(EntityTypeBuilder<ArticleMachine> builder)
    {
        builder.ToTable("ArticleMachine", "dbo");

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
        builder.Property(e => e.ArticleId).IsRequired();
        builder.Property(e => e.ArticleGroupId).IsRequired(false);
        builder.Property(e => e.MachineId).IsRequired(false);
        builder.Property(e => e.Quantity).HasPrecision(18, 8).IsRequired();
        builder.Property(e => e.Notes).IsUnicode(false).IsRequired(false);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Article)
            .WithMany(p => p.ArticleMachines)
            .HasForeignKey(e => e.ArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ArticleGroup)
            .WithMany(p => p.ArticleMachines)
            .HasForeignKey(e => e.ArticleGroupId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Machine)
            .WithMany(p => p.ArticleMachines)
            .HasForeignKey(e => e.MachineId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
