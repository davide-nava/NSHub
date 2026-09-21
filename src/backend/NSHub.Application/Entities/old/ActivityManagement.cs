using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ActivityManagement : BaseEntity
{
    public DateTime InputDate { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid ActivityTypeId { get; set; }

    public virtual Employee? Employee { get; set; }


    public string CorrespondentTitle { get; set; } = null!;

    public string CorrespondentCode { get; set; }

    public IEnumerable<StringGroupList> CorrespondentNames { get; set; }



    public string CorrespondentLocality { get; set; } = null!;

    public string CorrespondentPostalCode { get; set; } = null!;

    public string CorrespondentAddress { get; set; } = null!;

    public string CorrespondentTelephone { get; set; } = null!;

    public string CorrespondentFax { get; set; } = null!;

    public string CorrespondentEmail { get; set; } = null!;

    public string SubjectTitle { get; set; } = null!;

    public string SubjectName { get; set; } = null!;

    public IEnumerable<TranslationGroupList> Notes { get; set; }


    public string Clipboard { get; set; } = null!;

    public DateTime ExpiringDate { get; set; }

    public ProgressStateType ProgressStateType { get; set; }

    public int ExpiringOffset { get; set; }

    public ColorType BackColor { get; set; }

    public ColorType ForeColor { get; set; }

    public Guid CorrespondentId { get; set; }

    public Guid SubjectId { get; set; }

    public virtual Correspondent? Correspondent { get; set; }
    public virtual Subject? Subject { get; set; }


    public string PrimaryResources { get; set; } = null!;

    public string SecondaryResources { get; set; } = null!;

    public DateTime LastProgressDate { get; set; }

    public Guid CallId { get; set; }

    public virtual Call? Call { get; set; }


    public string RefExternal { get; set; } = null!;

    public Guid JobEntryId { get; set; }

    public virtual JobEntry? JobEntry { get; set; }

    public string GenericObjects { get; set; } = null!;

    public virtual ActivityType? ActivityType { get; set; }

}
