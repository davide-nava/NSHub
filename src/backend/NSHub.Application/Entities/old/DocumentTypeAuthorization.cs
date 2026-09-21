using System;
using System.Collections.Generic;

using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class DocumentTypeAuthorization : BaseEntity
{
    public Guid DocumentTypeId { get; set; }

    public Guid UserId { get; set; }

    public bool IsViewLocked { get; set; }

    public string EditMode { get; set; } = null!;

    public string DeleteMode { get; set; } = null!;

    public string EvasionMode { get; set; } = null!;

    public int IsInsertLocked { get; set; }

    public virtual User? User { get; set; }
    public virtual DocumentType? DocumentType { get; set; }


}
