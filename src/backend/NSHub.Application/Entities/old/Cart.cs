using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Cart : BaseEntity
{
    public Guid DocumentTypeId { get; set; }

    public Guid SubjectId { get; set; }

    public Guid DocumentManagementId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public Guid IdEmployee { get; set; }

    public Guid CorrespondentId { get; set; }

    public StatusType StatusType { get; set; }

    public Guid DefaultUserWarehouseId { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public virtual DocumentType? DocumentType { get; set; }
    public virtual Subject? Subject { get; set; }
    public virtual DocumentManagement? DocumentManagement { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual DefaultUserWarehouse? DefaultUserWarehouse { get; set; }
    public virtual Correspondent? Correspondent { get; set; }

}
