using System;

namespace PlanetHub.ApplicationCore.Entities;

public class AbsenceGroupSelection : BaseEntity
{
    public Guid WorkflowAuthorizationId { get; set; }

    public Guid AccountId { get; set; }

    public DateTime SelectionDate { get; set; }

    public virtual Account? Account { get; set; }

    public virtual WorkflowAuthorization? WorkflowAuthorization { get; set; }

}
