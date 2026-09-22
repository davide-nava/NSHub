using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class DocumentCorrespondentMap : BaseEntity
{
    public Guid DocumentTypeId { get; set; }

    public Guid DocumentFieldId { get; set; }

    public Guid CorrespondentCorrelationTypeId { get; set; }

    public Guid CorrespondentFieldId { get; set; }

    public CarryEvasionType CarryEvasionType { get; set; }

    public string DocumentEvasionText { get; set; } = null!;

    public virtual DocumentType? DocumentType { get; set; }

}
