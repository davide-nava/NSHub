using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PostfinanceEbill : BaseEntity
{
    public Guid DocumentManagementId { get; set; }

    public bool Accepted { get; set; }

    public DateTime DateSent { get; set; }

    public bool GetProtocol { get; set; }

    public bool GetSignedBill { get; set; }

    public bool GetProtocolStatus { get; set; }

    public string GetProtocolErrorCode { get; set; } = null!;

    public string GetProtocolErrorText { get; set; } = null!;

    public string SignedBill { get; set; } = null!;

    public virtual DocumentManagement? DocumentManagement { get; set; }

}
