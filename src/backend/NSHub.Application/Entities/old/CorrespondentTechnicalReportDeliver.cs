using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CorrespondentTechnicalReportDeliver : BaseEntity
{
    public Guid TechnicalReportTypeId { get; set; }

    public Guid CorrespondentId { get; set; }

    public string SubjectsId { get; set; } = null!;

    public string EmailAddresses { get; set; } = null!;

    public bool SendToCorrespondentMail { get; set; }

    public virtual TechnicalReportType? TechnicalReportType { get; set; }
    public virtual Correspondent? Correspondent { get; set; }


}
