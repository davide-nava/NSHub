using System;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkflowAuthorizationEmployee : BaseEntity
{
    public Guid WorkflowAuthorizationId { get; set; }

    public Guid EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual WorkflowAuthorization? WorkflowAuthorization { get; set; }
}
