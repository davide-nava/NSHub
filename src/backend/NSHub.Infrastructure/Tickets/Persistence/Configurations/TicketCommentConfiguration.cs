// <copyright file="TicketCommentConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Tickets.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Tickets.Entities;
using NSHub.Domain.Tickets.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="TicketComment"/>.
/// </summary>
public class TicketCommentConfiguration : IEntityTypeConfiguration<TicketComment>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<TicketComment> builder)
    {
        _ = builder.ToTable("TicketComments");

        _ = builder.HasKey(c => c.Id);
        _ = builder.Property(c => c.Id)
            .HasConversion(id => id.Value, value => new TicketCommentId(value))
            .ValueGeneratedNever();

        _ = builder.Property(c => c.TicketId)
            .HasConversion(id => id.Value, value => new TicketId(value))
            .IsRequired();

        _ = builder.Property(c => c.AuthorId)
            .IsRequired();

        _ = builder.Property(c => c.Message)
            .HasMaxLength(4000)
            .IsRequired();

        _ = builder.Property(c => c.CreatedAtUtc)
            .IsRequired();

        _ = builder.Property(c => c.IsInternalOnly)
            .IsRequired();
    }
}
