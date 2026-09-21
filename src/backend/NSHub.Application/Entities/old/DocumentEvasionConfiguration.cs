using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class DocumentEvasionConfiguration : BaseEntity
{
    public Guid DocumentTypeId { get; set; }

    public Guid DocumentTypeEvasionId { get; set; }

    public int TotalMode { get; set; }

    public bool IsChangeSign { get; set; }

    public virtual DocumentType? DocumentType { get; set; }

    public virtual DocumentTypeEvasion? DocumentTypeEvasion { get; set; }

}
