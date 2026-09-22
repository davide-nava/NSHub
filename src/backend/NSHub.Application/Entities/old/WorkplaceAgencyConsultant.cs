using System;

namespace NSHub.ApplicationCore.Entities;

public class WorkplaceAgencyConsultant : BaseEntity
{
    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public Guid WorkplaceAgencyId { get; set; }

    public Guid ConsultantId { get; set; }

    public virtual WorkplaceAgency? WorkplaceAgency { get; set; }

    public virtual Consultant? Consultant { get; set; }
}
