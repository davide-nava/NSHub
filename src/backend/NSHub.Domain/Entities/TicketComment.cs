// <copyright file="TicketComment.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class TicketComment : AuditableTenantEntity
{
    public Guid TicketId { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public DateTime Date { get; protected set; }
    public Guid UserId { get; protected set; }
    public virtual Ticket? Ticket { get; protected set; }
    public virtual User? User { get; protected set; }

    protected TicketComment() { }

    public static TicketComment Create()
    {
        return new TicketComment();
    }
}
