// <copyright file="TicketConfiguration.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Tickets.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSHub.Domain.Tickets.ValueObjects;

/// <summary>
/// EF Core configuration for <see cref="Ticket"/>.
/// </summary>
public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        _ = builder.ToTable("Tickets");

        _ = builder.HasKey(t => t.Id);
        _ = builder.Property(t => t.Id)
            .HasConversion(id => id.Value, value => new TicketId(value))
            .ValueGeneratedNever();

        _ = builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        _ = builder.Property(t => t.Description)
            .HasMaxLength(4000)
            .IsRequired();

        _ = builder.Property(t => t.RequesterId)
            .IsRequired();

        _ = builder.Property(t => t.AssignedTechnicianId);

        _ = builder.Property(t => t.Priority)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(t => t.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.OwnsOne(t => t.Sla, slaBuilder =>
        {
            _ = slaBuilder.Property(s => s.ResolutionDeadlineUtc).IsRequired();
            _ = slaBuilder.Property(s => s.MaximumResolutionTime).IsRequired();
        });

        _ = builder.Property(t => t.ResolutionNotes)
            .HasMaxLength(4000);

        _ = builder.Property(t => t.ResolvedAtUtc);
        _ = builder.Property(t => t.ClosedAtUtc);
        _ = builder.Property(t => t.CreatedAtUtc).IsRequired();

        _ = builder.HasMany(t => t.Comments)
            .WithOne()
            .HasForeignKey(c => c.TicketId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Metadata.FindNavigation(nameof(Ticket.Comments))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
