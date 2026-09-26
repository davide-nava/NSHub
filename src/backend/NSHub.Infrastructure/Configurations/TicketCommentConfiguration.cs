// <copyright file="TicketCommentConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Application.Interfaces;
using NSHub.Domain.Entities;
using NSHub.Infrastructure.Common;

namespace NSHub.Infrastructure.Configurations;

public class TicketCommentConfiguration(IRequestContext requestContext)
    : AuditableTenantEntityConfiguration(requestContext), IEntityTypeConfiguration<TicketComment>
{
    public void Configure(EntityTypeBuilder<TicketComment> builder)
    {
        _ = builder.ToTable("TicketComment", "dbo");

        _ = builder.Property(e => e.TicketId).IsRequired();
        _ = builder.Property(e => e.Description).HasMaxLength(512).IsRequired();
        _ = builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();
        _ = builder.Property(e => e.UserId).IsRequired();

        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserInsertId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserUpdateId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserDeleteId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne<Tenant>().WithMany().HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Restrict);
        _ = builder.HasOne(e => e.Ticket)
            .WithMany(p => p.TicketComments)
            .HasForeignKey(e => e.TicketId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.User)
            .WithMany(p => p.TicketComments)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
