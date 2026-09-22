using System;
using System.Diagnostics;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ActivityProgress : BaseEntity
{
    public Guid ActivityId { get; set; }

    public Guid EmployeeId { get; set; }

    public DateTime ProgressDate { get; set; }

    public int ProgressState { get; set; }

    public Guid CallId { get; set; }

    public Guid ActivityManagementId { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public Guid DescriptionSubjectId { get; set; }

    public virtual TranslationGroup? DescriptionSubject { get; set; }

    public Guid DescriptionRefExternalId { get; set; }
    public virtual TranslationGroup? DescriptionRefExternal { get; set; }

    public virtual Call? Call { get; set; }

    public virtual ActivityManagement? ActivityManagement { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Activity? Activity { get; set; }
}
