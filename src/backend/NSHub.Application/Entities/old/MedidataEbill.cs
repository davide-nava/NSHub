using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class MedidataEbill : BaseEntity
{
    public Guid DocumentId { get; set; }

    public DateTime CreationDate { get; set; }

    public DocumentStatusType DocumentStatusType { get; set; }

    public string TransmissionReference { get; set; } = null!;

    public string ErrorMessage { get; set; } = null!;

    public string XmlContent { get; set; } = null!;

    public bool Test { get; set; }

    public bool NotificationErrorRead { get; set; }

    public string XmlResponse { get; set; } = null!;

    public bool ResponseRead { get; set; }

    public Guid InternalId { get; set; }

    public string DocumentReference { get; set; } = null!;

    public virtual Document? Document { get; set; }

}
