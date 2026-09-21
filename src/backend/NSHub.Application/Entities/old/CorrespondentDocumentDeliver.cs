using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CorrespondentDocumentDeliver : BaseEntity
{
    public Guid DocumentTypeId { get; set; }

    public Guid CorrespondentId { get; set; }

    public string SubjectsId { get; set; } = null!;

    public string EmailAddresses { get; set; } = null!;

    public bool SendToCorrespondentMail { get; set; }

    public virtual Correspondent? Correspondent { get; set; }
    public virtual DocumentType? DocumentType { get; set; }

}
