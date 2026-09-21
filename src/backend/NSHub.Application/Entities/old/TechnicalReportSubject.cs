using System;

namespace PlanetHub.ApplicationCore.Entities;

public class TechnicalReportSubject : BaseEntity
{
    public Guid CorrespondentSubjectId { get; set; }

    public Guid TechnicalReportId { get; set; }

    public virtual CorrespondentSubject? CorrespondentSubject { get; set; }

    public virtual TechnicalReport? TechnicalReport { get; set; }
}
